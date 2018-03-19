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
        public async Task<IActionResult> GetContestant()
        {
            var contestants = await contestantServis.GetContestants();
            return Ok(contestants);
        }

        [HttpGet("{lastName}", Name = "GetContestantByName")]
        public async Task<IActionResult> GetContestant(string lastName)
        {
            var contestant = await contestantServis.GetContestantsByName(lastName);
            return Ok(contestant);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ContestantForCreation contestant)
        {
            if (!ModelState.IsValid || contestant == null)
                return BadRequest();

            var contestandToAdd = mapper.Map<Contestant>(contestant);
            var value = await contestantServis.AddContestant(contestandToAdd);
            if (value <= 0)
            {
                return StatusCode(500, "Wystąpił bład w zapisie");
            }
            var contestantForDisplay = mapper.Map<ContestantForDisplay>(contestandToAdd);
            return Ok(contestantForDisplay);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContestant(Guid id)
        {
            var contestant = contestantServis.GetContestantsById(id).Result;
            if (contestant == null)
                return BadRequest();
            var value = await contestantServis.DeleteContestant(contestant);
            if (value <= 0)
            {
                return StatusCode(500, "Wystąpił bład w zapisie");
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContestant(Guid id, [FromBody] Contestant contestant)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var originContestant = contestantServis.GetContestantsById(id).Result;
            if (originContestant == null)
                return BadRequest();
            var value = await contestantServis.UpdateContestant(originContestant, contestant);
            if (value <= 0)
            {
                return StatusCode(500, "Wystąpił bład w zapisie");
            }
            var contestantForDisplay = mapper.Map<ContestantForDisplay>(originContestant);

            return Ok(contestantForDisplay);
        }

    }
}