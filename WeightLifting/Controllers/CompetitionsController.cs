using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Services.Services.Interfaces;
using Data.DataTransferObject;
using Data.Models;
using System;
using System.Collections.Generic;

namespace WeightLifting.Controllers
{
    [Produces("application/json")]
    [Route("api/Competitions")]
    public class CompetitionsController : Controller
    {
        private readonly IMapper mapper;
        private readonly ICompetitionService competitionServis;

        public CompetitionsController(IMapper mapper, ICompetitionService competitionServis)
        {
            this.mapper = mapper;
            this.competitionServis = competitionServis;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var attempt = mapper.Map<List<CompetitionForDisplay>>(await competitionServis.GetCompetitionAsync());
            return Ok(attempt);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CompetitionForCreation competition)
        {
            if (!ModelState.IsValid || competition == null)
                return BadRequest();

            var competitionToAdd = mapper.Map<Competition>(competition);
            await competitionServis.AddCompetitionAsync(competitionToAdd);
            if (!await competitionServis.SaveChanges())
                return StatusCode(500, "Fault while saving...");

            var competitionForDisplay = mapper.Map<ContestantForDisplay>(competitionToAdd);
            return Ok(competitionForDisplay);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var competition = competitionServis.GetCompetitionByIdAsync(id).Result;
            if (competition == null)
                return BadRequest();

            await competitionServis.DeleteCompetitionAsync(competition);
            if (!await competitionServis.SaveChanges())
                return StatusCode(500, "Fault while saving...");

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Competition competition)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var originCompetition = competitionServis.GetCompetitionByIdAsync(id);
            if (originCompetition == null)
                return BadRequest();

            mapper.Map(originCompetition, competition);
            if (!await competitionServis.SaveChanges())
                return StatusCode(500, "Fault while saving...");

            var competitionForDisplay = mapper.Map<CompetitionForDisplay>(originCompetition);
            return Ok(competitionForDisplay);
        }
    }
}