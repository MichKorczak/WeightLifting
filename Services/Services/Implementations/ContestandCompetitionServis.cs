using Data.DataAccessLayer;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Implementations
{
    public class ContestandCompetitionServis : IContestandCompetition
    {
        private readonly ApplicationDbContext dbContext;

        public ContestandCompetitionServis(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddConstestandCompetition(ContestandCompetition contestandCompetition)
        {
            await dbContext.ContestandCompetitions.AddAsync(contestandCompetition);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<ContestandCompetition>> GetContestandCompetition()
        {
            var contestandComptetition = await dbContext.ContestandCompetitions.ToListAsync();
            return contestandComptetition;
        }
    }
}
