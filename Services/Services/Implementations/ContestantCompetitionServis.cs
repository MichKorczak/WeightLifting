using AutoMapper;
using Data.DataAccessLayer;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Services.Implementations
{
    public class ContestantCompetitionServis : IContestantCompetitionServis
    {
        private readonly ApplicationDbContext dbContext;

        public ContestantCompetitionServis(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> AddConstestandCompetition(ContestantCompetition contestantCompetition)
        {
            await dbContext.ContestantCompetitions.AddAsync(contestantCompetition);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteContestantCompetition(ContestantCompetition contestandCompetition)
        {
            dbContext.ContestantCompetitions.Remove(contestandCompetition);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<bool> SaveChangesContestanCompetitionAsync()
        {
            return await dbContext.SaveChangesAsync() >= 0;
        }

        public async Task<List<ContestantCompetition>> GetContestantCompetition()
        {
            var contestandComptetition = await dbContext.ContestantCompetitions.ToListAsync();
            return contestandComptetition;
        }

        public async Task<ContestantCompetition> GetContestantCompetitionById(Guid contestantCompetitionId)
        {
            var contestantCompetition = await dbContext.ContestantCompetitions.FirstOrDefaultAsync(t => t.Id == contestantCompetitionId);
            return contestantCompetition;
        }
    }
}
