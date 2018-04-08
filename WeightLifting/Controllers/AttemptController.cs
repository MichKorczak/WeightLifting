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
        public async Task<IActionResult> Get()
        {
            var attempt = mapper.Map<AttemptForDisplay>(await attemptServis.GetAttemptsAsync());
            return Ok(attempt);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AttemptForCreation attempt)
        {
            if (!ModelState.IsValid || attempt == null)
                return BadRequest();

            var attemptToAdd = mapper.Map<Attempt>(attempt);

            await attemptServis.AddAttemptAsync(attemptToAdd);
            if (!await attemptServis.SaveChanges())
                return StatusCode(500, "Fault while saving...");

            var attemptForDisplay = mapper.Map<ContestantForDisplay>(attemptToAdd);
            return Ok(attemptForDisplay);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var attempt = attemptServis.GetAttemptByIdAsync(id).Result;
            if (attempt == null)
                return BadRequest();
            await attemptServis.DeleteAttemptAsync(attempt);
            if (!await attemptServis.SaveChanges())
                return StatusCode(500, "Fault while saving...");
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Attempt attempt)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var originAttempt = attemptServis.GetAttemptByIdAsync(id);
            if (originAttempt == null)
                return BadRequest();

            mapper.Map(originAttempt, attempt);
            if (!await attemptServis.SaveChanges())
                return StatusCode(500, "Fault while saving...");
            var attemptForDisplay = mapper.Map<AttemptForDisplay>(originAttempt);

            return Ok(attemptForDisplay);
        }

    }
}