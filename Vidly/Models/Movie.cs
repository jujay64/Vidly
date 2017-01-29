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

        public byte GenreId { get; set; }
        [Required]
        public DateTime ReleasedDate { get; set; }

        [Required]
        public DateTime AddedToDatabaseDate { get; set; }

        [Required]
        public int Stock { get; set; }

    }
}