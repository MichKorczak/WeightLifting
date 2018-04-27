using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Competition
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime Date { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ContestantCompetition> ContestantCompetition { get; set; }
        public virtual ICollection<Attempt> Attempt { get; set; }
    }
}