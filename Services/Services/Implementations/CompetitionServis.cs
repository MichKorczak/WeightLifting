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
    public class CompetitionServis : ICompetitionServis
    {
        private readonly ApplicationDbContext dbContext;

        public CompetitionServis(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> AddCompetition(Competition competition)
        {
            await dbContext.Competitions.AddAsync(competition);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteCompetition(Competition competition)
        {
            dbContext.Competitions.Remove(competition);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<bool> SaveChangesCompetitionAsync()
        {
            return await dbContext.SaveChangesAsync() >= 0;
        }

        public async Task<List<Competition>> GetCompetition()
        {
            var competition = await dbContext.Competitions.ToListAsync();
            return competition;
        }

        public async Task<Competition> GetCompetitionById(Guid competitionId)
        {
            var competition = await dbContext.Competitions.FirstOrDefaultAsync(t => t.Id == competitionId);
            return competition;
        }

        public async Task<List<Competition>> GetCompetitionByName(string name)
        {
            var competition = await dbContext.Competitions.Where(t => t.Name == name).ToListAsync();
            return competition;
        }
    }
}