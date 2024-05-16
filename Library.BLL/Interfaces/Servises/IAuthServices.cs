using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.DAL.Model.Identity;
using Microsoft.AspNetCore.Identity;

namespace Library.BLL.Interfaces.Servises
{
    public interface IAuthServices
    {
        Task<string> CreatTokenAsync(AppUser user, UserManager<AppUser> userManager);
    }
}
