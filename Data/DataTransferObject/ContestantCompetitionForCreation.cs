using Data.Models;

namespace Data.DataTransferObject
{
    public class ContestantCompetitionForCreation
    {
        public decimal Weight { get; set; }
        public string Club { get; set; }
        public decimal Sincler { get; set; }
        public Contestant Contestant { get; set; }
        public Competition Competition { get; set; }
    }
}
