using System.Threading.Tasks;
using Data.DataTransferObject;
using Data.Models;

namespace Services.Services.Interfaces
{
    public interface IUserServis
    {
        Task<bool> AddUserAsync(User user);

        Task<User> LoginAsync(Login login);

        Task<bool> SaveChanges();
    }
}