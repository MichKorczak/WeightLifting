using System.ComponentModel.DataAnnotations;
using Data.Enums;

namespace Data.DataTransferObject
{
    public class ContestantForCreation
    {
        [Required] [MinLength(3)] public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        public string LastName { get; set; }

        [Required]
        public string DateOfBirthday { get; set; }

        [Required]
        [EnumDataType(typeof(Sex))] public Sex Sex { get; set; }
    }
}