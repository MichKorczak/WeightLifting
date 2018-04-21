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
        private readonly ITokenService tokenService;

        public UserService(ApplicationDbContext dbContext, IHashService hashService, ITokenService tokenService)
        {
            this.tokenService = tokenService;
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

        public async Task<TokenModel> GetToken(UserForLogin login)
        {
            var loginTask =await dbContext.Users.FirstOrDefaultAsync(t => t.Email == login.Email);
            if (loginTask == null)
                return null;
            login.Password = hashService.HashPassword(login.Password, loginTask.Salt);
            if (login.Password.Equals(loginTask.Password))
                return tokenService.CreateToken(loginTask);
            return null;
        }

        public async Task<bool> SaveChanges()
        {
            return await dbContext.SaveChangesAsync() >= 0;
        }
    }
}
