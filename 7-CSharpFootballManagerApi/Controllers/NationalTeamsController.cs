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
    public class NationalNationalTeamsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public NationalNationalTeamsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/NationalTeams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NationalTeam>>> GetNationalTeams()
        {
            var nationalTeams = await _unitOfWork.NationalTeamService.GetAllWithFootballersAsync();
            return Ok(nationalTeams);
        }

        // GET: api/NationalTeams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NationalTeam>> GetNationalTeam(int id)
        {
            var nationalTeams = await _unitOfWork.NationalTeamService.GetAsync(id);
            return Ok(nationalTeams);
        }

        // PUT: api/NationalTeams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNationalTeam(int id, NationalTeam nationalTeams)
        {
            await _unitOfWork.NationalTeamService.UpdateAsync(id, nationalTeams);
            return NoContent();
        }

        [HttpPost("{id}/add-footballer")]
        public async Task<IActionResult> AddFootballer(int id, [FromBody] Footballer footballer)
        {
            footballer.NationalTeam = await _unitOfWork.NationalTeamService.GetAsync(id);
            var createFootballer = await _unitOfWork.FootballerService.CreateAsync(footballer);

            return Ok(createFootballer);
        }

        // POST: api/NationalTeams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NationalTeam>> PostNationalTeam(NationalTeam nationalTeams)
        {
            var createdNationalTeam = await _unitOfWork.NationalTeamService.CreateAsync(nationalTeams);
            //await _unitOfWork.SaveChangesAsync();
            return Ok(createdNationalTeam);
        }

        // DELETE: api/NationalTeams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNationalTeam(int id)
        {
            await _unitOfWork.NationalTeamService.DeleteAsync(id);
            return NoContent();
        }
    }
}
