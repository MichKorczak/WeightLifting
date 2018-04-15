using System.Threading.Tasks;
using Data.DataTransferObject;
using Data.Models;

namespace Services.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> AddUserAsync(User user);

        Task<User> LoginAsync(UserForLogin login);

        Task<bool> SaveChanges();
    }
}