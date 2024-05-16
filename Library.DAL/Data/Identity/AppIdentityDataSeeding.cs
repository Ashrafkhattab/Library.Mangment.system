using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.DAL.Model.Identity;
using Microsoft.AspNetCore.Identity;

namespace Library.DAL.Data.Identity
{
    public static  class AppIdentityDataSeeding
    {
        public static async Task  seadAdminRole(RoleManager<IdentityRole> roleManager)
        {
            if (roleManager.Roles.Count()==0 ) 
            {
                await roleManager.CreateAsync(new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                });
            }
        }
        public static async Task SeedAdmin( UserManager<AppUser> _userManger)
        {
            if(_userManger.Users.Count() == 0)
            {
                var User = new AppUser
                {
                    Id = Guid.NewGuid().ToString(),
                    DisplayName = "Admin",
                    UserName = "Admin",
                    Email = "admin@admin.com",
                    isDeleted = false,
                };
                await _userManger.CreateAsync(User,"admin@123A");
                await _userManger.AddToRoleAsync(User, "Admin");
            }

        }
    }
}
