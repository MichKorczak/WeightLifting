using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interfaces
{
    public interface ICompetitionServis
    {
        Task<List<Competition>> GetCompetition();

        Task<Competition> GetCompetitionById(Guid competitionId);

        Task<List<Competition>> GetCompetitionByName(string name);

        Task<int> AddCompetition(Competition competition);

        Task<int> DeleteCompetition(Competition competition);

        Task<bool> SaveChangesCompetitionAsync();
    }
}
