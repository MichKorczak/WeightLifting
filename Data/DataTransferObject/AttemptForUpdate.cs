using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Data.Enums;

namespace Data.DataTransferObject
{
    public class AttemptForUpdate
    {        
        [EnumDataType(typeof(NameOfAttempt))]
        public NameOfAttempt NameOfAttempt { get; set; }
        
        [DisplayName("Waga")]
        [Range(1, 200, ErrorMessage = "Waga ma zawierać się w przedziale 1-200 kg")]
        public int Weight { get; set; }

        [DisplayName("Werdykt")]
        public bool Correct { get; set; }
    }
}