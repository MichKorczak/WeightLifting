using System.Security.Cryptography;
using System.Threading.Tasks;
using AutoMapper;
using Data.DataTransferObject;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Implementations;
using Services.Services.Interfaces;

namespace WeightLifting.Controllers 
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly IUserServis userServis;
        private readonly IMapper mapper;

        public UserController(IMapper mapper, IUserServis userServis)
        {
            this.mapper = mapper;
            this.userServis = userServis;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserForRegister register)
        {
            if (!ModelState.IsValid || register == null)
                return BadRequest();

            byte[] salt = new byte[128/8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            var hashPassword = HashServis.PasswordHash(register.Password, salt);

            register.Salt = salt;
            register.Password = hashPassword;

            var userToAdd = mapper.Map<User>(register);

            if (await userServis.AddUserAsync(userToAdd))
            {
                if (!await userServis.SaveChanges())
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
            var loginAnswear = await userServis.LoginAsync(login);
            if (loginAnswear == null)
                return BadRequest();
            var loginForDisplay = mapper.Map<UserForDisplay>(loginAnswear);
            return Ok(loginForDisplay);
        }
    }
}
