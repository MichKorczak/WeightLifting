using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.DataTransferObject
{
    public class ContestantCompetitionForUpdate
    {
        [Required]
        public decimal Weight { get; set; }
        public string Club { get; set; }
    }
}
