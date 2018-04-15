using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;

namespace Services.Services.Interfaces
{
    public interface IContestantService
    {
        Task<List<Contestant>> GetContestantsAsync(); 

        Task<Contestant> GetContestantsByIdAsync(Guid contestantId);

        Task<List<Contestant>> GetContestantsByNameAsync(string lastName);

        Task AddContestantAsync(Contestant contestant);  

        Task<int> DeleteContestantAsync(Contestant contestant);

        Task<bool> SaveChanges(); 
    }
}