using Data.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Services.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;
using System;
using System.Linq;
using AutoMapper;


namespace Services.Services.Implementations
{
    public class ContestantServis : IContestantServis
    {
        private readonly ApplicationDbContext dbContext;
        private readonly Mapper mapper;

        public ContestantServis(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<int> AddContestant(Contestant contestant)
        {
            await dbContext.Contestants.AddAsync(contestant);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteContestant(Contestant contestant)
        {
            dbContext.Contestants.Remove(contestant);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<List<Contestant>> GetContestants()
        {
            var contestants = await dbContext.Contestants.ToListAsync();
            return contestants;
        }

        public async Task<Contestant> GetContestantsById(Guid contestantId)
        {
            var contestants = await dbContext.Contestants.FirstOrDefaultAsync(t => t.Id == contestantId);
            return contestants;
        }

        public async Task<List<Contestant>> GetContestantsByName(string name)
        {
            var contestants = await dbContext.Contestants.Where(t => $"{t.LastName}{" "}{t.FirstName}" == name).ToListAsync();
            return contestants;
        }

        public async Task<int> UpdateContestant(Contestant originContestant, Contestant contestant)
        {
            mapper.DefaultContext(originContestant = contestant);

            dbContext.Contestants.Update(originContestant);
            return await dbContext.SaveChangesAsync();
        }
    } 
}

