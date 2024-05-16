using Library.BLL.Services;
using Library.BLL;
using Library.DAL.Data.Identity;
using Library.DAL.Data;
using Library.DAL.Model.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Library.System.Errors;
using Library.BLL.Interfaces.Servises;

namespace Library.System.Helpers
{
    public static class AppExtentions
    {
        public  static IServiceCollection addAppServices(this IServiceCollection Services)
        {
            
           Services.AddScoped(typeof(IUniteOfWork), typeof(UniteOfWork));
           Services.AddAutoMapper(m => m.AddProfile(new MappingProfiles()));
           Services.Configure<ApiBehaviorOptions>(options => {
                options.InvalidModelStateResponseFactory = (actioncontext) =>
                {
                    var errors = actioncontext.ModelState.Where(p => p.Value.Errors.Count() > 0)
                                                         .SelectMany(p => p.Value.Errors)
                                                          .Select(e => e.ErrorMessage).ToArray();

                    var apiValidationResponse = new ApiValidationResponse() { Errors = errors };

                    return new BadRequestObjectResult(apiValidationResponse);
                };

            });
           Services.AddIdentity<AppUser, IdentityRole>(Options =>
            {
                Options.Password.RequiredLength = 8;
            }).AddEntityFrameworkStores<LibraryContext>().AddDefaultTokenProviders();
            Services.AddScoped(typeof(IAuthServices), typeof(AuthServices));
            Services.AddScoped(typeof(IBookServices), typeof(BookServices));
            Services.AddScoped(typeof(IPatronServices), typeof(PatronServices));
            Services.AddScoped(typeof(IBorrowingServices), typeof(BorrowingServices));
           



            return Services;
        }

    }
}
