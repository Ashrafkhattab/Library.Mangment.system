using Library.BLL.Interfaces.Servises;
using Library.DAL.Model.Identity;
using Library.System.DTOs;
using Library.System.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Library.System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManger;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IAuthServices _authServices;

        public AccountController(UserManager<AppUser> userManger , SignInManager<AppUser> signInManager, IAuthServices authServices)
        {
            _userManger = userManger;
            _signInManager = signInManager;
            _authServices = authServices;
        }

        [HttpPost("login")] // Post:  /api/account/login
        public async Task<ActionResult<UserDTO>> Login(LoginDTO model)
        {
            var user = await _userManger.FindByEmailAsync(model.Email);
            if (user == null) return Unauthorized(new ApiResponse(401));

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!result.Succeeded) return Unauthorized(new ApiResponse(401));

            return Ok(new UserDTO
            { DisplayName = user.DisplayName,
                Email = user.Email,
                Token = await _authServices.CreatTokenAsync(user,_userManger)
            });

        }
        [HttpPost("register")] // Post:  /api/account/register
        public async Task<ActionResult<UserDTO>>  Register(RegisterDTO model)
        {
            var User = new AppUser
            {
                DisplayName = model.DisplayName,
                Email = model.Email,
                UserName = model.Email.Split('@')[0],
                PhoneNumber= model.PhoneNumber,
            };

            var result = await _userManger.CreateAsync(User,model.Password);
            if (!result.Succeeded) return BadRequest(new ApiResponse(400));

            return Ok(new UserDTO
            {
                DisplayName=model.DisplayName,
                Email=model.Email,
                Token= await _authServices.CreatTokenAsync(User, _userManger)
            });
        }
    }
}
