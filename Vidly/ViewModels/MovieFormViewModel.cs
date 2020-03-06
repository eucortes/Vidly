using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.Provider;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public int? GenreId { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Date Added")]
        public DateTime? DateAdded { get; set; }
        [Required]
        [Display(Name = "In Stock")]
        [Range(1, 20)]
        public int? InStock { get; set; }

        public string Title => Id!=0? "Edit Movie": "New Movie";

        public MovieFormViewModel()
        {
            Id=0;
        }
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            GenreId = movie.GenreId;
            ReleaseDate = movie.ReleaseDate;
            DateAdded = movie.DateAdded;
            InStock = movie.InStock;

        }
    }
}