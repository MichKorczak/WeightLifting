using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.DataTransferObject
{
    public class CompetitionForUpdate
    {
        [Required]
        public string Date { get; set; }
        public string Name { get; set; }
    }
}
