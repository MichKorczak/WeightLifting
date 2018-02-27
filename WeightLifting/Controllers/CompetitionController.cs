using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Services.Services.Interfaces;
using Data.DataTransferObject;
using Data.Models;

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
            await competitionServis.AddCompetition(competitionToAdd);
            var competitionForDisplay = mapper.Map<ContestantForDisplay>(competitionToAdd);
            return Ok(competitionForDisplay);
        }
    }
}