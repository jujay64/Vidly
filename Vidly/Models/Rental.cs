using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace Vidly.Models
{
    public class Rental
    {
        public int Id { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [Required]
        public int CustomerId { get; set; }

        public Movie Movie { get; set; }

        [Required]
        public int MovieId { get; set; }

        [Display(Name = "Rented Date")]
        public DateTime RentedDate { get; set; }

        [Display(Name = "Returned Date")]
        public DateTime? ReturnedDate { get; set; }
    }
}