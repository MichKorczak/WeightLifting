using System;
using System.ComponentModel.Design;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper.Configuration;
using Data.DataAccessLayer;
using Data.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Services.Services.Interfaces;

namespace Services.Services.Implementations
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration Configuration;
        private readonly ApplicationDbContext dbContext;

        public TokenService(IConfiguration configuration, ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.Configuration= configuration;
        }

        public TokenModel CreateToken(User user)
        {
            var claimsdata = new[] {new Claim(ClaimTypes.Name, user.Email)};
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenKey = new JwtSecurityToken(
                issuer: Configuration["Tokens:Issuer"],
                audience: Configuration["Tokens:Issuer"],
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
