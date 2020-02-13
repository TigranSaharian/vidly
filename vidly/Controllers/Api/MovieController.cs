using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using vidly.Dtos;
using vidly.Models;

namespace vidly.Controllers.Api
{
    public class MovieController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetMovie()
        {
            var movieDtos = _context.Movies
                .Include(x => x.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
            return Ok(movieDtos);
        }

        public IHttpActionResult GetMovie(int id)
        {
            Movie movie = _context.Movies.SingleOrDefault(x => x.Id == id);
            if (movie == null)
                return NotFound();
            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                BadRequest();
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        [HttpPut]
        public void UpdateMovie(int id, Movie movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var MovieInDb = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (MovieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(movieDto, MovieInDb);
            _context.SaveChanges();
        }

        [HttpDelete]
        public void Delete(int id)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == id);
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }

    }
}
