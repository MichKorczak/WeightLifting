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
        private readonly IContestantCompetitionServis contestandCompetitionServis;

        public ContestandCompetitionController(IMapper mapper, IContestantCompetitionServis contestandCompetition)
        {
            this.mapper = mapper;
            this.contestandCompetitionServis = contestandCompetition; 
        }

        [HttpGet]
        public async Task<IActionResult> GetContestandCompetition()
        {
            var contestandCompetition = await contestandCompetitionServis.GetContestantCompetition();
            return Ok(contestandCompetition);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ContestantCompetitionForCreation contestandCompetition)
        {
            if (!ModelState.IsValid || contestandCompetition == null)
                return BadRequest();

            var contestandCompetitionToAdd = mapper.Map<ContestantCompetition>(contestandCompetition);
            await contestandCompetitionServis.AddConstestandCompetition(contestandCompetitionToAdd);
            var contestandCompetitionForDisplay = mapper.Map<ContestantCompetitionForDisplay>(contestandCompetitionToAdd);
            return Ok(contestandCompetitionForDisplay);
        }
    }
}