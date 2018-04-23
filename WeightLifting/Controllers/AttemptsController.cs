﻿using System;
using System.Threading.Tasks;
using AutoMapper;
using Data.DataTransferObject;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Interfaces;

namespace WeightLifting.Controllers
{
    [Produces("application/json")]
    [Route("api/Attempts")]
    public class AttemptsController : Controller
    {
        private readonly IAttemptServis attemptServis;
        private readonly IMapper mapper;

        public AttemptsController(IMapper mapper, IAttemptServis attemptServis)
        {
            this.mapper = mapper;
            this.attemptServis = attemptServis;
        }

        [HttpGet]
        public async Task<IActionResult> GetAttempt()
        {
            var attempt = await attemptServis.GetAttempt();
            //brak mapowania
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
                return StatusCode(500, "Fault while saving...");
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
                return StatusCode(500, "Fault while saving...");
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAttempt(Guid id, [FromBody] AttemptForUpdate attempt)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var originAttempt = attemptServis.GetAttemptById(id).Result;
            if (originAttempt == null)
                return BadRequest();
            Mapper.Map(originAttempt, attempt);

            if (!await attemptServis.SaveChangesContestantAsync())
                return StatusCode(500, "Fault while saving...");
            var attemptForDisplay = mapper.Map<AttemptForDisplay>(originAttempt);

            return Ok(attemptForDisplay);
        }
    }
}