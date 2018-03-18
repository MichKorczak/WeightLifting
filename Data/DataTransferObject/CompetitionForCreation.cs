using System;
using System.ComponentModel.DataAnnotations;

namespace Data.DataTransferObject
{
    public class CompetitionForCreation
    {
        [Required]
        public string Date { get; set; }
        public string Name { get; set; }
    }
}
