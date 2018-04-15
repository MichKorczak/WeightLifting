using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.DataAccessLayer;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Services.Services.Interfaces;

namespace Services.Services.Implementations
{
    public class ContestantCompetitionService : IContestantCompetitionService
    {
        private readonly ApplicationDbContext dbContext;

        public ContestantCompetitionService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddConstestandCompetitionAsync(ContestantCompetition contestantCompetition)
        {
            await dbContext.ContestantCompetitions.AddAsync(contestantCompetition);
        }

        public async Task<int> DeleteContestantCompetitionAsync(ContestantCompetition contestandCompetition)
        {
            dbContext.ContestantCompetitions.Remove(contestandCompetition);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<bool> SaveChanges()
        {
            return await dbContext.SaveChangesAsync() >= 0;
        }

        public async Task<List<ContestantCompetition>> GetContestantCompetitionAsync()
        {
            var contestandComptetition = await dbContext.ContestantCompetitions.ToListAsync();
            return contestandComptetition;
        }

        public async Task<ContestantCompetition> GetContestantCompetitionByIdAsync(Guid contestantCompetitionId)
        {
            var contestantCompetition = await dbContext.ContestantCompetitions.FirstOrDefaultAsync(t => t.Id == contestantCompetitionId);
            return contestantCompetition;
        }
    }
}