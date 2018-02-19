using Data.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Services.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;

namespace Services.Services.Implementations
{
    public class ContestantServis : IContestantServis
    {
        private readonly ApplicationDbContext dbContext;

        public ContestantServis(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddContestant(Contestant contestant)
        {
            await dbContext.Contestants.AddAsync(contestant);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Contestant>> GetContestans()
        {
            var contestants = await dbContext.Contestants.ToListAsync();
            return contestants;
        }
    }
}
