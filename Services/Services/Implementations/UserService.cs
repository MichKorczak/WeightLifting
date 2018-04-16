using System.Threading.Tasks;
using Data.DataAccessLayer;
using Data.DataTransferObject;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Services.Services.Interfaces;

namespace Services.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IHashService hashService;

        public UserService(ApplicationDbContext dbContext, IHashService hashService)
        {
            this.hashService = hashService;
            this.dbContext = dbContext;
        }

        public async Task<bool> AddUserAsync(User user)
        {
            var loginTest = await dbContext.Users.FirstOrDefaultAsync(t => t.Email == user.Email);
            if (loginTest != null)
                return false;

            user.Salt = hashService.CreatedSalt();
            user.Password = hashService.HashPassword(user.Password, user.Salt);

            await dbContext.Users.AddAsync(user);
            return true;

        }

        public async Task<User> LoginAsync(UserForLogin login)
        {
            var loginTask =await dbContext.Users.FirstOrDefaultAsync(t => t.Email == login.EmailAddress);
            if (loginTask == null)
                return null;
            login.Password = hashService.HashPassword(login.Password, loginTask.Salt);
            if (login.Password.Equals(loginTask.Password))
                return loginTask;
            return null;
        }

        public async Task<bool> SaveChanges()
        {
            return await dbContext.SaveChangesAsync() >= 0;
        }
    }
}
