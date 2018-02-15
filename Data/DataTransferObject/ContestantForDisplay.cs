﻿using Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DataTransferObject
{
    public class ContestantForDisplay
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirtch { get; set; }
        public Sex Sex { get; set; }

    }
}