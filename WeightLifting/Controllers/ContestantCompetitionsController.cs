using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Data.DataTransferObject;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Interfaces;

namespace WeightLifting.Controllers
{
    [Produces("application/json")]
    [Route("api/ContestantCompetitions")]
    public class ContestantCompetitionsController : Controller 
    {
        private readonly IContestantCompetitionService contestantCompetitionServis;
        private readonly ICompetitionService competitionService;
        private readonly IContestantService contestantService;
        private readonly IMapper mapper;

        public ContestantCompetitionsController(IMapper mapper, IContestantCompetitionService contestandCompetition, 
            ICompetitionService competitionService, IContestantService contestantService)
        {
            this.mapper = mapper;
            this.competitionService = competitionService;
            this.contestantService = contestantService;
            this.contestantCompetitionServis = contestandCompetition;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var contestandCompetition = mapper.Map<List<ContestantCompetitionForDisplay>>(await contestantCompetitionServis.GetContestantCompetitionAsync());
            return Ok(contestandCompetition);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ContestantCompetitionForCreation contestandCompetition)
        {
            if (!ModelState.IsValid || contestandCompetition == null)
                return BadRequest();
            contestandCompetition.Competition = 
                competitionService.GetCompetitionByIdAsync(contestandCompetition.CompetitionId).Result;
            contestandCompetition.Contestant =
                contestantService.GetContestantsByIdAsync(contestandCompetition.ContestantId).Result;

            var contestandCompetitionToAdd = mapper.Map<ContestantCompetition>(contestandCompetition);

            await contestantCompetitionServis.AddConstestandCompetitionAsync(contestandCompetitionToAdd);
            if (!await contestantCompetitionServis.SaveChanges())
                return StatusCode(500, "Fault while saving...");

            var contestandCompetitionForDisplay =
                mapper.Map<ContestantCompetitionForDisplay>(contestandCompetitionToAdd);
            return Ok(contestandCompetitionForDisplay);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var contestantCompetition = contestantCompetitionServis.GetContestantCompetitionByIdAsync(id).Result;
            if (contestantCompetition == null)
                return BadRequest();
            await contestantCompetitionServis.DeleteContestantCompetitionAsync(contestantCompetition);
            if (!await contestantCompetitionServis.SaveChanges())
                return StatusCode(500, "Fault while saving...");
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContestantCompetition(Guid id,
            [FromBody] ContestantCompetitionForUpdate contestantCompetition)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var originContestantCompetition = contestantCompetitionServis.GetContestantCompetitionByIdAsync(id);
            if (originContestantCompetition == null)
                return BadRequest();

            Mapper.Map(originContestantCompetition, contestantCompetition);
            if (!await contestantCompetitionServis.SaveChanges())
                return StatusCode(500, "Fault while saving...");
            var contestantCompetitionForDisplay =
                mapper.Map<ContestantCompetitionForDisplay>(originContestantCompetition);

            return Ok(contestantCompetitionForDisplay);
        }
    }
}