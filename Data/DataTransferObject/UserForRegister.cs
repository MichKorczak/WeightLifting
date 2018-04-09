using System;
using System.ComponentModel.DataAnnotations;

namespace Data.DataTransferObject
{
    public class UserForRegister
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }    

        [Required]
        public string LastName { get; set; }

        public int DateOfBirthday { get; set; }
    }
}