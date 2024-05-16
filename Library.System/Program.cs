using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Library.BLL.Interfaces;
using Library.BLL.Repositories;
using Library.BLL.Services;
using Library.DAL.Data;
using Library.DAL.Data.Identity;
using Library.DAL.Model.Identity;
using Library.System.Errors;
using Library.System.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Library.BLL;
using Microsoft.OpenApi.Models;
using Library.System.Middleware;

namespace Library.System
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Config Services
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region swager Auth
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo", Version = "v1" });
            });
            builder.Services.AddSwaggerGen(swagger =>
            {
                //This is to generate the Default UI of Swagger Documentation    
                swagger.SwaggerDoc("v2", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ASP.NET 5 Web API",
                    Description = " ITI Projrcy"
                });

                // To Enable authorization using Swagger (JWT)    
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
     {
         {
         new OpenApiSecurityScheme
         {
         Reference = new OpenApiReference
         {
         Type = ReferenceType.SecurityScheme,
         Id = "Bearer"
         }
         },
         new string[] {}
         }
     });
            });

            #endregion
             
            
            builder.Services.AddDbContext<LibraryContext>(options => {
                options.EnableSensitiveDataLogging();
                options.UseLazyLoadingProxies().UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
                });
            //builder.Services.AddDbContext<AppIdentityDbContext>(Options => Options.UseSqlServer(builder
            //        .Configuration.GetConnectionString("IdentityConnection")));
            builder.Services.addAppServices();
            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["JWT:ValidAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"])),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromHours(double.Parse(builder.Configuration["JWT:Expire"]))
                };


            });

            
            #endregion



            var app = builder.Build();


            #region Database
            using var scope = app.Services.CreateScope();
            var service = scope.ServiceProvider;
            var dbContext = service.GetRequiredService<LibraryContext>();
            var loggfactory = service.GetRequiredService<ILoggerFactory>();
            var usermanger = service.GetRequiredService<UserManager<AppUser>>();
            var rolManger = service.GetRequiredService<RoleManager<IdentityRole>>();

            try
            {
                await dbContext.Database.MigrateAsync();
                await AppIdentityDataSeeding.SeedAdmin(usermanger);

            }
            catch (Exception ex)
            {
                var logger = loggfactory.CreateLogger<Program>();
                logger.LogError(ex, "an arror has been occured during apply the maigration");
            }
            #endregion



            #region Kestel
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseRouting();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

           

            app.MapControllers();
            app.UseAuthentication();
            app.UseAuthorization();
            #endregion

            app.Run();
        }
    }
}
