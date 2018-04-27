using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Data.Enums;
using Data.Models;

namespace Data.DataTransferObject
{
    public class AttemptForCreation
    {
        [Required]
        [EnumDataType(typeof(NameOfAttempt))]
        public NameOfAttempt NameOfAttempt { get; set; }

        [Required]
        [DisplayName("Ciężar")]
        [Range(1, 300, ErrorMessage = "Waga ma zawierać się w przedziale 1-300 kg")]
        public int Weight { get; set; }

        [Required]
        [DisplayName("Werdykt")]
        public bool Correct { get; set; }

        [Required]
        public Guid CompetitionId { get; set; }

        public Competition Competition { get; set; }

    }
}