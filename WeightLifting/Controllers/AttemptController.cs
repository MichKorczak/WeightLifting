using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Services.Services.Interfaces;
using Data.DataTransferObject;
using Data.Models;

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
            await attemptServis.AddAttempt(attemptToAdd);
            var attemptForDisplay = mapper.Map<ContestantForDisplay>(attemptToAdd);
            return Ok(attemptForDisplay);
        }


    }
}