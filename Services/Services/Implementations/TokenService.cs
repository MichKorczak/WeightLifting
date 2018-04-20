using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Data.DataTransferObject;
using Microsoft.IdentityModel.Tokens;
using Services.Services.Interfaces;

namespace Services.Services.Implementations
{
    public class TokenService : ITokenService
    {
        public JwtSecurityToken CreateToken(UserForLogin login)
        {
            var claimsdata = new[] {new Claim(ClaimTypes.Name, login.Email)};
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ajshkfsdhfasdfbasbmbzxv"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var tokenKey = new JwtSecurityToken(
                issuer: "cos",
                audience: "cos",
                expires: DateTime.Now.AddMinutes(1),
                claims: claimsdata,
                signingCredentials: credentials);

            return tokenKey;
        }
    }
}
