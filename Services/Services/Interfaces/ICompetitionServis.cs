using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;

namespace Services.Services.Interfaces
{
    public interface ICompetitionServis
    {
        Task<List<Competition>> GetCompetitionAsync();

        Task<Competition> GetCompetitionByIdAsync(Guid competitionId);

        Task<List<Competition>> GetCompetitionByNameAsync(string name);

        Task AddCompetitionAsync(Competition competition);

        Task<int> DeleteCompetitionAsync(Competition competition);

        Task<bool> SaveChanges();
    }
}