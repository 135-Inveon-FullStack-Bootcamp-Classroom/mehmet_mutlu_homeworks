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
    public class DirectorsController : ControllerBase
    {
        public DirectorService _directorService;

        public DirectorsController(DirectorService directorService)
        {
            _directorService = directorService;
        }

        [HttpGet("get-all-directors")]
        public IActionResult GetAllDirectors()
        {
            var allDirectors = _directorService.GetAllDirectors();
            return Ok(allDirectors);
        }

        [HttpGet("get-director-by-id/{id}")]
        public IActionResult GetDirectorByID(int id)
        {
            var Director = _directorService.GetDirectorByID(id);
            return Ok(Director);
        }

        [HttpPost("add-director")]
        public IActionResult AddDirector([FromBody] DirectorVM director)
        {
            _directorService.AddDirector(director);
            return Ok();
        }

        [HttpPut("update-director-by-id/{id}")]
        public IActionResult UpdateDirectorByID(int id, [FromBody] DirectorVM director)
        {
            var updatedDirector = _directorService.UpdatedirectorByID(id, director);
            return Ok(updatedDirector);
        }

        [HttpDelete("delete-director-by-id/{id}")]
        public IActionResult DeleteDirectorByID(int id)
        {
            _directorService.DeletedirectorByID(id);
            return Ok();
        }
    }
}
