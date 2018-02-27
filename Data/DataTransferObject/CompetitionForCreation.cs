using System;
using System.ComponentModel.DataAnnotations;

namespace Data.DataTransferObject
{
    public class CompetitionForCreation
    {
        [Required]
        public DateTime Date { get; set; }
        public string Name { get; set; }
    }
}
