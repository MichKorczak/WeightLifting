﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Enums;

namespace Data.Models
{
    public class Attempt
    {
        [Key]
        public Guid Id { get; set; }

        [EnumDataType(typeof(NameOfAttempt))]
        public NameOfAttempt NameOfAttempt { get; set; }

        public int Weight { get; set; }
        public bool Correct { get; set; }

        [ForeignKey("Competition")]
        public Guid CompetitionId { get; set; }

        public virtual Competition Competition { get; set; }
    }
}