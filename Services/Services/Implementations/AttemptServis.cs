using Services.Services.Interfaces;
using System.Collections.Generic;
using Data.Models;
using System.Threading.Tasks;
using Data.DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace Services.Services.Implementations
{
    public class AttemptServis : IAttemptServis
    {
        private readonly ApplicationDbContext dbContext;
        
        public AttemptServis(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddAttempt(Attempt attempt)
        {
            await dbContext.Attempts.AddAsync(attempt);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Attempt>> GetAttempt()
        {
            var attempt = await dbContext.Attempts.ToListAsync();
            return attempt;
        }
    }
}
