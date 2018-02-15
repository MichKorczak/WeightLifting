using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Models
{
    public class Attempt
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        [ForeignKey("Competition")]
        public Guid CompetitionId { get; set; } 
        public Competition Competition { get; set; }
    }
}
