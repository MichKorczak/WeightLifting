using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Services.Services.Interfaces;
using Data.DataTransferObject;
using Data.Models;
using System.Linq;
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
        public async Task<IActionResult> GetContestantByLastName(string lastName)
        {
            var contestant = await contestantServis.GetContestantsByName(lastName);
            return Ok(contestant);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ContestantForCreation contestand)
        {
            if (!ModelState.IsValid || contestand == null)
                return BadRequest();

            var contestandToAdd = mapper.Map<Contestant>(contestand);
            await contestantServis.AddContestant(contestandToAdd);
            var contestantForDisplay = mapper.Map<ContestantForDisplay>(contestandToAdd);
            return Ok(contestantForDisplay);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContestant(Guid id)
        {
            if (id == null)
                return BadRequest();
            await contestantServis.DeleteContestant(id);
            return new NoContentResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContestant(Guid id, [FromBody] Contestant contestant)
        {
            if (!ModelState.IsValid || contestant == null)
                return BadRequest();

            await contestantServis.UpdateContestant(id, contestant);
            var contestantForDisplay = mapper.Map<ContestantForDisplay>(contestant);
            return Ok(contestantForDisplay);
        }

    }
}