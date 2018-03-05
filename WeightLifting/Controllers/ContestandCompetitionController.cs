using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.DataTransferObject;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Interfaces;

namespace WeightLifting.Controllers
{
    [Produces("application/json")]
    [Route("api/ContestandCompetition")]
    public class ContestandCompetitionController : Controller
    {
        private readonly IMapper mapper;
        private readonly IContestandCompetition contestandCompetitionServis;

        public ContestandCompetitionController(IMapper mapper, IContestandCompetition contestandCompetition)
        {
            this.mapper = mapper;
            this.contestandCompetitionServis = contestandCompetition; 
        }

        [HttpGet]
        public async Task<IActionResult> GetContestandCompetition()
        {
            var contestandCompetition = await contestandCompetitionServis.GetContestandCompetition();
            return Ok(contestandCompetition);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ContestandCompetitionForCreation contestandCompetition)
        {
            if (!ModelState.IsValid || contestandCompetition == null)
                return BadRequest();

            var contestandCompetitionToAdd = mapper.Map<ContestandCompetition>(contestandCompetition);
            await contestandCompetitionServis.AddConstestandCompetition(contestandCompetitionToAdd);
            var contestandCompetitionForDisplay = mapper.Map<ContestandCompetitionForDisplay>(contestandCompetitionToAdd);
            return Ok(contestandCompetitionForDisplay);
        }
    }
}