using Data.Enums;

namespace Data.DataTransferObject
{
    public class AttemptForDisplay
    {
        public NameOfAttempt NameOfAttempt { get; set; }
        public int Weight { get; set; }
        public bool Correct { get; set; }
    }
}