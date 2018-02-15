using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Models
{
    public class ContestandCompetition
    {
        [Key]
        public Guid Id { get; set; }
        public decimal Weight { get; set; }
        public string Club { get; set; }
        public Contestant Contestant { get; set; }
        public Competition Competition { get; set; }
        [ForeignKey("Contestant")]
        public Guid ContestandId { get; set; }
        [ForeignKey("Competition")]
        public Guid CompetitionId { get; set; }
    }
}
