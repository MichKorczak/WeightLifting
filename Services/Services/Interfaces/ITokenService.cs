using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Data.DataTransferObject;
using Data.Models;

namespace Services.Services.Interfaces
{
    public interface ITokenService
    {
        JwtSecurityToken CreateToken(UserForLogin login);
    }
}
