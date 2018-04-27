using System;
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
        public Guid ContestantId { get; set; }

        public Contestant Contestant { get; set; }

        [Required]
        public Guid CompetitionId { get; set; }

        public Competition Competition { get; set; }
    }
}