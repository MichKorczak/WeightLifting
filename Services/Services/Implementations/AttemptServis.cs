using Services.Services.Interfaces;
using System.Collections.Generic;
using Data.Models;
using System.Threading.Tasks;
using Data.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using AutoMapper;

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
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAttempt(Attempt attempt)
        {
            dbContext.Attempts.Remove(attempt);
            return await dbContext.SaveChangesAsync();
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

        public async Task<int> UpdateAttempt(Attempt originAttempt, Attempt attempt)
        {
            Mapper.Map(attempt, originAttempt);

            dbContext.Attempts.Update(originAttempt);
            return await dbContext.SaveChangesAsync();
        }
    }
}
