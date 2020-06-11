using System.ComponentModel.DataAnnotations;

namespace Client.Models
{
    public class LoginUserForm
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}