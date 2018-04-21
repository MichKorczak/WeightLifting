using Data.DataTransferObject;
using Data.Models;

namespace Services.Services.Interfaces
{
    public interface ITokenService
    {
        TokenModel CreateToken(User user);
    }
}
