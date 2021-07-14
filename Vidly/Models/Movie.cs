using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vidly.Models
{
    public class Movie
    {
        public int id { get; set; }

        [StringLength(20)]
        [Required]
        [Display(Name = "Movie Name")]
        public string name { get; set; }
        
        public Genre Genre { get; set; }
        
        [Display(Name = "Movie Genre")]
        public int GenreId { get; set; }
        
        [Display(Name="Release Date")]
        public DateTime ReleaseDate { get; set; }
        
        public DateTime DateAdded { get; set; }

        [Range(1,20)]
        [Display(Name = "Number in Stock")]
        public byte NumberInStock { get; set; }
    }
}