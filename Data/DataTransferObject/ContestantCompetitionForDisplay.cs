using Data.Models;
using System;

namespace Data.DataTransferObject
{
    public class ContestantCompetitionForDisplay
    {
        public Guid Id { get; set; }
        public decimal Weight { get; set; }
        public string Club { get; set; }
        public decimal Sincler { get; set; }
        public Contestant Contestant { get; set; }
        public Competition Competition { get; set; }
    }
}
