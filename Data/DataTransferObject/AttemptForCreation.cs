using Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Data.DataTransferObject
{
    public class AttemptForCreation
    {
        [Required]
        [EnumDataType(typeof(NameOfAttempt))]
        public NameOfAttempt NameOfAttempt { get; set; }
        public int Weight { get; set; }
        public bool Correct { get; set; }

    }
}
