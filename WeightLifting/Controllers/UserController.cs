using System.Threading.Tasks;
using AutoMapper;
using Data.DataTransferObject;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserForRegister register)
        {
            if (!ModelState.IsValid || register == null)
                return BadRequest();

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

        [HttpPost]
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

        [HttpGet]
        public string Test()
        {
            string cos = "dziala";
            return cos;
        }
    }
}
