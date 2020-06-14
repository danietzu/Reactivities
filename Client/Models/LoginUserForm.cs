using System.ComponentModel.DataAnnotations;

namespace Client.Models
{
    public class LoginUserForm
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [RegularExpression(
            @"^(?:(?=.*[a-z])(?:(?=.*[A-Z])(?=.*[\d\W])|(?=.*\W)(?=.*\d))|(?=.*\W)(?=.*[A-Z])(?=.*\d)).{8,}$",
            ErrorMessage = "The Password must have: \n" +
                           "at least 1 lowercase letter\n" +
                           "at least 1 uppercase letter\n" +
                           "at least 1 number and\n" +
                           "at least 1 symbol")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}