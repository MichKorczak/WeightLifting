using System.ComponentModel.DataAnnotations;

namespace Data.DataTransferObject
{
    public class UserForLogin
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}