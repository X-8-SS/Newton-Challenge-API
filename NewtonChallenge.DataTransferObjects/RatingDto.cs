﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewtonChallenge.DataTransferObjects
{
    public class RatingDto
    {
        public int RatingId { get; set; }

        [StringLength(5, MinimumLength = 1)]
        [Required]
        public string Category { get; set; }
    }
}
