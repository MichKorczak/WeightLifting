using System.ComponentModel.DataAnnotations;

namespace Data.DataTransferObject
{
    public class UserForLogin
    {
        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string Password { get; set; }
    }
}