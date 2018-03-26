using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace Data.User
{
    public class Registration
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Mail { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and max {1} charakters long",
            MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password nad confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-z""'-\s-]*$")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-z""'-\s-]*$")]
        public string LastName { get; set; }

        // nie wiem czy nie należało by dodać jeszcze jakiegoś ID

    }
}
