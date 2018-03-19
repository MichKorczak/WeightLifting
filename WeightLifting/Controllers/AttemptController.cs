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
    [Route("api/Attempt")]
    public class AttemptController : Controller
    {
        private readonly IMapper mapper;
        private readonly IAttemptServis attemptServis;

        public AttemptController(IMapper mapper, IAttemptServis attemptServis)
        {
            this.mapper = mapper;
            this.attemptServis = attemptServis;
        }

        [HttpGet]
        public async Task<IActionResult> GetAttempt()
        {
            var attempt = await attemptServis.GetAttempt();
            return Ok(attempt);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AttemptForCreation attempt)
        {
            if (!ModelState.IsValid || attempt == null)
                return BadRequest();

            var attemptToAdd = mapper.Map<Attempt>(attempt);
            var value = await attemptServis.AddAttempt(attemptToAdd);
            if (value <= 0)
            {
                return StatusCode(500, "Wystąpił bład w zapisie");
            }
            var attemptForDisplay = mapper.Map<ContestantForDisplay>(attemptToAdd);
            return Ok(attemptForDisplay);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttempt(Guid id)
        {
            var attempt = attemptServis.GetAttemptById(id).Result;
            if (attempt == null)
                return BadRequest();
            var value = await attemptServis.DeleteAttempt(attempt);
            if (value <= 0)
            {
                return StatusCode(500, "Wystąpił bład w zapisie");
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAttempt(Guid id, [FromBody] Attempt attempt)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var originAttempt = attemptServis.GetAttemptById(id).Result;
            if (originAttempt == null)
                return BadRequest();
            var value = await attemptServis.UpdateAttempt(originAttempt, attempt);
            if (value <= 0)
            {
                return StatusCode(500, "Wystąpił bład w zapisie");
            }
            var attemptForDisplay = mapper.Map<AttemptForDisplay>(originAttempt);

            return Ok(attemptForDisplay);
        }

    }
}