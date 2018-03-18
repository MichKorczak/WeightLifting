using Data.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Services.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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

        public async Task DeleteContestant(Guid id)
        {
            var contestants = await dbContext.Contestants.FirstOrDefaultAsync(t => t.Id == id);
            dbContext.Contestants.Remove(contestants);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Contestant>> GetContestants()
        {
            var contestants = await dbContext.Contestants.ToListAsync();
            return contestants;
        }

        public async Task<List<Contestant>> GetContestantsByName(string Name)
        {
            var contestants = await dbContext.Contestants.Where(t => $"{t.LastName}{t.FirstName}" == Name).ToListAsync();
            return contestants;
        }

        public async Task UpdateContestant(Guid id, [FromBody] Contestant contestant)
        {
            var originContestant = await dbContext.Contestants.FirstOrDefaultAsync(t => t.Id == id);

            originContestant.FirstName = contestant.FirstName;
            originContestant.LastName = contestant.LastName;
            originContestant.DateOfBirthday = contestant.DateOfBirthday;
            originContestant.Sex = contestant.Sex;

            dbContext.Contestants.Update(originContestant);
            await dbContext.SaveChangesAsync();
        }
    } 
}

