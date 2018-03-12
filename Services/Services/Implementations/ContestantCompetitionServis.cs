using Data.DataAccessLayer;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Services.Services.Interfaces;
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

        public async Task AddConstestandCompetition(ContestantCompetition contestantCompetition)
        {
            await dbContext.ContestantCompetitions.AddAsync(contestantCompetition);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<ContestantCompetition>> GetContestantCompetition()
        {
            var contestandComptetition = await dbContext.ContestantCompetitions.ToListAsync();
            return contestandComptetition;
        }
    }
}
