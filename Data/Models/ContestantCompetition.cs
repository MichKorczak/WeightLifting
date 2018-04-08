using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class ContestantCompetition
    {
        [Key]
        public Guid Id { get; set; }

        public decimal Weight { get; set; }
        public string Club { get; set; }
        public decimal Sincler { get; set; }
        public Contestant Contestant { get; set; }
        public Competition Competition { get; set; }

        [ForeignKey("Contestant")]
        public Guid ContestandId { get; set; }

        [ForeignKey("Competition")]
        public Guid CompetitionId { get; set; }
    }
}