using System.ComponentModel.DataAnnotations;

namespace ShopAPI.Controllers
{
    public class LoginUserDto
    {
        [System.ComponentModel.DataAnnotations.Required]
        [EmailAddress]
        public string Email { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string Password { get; set; }
    }

}