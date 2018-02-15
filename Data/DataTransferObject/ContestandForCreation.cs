using Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.DataTransferObject
{
    public class ContestandForCreation
    {
        [Required]
        [MinLength(3)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirthday { get; set; }
        [EnumDataType(typeof(Sex))]
        public Sex Sex { get; set; }
    }
}
