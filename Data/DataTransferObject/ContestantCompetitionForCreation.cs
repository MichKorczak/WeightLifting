using System.ComponentModel.DataAnnotations;
using Data.Models;

namespace Data.DataTransferObject
{
    public class ContestantCompetitionForCreation
    {
        [Required]
        public decimal Weight { get; set; }

        [Required]
        public string Club { get; set; }

        [Required]
        public decimal Sincler { get; set; }

        [Required]
        public Contestant Contestant { get; set; }

        [Required]
        public Competition Competition { get; set; }
    }
}