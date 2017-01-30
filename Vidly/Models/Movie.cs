﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Display(Name="Genre")]
        public byte GenreId { get; set; }

        [Required]
        [Display(Name="Release Date")]
        public DateTime ReleasedDate { get; set; }

        public DateTime AddedToDatabaseDate { get; set; }

        [Required]
        [Display(Name="Number in Stock")]
        public int Stock { get; set; }

    }
}