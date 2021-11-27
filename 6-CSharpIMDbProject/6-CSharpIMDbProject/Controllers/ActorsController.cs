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
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        public ActorService _actorService;

        public ActorsController(ActorService actorService)
        {
            _actorService = actorService;
        }

        [HttpGet("get-all-actors")]
        public IActionResult GetAllActors()
        {
            var allActors = _actorService.GetAllActors();
            return Ok(allActors);
        }

        [HttpGet("get-actor-by-id/{id}")]
        public IActionResult GetActorByID(int id)
        {
            var actor = _actorService.GetActorByID(id);
            return Ok(actor);
        }

        [HttpPost("add-actor")]
        public IActionResult AddActor([FromBody]ActorVM actor)
        {
            _actorService.AddActor(actor);
            return Ok();
        }

        [HttpPut("update-actor-by-id/{id}")]
        public IActionResult UpdateActorByID(int id, [FromBody]ActorVM actor)
        {
            var updatedActor = _actorService.UpdateActorByID(id, actor);
            return Ok(updatedActor);
        }

        [HttpDelete("delete-actor-by-id/{id}")]
        public IActionResult DeleteActorByID(int id)
        {
            _actorService.DeleteActorByID(id);
            return Ok();
        }
    }
}
