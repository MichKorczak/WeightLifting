using System.ComponentModel.DataAnnotations;
using Data.Enums;

namespace Data.DataTransferObject
{
    public class ContestantForUpdate
    {
        public string Name { get; set; }

        public string DateOfBirthday { get; set; }

        public Sex Sex { get; set; }
    }
}