using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.DataAccessLayer;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Services.Services.Interfaces;

namespace Services.Services.Implementations
{
    public class AttemptService : IAttemptService
    {
        private readonly ApplicationDbContext dbContext;

        public AttemptService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAttemptAsync(Attempt attempt)
        {
            await dbContext.Attempts.AddAsync(attempt);

        }

        public async Task<int> DeleteAttemptAsync(Attempt attempt)
        {
            dbContext.Attempts.Remove(attempt);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<bool> SaveChanges()
        {
            return await dbContext.SaveChangesAsync() >= 0;
        }

        public async Task<List<Attempt>> GetAttemptsAsync()
        {
            var attempts = await dbContext.Attempts.ToListAsync();
            return attempts;
        }

        public async Task<Attempt> GetAttemptByIdAsync(Guid attemptId)
        {
            var attempts = await dbContext.Attempts.FirstOrDefaultAsync(t => t.Id == attemptId);
            return attempts;
        }
    }
}