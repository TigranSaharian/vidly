using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
        [Required]
        [Display(Name ="Genre")]
        public byte GenreId { get; set; }
        [Display(Name ="Date Added")]
        public DateTime DateAdded { get; set; }
        [Display(Name ="Release Date")]
        public DateTime ReleaseDate { get; set; }
        [Display(Name ="Number in stock")]
        [Range(1,20)]
        public byte NumberInStock { get; set; }
    }
}