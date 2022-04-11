using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.Data;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> logger;
        private readonly IMapper mapper;
        private readonly Microsoft.AspNetCore.Identity.UserManager<APIUser> userManager;

        public AuthenticationController(ILogger<AuthenticationController> logger, IMapper mapper, Microsoft.AspNetCore.Identity.UserManager<APIUser> userManager)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(UserDto userDto)
        {

            var user = mapper.Map<APIUser>(userDto);
            user.UserName = userDto.Email;
            var result = await userManager.CreateAsync(user, userDto.Password);

            if (result.Succeeded == false)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);
                }
                return BadRequest(ModelState);

            }

            await userManager.AddToRoleAsync(user, "User");
            return Accepted();

        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginUserDto loginUserDto)
        {

            try
            {
                var user = await userManager.FindByEmailAsync(loginUserDto.Email);

                var passwordValid = await userManager.CheckPasswordAsync(user, loginUserDto.Password);

                if (user == null || passwordValid == false)
                {
                    return NotFound();
                }

                return Accepted();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }



}

