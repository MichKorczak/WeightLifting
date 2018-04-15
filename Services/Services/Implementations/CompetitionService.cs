using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.DataAccessLayer;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Services.Services.Interfaces;

namespace Services.Services.Implementations
{
    public class CompetitionService : ICompetitionService
    {
        private readonly ApplicationDbContext dbContext;

        public CompetitionService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddCompetitionAsync(Competition competition)
        {
            await dbContext.Competitions.AddAsync(competition);
        }

        public async Task<int> DeleteCompetitionAsync(Competition competition)
        {
            dbContext.Competitions.Remove(competition);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<bool> SaveChanges()
        {
            return await dbContext.SaveChangesAsync() >= 0;
        }

        public async Task<List<Competition>> GetCompetitionAsync()
        {
            var competition = await dbContext.Competitions.ToListAsync();
            return competition;
        }

        public async Task<Competition> GetCompetitionByIdAsync(Guid competitionId)
        {
            var competition = await dbContext.Competitions.FirstOrDefaultAsync(t => t.Id == competitionId);
            return competition;
        }

        public async Task<List<Competition>> GetCompetitionByNameAsync(string name)
        {
            var competition = await dbContext.Competitions.Where(t => t.Name == name).ToListAsync();
            return competition;
        }
    }
}