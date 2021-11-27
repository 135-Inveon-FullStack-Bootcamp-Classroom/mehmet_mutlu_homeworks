using _6_CSharpIMDbProject.Data.Services;
using _6_CSharpIMDbProject.Data.ViewModels;
using _6_CSharpIMDbProject.DBOperations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _6_CSharpIMDbProject.Controllers
{
    public class MoviesController : ControllerBase
    {
        public MovieService _movieService;

        public MoviesController(MovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("get-all-movies")]
        public IActionResult GetAllMovies()
        {
            var allMovies = _movieService.GetAllMovies();
            return Ok(allMovies);
        }

        [HttpGet("get-movie-by-id/{id}")]
        public IActionResult GetMovieByID(int id)
        {
            var movie = _movieService.GetMovieByID(id);
            return Ok(movie);
        }

        [HttpPost("add-movie")]
        public IActionResult AddMovie([FromBody] MovieVM movie)
        {
            _movieService.AddMovie(movie);
            return Ok();
        }

        [HttpPut("update-movie-by-id/{id}")]
        public IActionResult UpdateMovieByID(int id, [FromBody] MovieVM movie)
        {
            var updatedMovie = _movieService.UpdateMovieByID(id, movie);
            return Ok(updatedMovie);
        }

        [HttpDelete("delete-movie-by-id/{id}")]
        public IActionResult DeleteMovieByID(int id)
        {
            _movieService.DeleteMovieByID(id);
            return Ok();
        }
    }
}
