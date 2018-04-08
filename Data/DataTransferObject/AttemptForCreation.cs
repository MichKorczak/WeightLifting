using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Data.Enums;

namespace Data.DataTransferObject
{
    public class AttemptForCreation
    {
        [Required]
        [EnumDataType(typeof(NameOfAttempt))]
        public NameOfAttempt NameOfAttempt { get; set; }

        [Required]
        [DisplayName("Waga")]
        [Range(1, 200, ErrorMessage = "Waga ma zawierać się w przedziale 1-200 kg")]
        public int Weight { get; set; }

        [Required]
        [DisplayName("Werdykt")]
        public bool Correct { get; set; }
    }
}