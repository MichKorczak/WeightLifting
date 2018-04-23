using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.DataAccessLayer;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Services.Services.Interfaces;

namespace Services.Services.Implementations
{
    public class AttemptServis : IAttemptServis
    {
        private readonly ApplicationDbContext dbContext;

        public AttemptServis(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> AddAttempt(Attempt attempt)
        {
            await dbContext.Attempts.AddAsync(attempt);
            return await dbContext.SaveChangesAsync(); // nie powinno tu byc zapisywania tylko uzywac metody save Changes
        }

        public async Task<int> DeleteAttempt(Attempt attempt)
        {
            dbContext.Attempts.Remove(attempt);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<bool> SaveChangesContestantAsync() // czemu SaveChangesContestantAsync ? :D samo SaveChanges
        {
            return await dbContext.SaveChangesAsync() >= 0;
        }

        public async Task<List<Attempt>> GetAttempt()
        {
            var attempts = await dbContext.Attempts.ToListAsync();
            return attempts;
        }

        public async Task<Attempt> GetAttemptById(Guid attemptId)
        {
            var attempts = await dbContext.Attempts.FirstOrDefaultAsync(t => t.Id == attemptId);
            return attempts;
        }
    }
}