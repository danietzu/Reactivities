using System.ComponentModel.DataAnnotations;

namespace Client.Models
{
    public class RegisterUserForm
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string DisplayName { get; set; }
    }
}