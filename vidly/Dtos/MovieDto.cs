using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using vidly.Models;

namespace vidly.Dtos
{
    public class MovieDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public byte GenreId { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime ReleaseDate { get; set; }
        public byte NumberInStock { get; set; }
    }
}