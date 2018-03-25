using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Services.Services.Interfaces;
using Data.DataTransferObject;
using Data.Models;
using System;

namespace WeightLifting.Controllers
{
    [Produces("application/json")]
    [Route("api/Competition")]
    public class CompetitionController : Controller
    {
        private readonly IMapper mapper;
        private readonly ICompetitionServis competitionServis;

        public CompetitionController(IMapper mapper, ICompetitionServis competitionServis)
        {
            this.mapper = mapper;
            this.competitionServis = competitionServis;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompetition()
        {
            var attempt = await competitionServis.GetCompetition();
            return Ok(attempt);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CompetitionForCreation competition)
        {
            if (!ModelState.IsValid || competition == null)
                return BadRequest();

            var competitionToAdd = mapper.Map<Competition>(competition);
            var value = await competitionServis.AddCompetition(competitionToAdd);
            if (value <= 0)
            {
                return StatusCode(500, "Fault while saving...");
            }
            var competitionForDisplay = mapper.Map<ContestantForDisplay>(competitionToAdd);
            return Ok(competitionForDisplay);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompetition(Guid id)
        {
            var competition = competitionServis.GetCompetitionById(id).Result;
            if (competition == null)
                return BadRequest();
            var value = await competitionServis.DeleteCompetition(competition);
            if (value <= 0)
            {
                return StatusCode(500, "Fault while saving...");
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompetition(Guid id, [FromBody] CompetitionForUpdate competition)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var originCompetition = competitionServis.GetCompetitionById(id).Result;
            if (originCompetition == null)
                return BadRequest();
            Mapper.Map(originCompetition, competition);
            if (!await competitionServis.SaveChangesCompetitionAsync())
            {
                return StatusCode(500, "Fault while saving...");
            }
            var competitionForDisplay = mapper.Map<CompetitionForDisplay>(originCompetition);

            return Ok(competitionForDisplay);
        }
    }
}