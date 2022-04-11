using Microsoft.Build.Framework;

namespace ShopAPI.Controllers
{
    public class UserDto : LoginUserDto
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string FirstName { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string LastName { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string Role { get; set; }
    }

}