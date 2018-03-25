﻿using System;
using System.ComponentModel.DataAnnotations;
using Data.Enums;

namespace Data.DataTransferObject
{
    public class ContestantForUpdate
    {
        [Required]
        public string Name { get; set; }
        public string DateOfBirtch { get; set; }
        public Sex Sex { get; set; }
    }
}
