using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Data.DataTransferObject;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Interfaces;

namespace WeightLifting.Controllers
{
    [Produces("application/json")]
    [Route("api/Contestants")]
    public class ContestantsController : Controller 
    {
        private readonly IContestantService contestantService;
        private readonly IMapper mapper;

        public ContestantsController(IMapper mapper, IContestantService contestantService)
        {
            this.mapper = mapper;
            this.contestantService = contestantService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get() 
        {   
            var contestant = mapper.Map<List<ContestantForDisplay>>(await contestantService.GetContestantsAsync());          
            return Ok(contestant);
        }

        [HttpGet("  lastName", Name = "GetContestantByName")] 
        public async Task<IActionResult> Get(string lastName)
        {
            var contestant = mapper.Map<ContestantForDisplay>(await contestantService.GetContestantsByNameAsync(lastName));
            return Ok(contestant);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ContestantForCreation contestant) 
        {
            if (!ModelState.IsValid || contestant == null)
                return BadRequest();

            var contestantToAdd = mapper.Map<Contestant>(contestant);

            await contestantService.AddContestantAsync(contestantToAdd);
            if (!await contestantService.SaveChanges())
                return StatusCode(500, "Fault while saving...");

            var contestantForDisplay = mapper.Map<ContestantForDisplay>(contestantToAdd);
            return Ok(contestantForDisplay);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var contestant = await contestantService.GetContestantsByIdAsync(id); 
            if (contestant == null)
                return BadRequest();
            await contestantService.DeleteContestantAsync(contestant);
            if (!await contestantService.SaveChanges())
                return StatusCode(500, "Fault while saving...");
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ContestantForUpdate contestant)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var originContestant = await contestantService.GetContestantsByIdAsync(id);
            if (originContestant == null)
                return BadRequest();

            Mapper.Map(originContestant, contestant);
            if (!await contestantService.SaveChanges())
                return StatusCode(500, "Fault while saving...");
            var contestantForDisplay = mapper.Map<ContestantForDisplay>(originContestant);

            return Ok(contestantForDisplay);
        }
    }
}