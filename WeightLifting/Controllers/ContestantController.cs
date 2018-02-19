using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Services.Services.Interfaces;
using Data.DataTransferObject;
using Data.Models;

namespace WeightLifting.Controllers
{
    [Produces("application/json")]
    [Route("api/Contestant")]
    public class ContestantController : Controller
    {
        private readonly IMapper mapper;
        private readonly IContestantServis contestantServis;

        public ContestantController(IMapper mapper, IContestantServis contestantServis)
        {
            this.mapper = mapper;
            this.contestantServis = contestantServis;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var contestants = await contestantServis.GetContestans();
            return Ok(contestants);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ContestandForCreation contestand)
        {
            if (!ModelState.IsValid || contestand == null)
                return BadRequest();

            var contestandToAdd = mapper.Map<Contestant>(contestand);
            await contestantServis.AddContestant(contestandToAdd);
            var contestantForDisplay = mapper.Map<ContestantForDisplay>(contestandToAdd);
            return Ok(contestantForDisplay);

        }
    }
}S