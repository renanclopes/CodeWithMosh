using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set;}

        public MovieGenre Genre { get; set; }

        [Display(Name="Genre")]
        [Required]
        public int GenreId { get; set; }

        [Display(Name="Release Date")]
        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Display(Name="Number in Stock")]
        [Required]
        public int NumberInStock { get; set; }
    }
}