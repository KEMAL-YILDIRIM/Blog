using System.ComponentModel.DataAnnotations;

namespace Blog.Api.Dtos
{
    public class Register
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
