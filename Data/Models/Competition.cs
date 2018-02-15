using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Models
{
    public class Competition
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public ICollection<ContestandCompetition> ContestandCompetition { get; set; }
        public ICollection<Attempt> Attempt { get; set; }
        [ForeignKey("ContestantCompetition")]
        public Guid CostestandCompetitionId { get; set; }
        [ForeignKey("Attempt")]
        public Guid AttemptId { get; set; }
    }
}
