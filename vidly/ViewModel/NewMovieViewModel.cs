using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using vidly.Models;

namespace vidly.ViewModel
{
    public class NewMovieViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }

        public string Title
        {
            get
            {
                return Movie.Id == 0 ? "New Movie" : "Edit Movie";
            }
        }
    }
}