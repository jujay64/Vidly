using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebGrease;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [Display(Name="Genre")]
        public byte GenreId { get; set; }

        [Required]
        [Display(Name="Release Date")]
        public DateTime ReleasedDate { get; set; }

        public DateTime AddedToDatabaseDate { get; set; }

        [Required]
        [Range(1,20)]
        [Display(Name="Number in Stock")]
        public int Stock { get; set; }

        [Display(Name = "Number Available")]       
        public int StockAvailable { get; set; }
    }
}