using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Data.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Services.Interfaces;

namespace Services.Services.Implementations
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration configuration;

        public TokenService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public TokenModel CreateToken(User user)
        {
            var claimsdata = new[] {new Claim(ClaimTypes.Name, user.Email)};
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Tokens:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenKey = new JwtSecurityToken(
                issuer: configuration["Tokens:Issuer"],
                audience: configuration["Tokens:Issuer"],
                expires: DateTime.Now.AddMinutes(30),
                claims: claimsdata,
                signingCredentials: credentials);

            var resoultToken = new TokenModel
            {
                Token = new JwtSecurityTokenHandler().WriteToken(tokenKey), 
                Email = user.Email,
                UserId = user.Id.ToString()
            };

            return resoultToken;
        }


    }
}
