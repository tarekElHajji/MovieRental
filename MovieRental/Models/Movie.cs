using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRental.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Added Date")]
        public DateTime DateAdded { get; set; }


        public int Stock { get; set; }

        [Required]
        [DisplayName("Genre")]
        public int GenreId { get; set; }

        public Genre Genre { get; set; }
        

    }
}