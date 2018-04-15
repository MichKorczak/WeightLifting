using System.Threading.Tasks;
using Data.DataAccessLayer;
using Data.DataTransferObject;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Services.Services.Interfaces;

namespace Services.Services.Implementations
{
    public class UserServis : IUserServis
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IHashServis hashServis;

        public UserServis(ApplicationDbContext dbContext, IHashServis hashServis)
        {
            this.dbContext = dbContext;
            this.hashServis = hashServis;
        }

        public async Task<bool> AddUserAsync(User user)
        {
            var loginTest = await dbContext.Users.FirstOrDefaultAsync(t => t.Email == user.Email);
            if (loginTest != null)
                return false;

            user.Salt = hashServis.SaltCreated();
            user.Password = hashServis.PasswordHash(user.Password, user.Salt);

            await dbContext.Users.AddAsync(user);
            return true;

        }

        public async Task<User> LoginAsync(UserForLogin login)
        {
            var loginTask =await dbContext.Users.FirstOrDefaultAsync(t => t.Email == login.EmailAddress);
            if (loginTask == null)
                return null;
            login.Password = HashServis.PasswordHash(login.Password, loginTask.Salt);
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
