using Data.Enums;
using System;

namespace Data.DataTransferObject
{
    class AttemptForDisplay
    {
        public Guid Id { get; set; }
        public NameOfAttempt NameOfAttempt { get; set; }
        public int Weight { get; set; }
        public bool Correct { get; set; }
    }
}
