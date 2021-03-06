﻿using System.Threading.Tasks;
using AutoMapper;
using Data.DataTransferObject;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Interfaces;

namespace WeightLifting.Controllers 
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private readonly IUserService userService;
        private readonly ITokenService tokenService;
        private readonly IMapper mapper;

        public UsersController(IMapper mapper, IUserService userServis, ITokenService tokenService)
        {
            this.mapper = mapper;
            this.tokenService = tokenService;
            this.userService = userServis;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserForRegister register)
        {
            if (!ModelState.IsValid || register == null)
                return BadRequest();

            var userToAdd = mapper.Map<User>(register);

            if (await userService.AddUserAsync(userToAdd))
            {
                if (!await userService.SaveChanges())
                    return StatusCode(500, "Fault while saving...");

                var userForDisplay = mapper.Map<UserForDisplay>(userToAdd);
                return Ok(userForDisplay);
            }

            return BadRequest();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForLogin login)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var loginAnswear = await userService.GetToken(login);
            if (loginAnswear == null)
                return BadRequest();
            return Ok(loginAnswear);
        }
    }
}
