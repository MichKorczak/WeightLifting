using Services.Services.Interfaces;
using System.Collections.Generic;
using Data.Models;
using System.Threading.Tasks;
using Data.DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace Services.Services.Implementations
{
    public class CompetitionServis : ICompetitionServis
    {
        private readonly ApplicationDbContext dbContext;

        public CompetitionServis(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddCompetition(Competition competition)
        {
            await dbContext.Competitions.AddAsync(competition);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Competition>> GetCompetition()
        {
            var competition = await dbContext.Competitions.ToListAsync();
            return competition;
        }
    }
}
