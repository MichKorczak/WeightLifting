using System;
using System.ComponentModel.DataAnnotations;

namespace Data.DataTransferObject
{
    public class Register
    {
        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }    

        [Required]
        public string LastName { get; set; }

        public DateTime DateOfBirthday { get; set; }
    }
}