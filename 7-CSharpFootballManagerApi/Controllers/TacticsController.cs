﻿using FootballManagerApi.Entities;
using FootballManagerApi.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TacticsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TacticsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Tactics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tactic>>> GetTactics()
        {
            var tactic = await _unitOfWork.TacticService.GetAllAsync();
            return Ok(tactic);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tactic>> GetTactic(int id)
        {
            var tactic = await _unitOfWork.TacticService.GetAsync(id);
            return Ok(tactic);
        }

        // PUT: api/Tactics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTactic(int id, Tactic tactic)
        {
            await _unitOfWork.TacticService.UpdateAsync(id, tactic);
            return NoContent();
        }

        // POST: api/Tactics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tactic>> PostTactic(Tactic tactic)
        {
            var createdTactic = await _unitOfWork.TacticService.CreateAsync(tactic);
            return Ok(createdTactic);
        }

        // DELETE: api/Tactics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTactic(int id)
        {
            await _unitOfWork.TacticService.DeleteAsync(id);
            return NoContent();
        }
    }
}
