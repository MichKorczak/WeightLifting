using System;
using Data.Enums;

namespace Data.DataTransferObject
{
    public class ContestantForDisplay
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public Sex Sex { get; set; }
    }
}