using System;
using System.Threading.Tasks;
using AutoMapper;
using Data.DataTransferObject;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Interfaces;

namespace WeightLifting.Controllers
{
    [Produces("application/json")]
    [Route("api/ContestandCompetition")]
    public class ContestandCompetitionController : Controller
    {
        private readonly IMapper mapper;
        private readonly IContestantCompetitionServis contestantCompetitionServis;

        public ContestandCompetitionController(IMapper mapper, IContestantCompetitionServis contestandCompetition)
        {
            this.mapper = mapper;
            this.contestantCompetitionServis = contestandCompetition; 
        }

        [HttpGet]
        public async Task<IActionResult> GetContestandCompetition()
        {
            var contestandCompetition = await contestantCompetitionServis.GetContestantCompetition();
            return Ok(contestandCompetition);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ContestantCompetitionForCreation contestandCompetition)
        {
            if (!ModelState.IsValid || contestandCompetition == null)
                return BadRequest();

            var contestandCompetitionToAdd = mapper.Map<ContestantCompetition>(contestandCompetition);
            var value = await contestantCompetitionServis.AddConstestandCompetition(contestandCompetitionToAdd);
            if (value <= 0)
            {
                return StatusCode(500, "Wystąpił bład w zapisie");
            }
            var contestandCompetitionForDisplay = mapper.Map<ContestantCompetitionForDisplay>(contestandCompetitionToAdd);
            return Ok(contestandCompetitionForDisplay);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContestantCompetition(Guid id)
        {
            var contestantCompetition = contestantCompetitionServis.GetContestantCompetitionById(id).Result;
            if (contestantCompetition == null)
                return BadRequest();
            var value = await contestantCompetitionServis.DeleteContestantCompetition(contestantCompetition);
            if (value <= 0)
            {
                return StatusCode(500, "Wystąpił bład w zapisie");
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContestantCompetition(Guid id, [FromBody] ContestantCompetition contestantCompetition)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var originContestantCompetition = contestantCompetitionServis.GetContestantCompetitionById(id).Result;            
            if (originContestantCompetition == null)
                return BadRequest();
            var value = await contestantCompetitionServis.UpdateContestantCompetition(originContestantCompetition, contestantCompetition);
            if (value <= 0)
            {
                return StatusCode(500, "Wystąpił bład w zapisie");
            }
            var contestantCompetitionForDisplay = mapper.Map<ContestantCompetitionForDisplay>(originContestantCompetition);

            return Ok(contestantCompetitionForDisplay);
        }
    }
}