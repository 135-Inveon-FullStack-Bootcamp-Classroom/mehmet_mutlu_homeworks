using _6_CSharpIMDbProject.Data.Services;
using _6_CSharpIMDbProject.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _6_CSharpIMDbProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        public GenreService _genreService;

        public GenresController(GenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet("get-all-genres")]
        public IActionResult GetAllGenres()
        {
            var allGenres = _genreService.GetAllGenres();
            return Ok(allGenres);
        }

        [HttpGet("get-genre-by-id/{id}")]
        public IActionResult GetGenreByID(int id)
        {
            var Genre = _genreService.GetGenreByID(id);
            return Ok(Genre);
        }

        [HttpPost("add-genre")]
        public IActionResult AddGenre([FromBody] GenreVM genre)
        {
            _genreService.AddGenre(genre);
            return Ok();
        }

        [HttpPut("update-genre-by-id/{id}")]
        public IActionResult UpdateGenreByID(int id, [FromBody] GenreVM genre)
        {
            var updatedGenre = _genreService.UpdateGenreByID(id, genre);
            return Ok(updatedGenre);
        }

        [HttpDelete("delete-genre-by-id/{id}")]
        public IActionResult DeleteGenreByID(int id)
        {
            _genreService.DeleteGenreByID(id);
            return Ok();
        }
    }
}
