using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;

namespace Services.Services.Interfaces
{
    public interface IContestantCompetitionService
    {
        Task<List<ContestantCompetition>> GetContestantCompetitionAsync();

        Task<ContestantCompetition> GetContestantCompetitionByIdAsync(Guid contestantCompetitionId);

        Task AddConstestandCompetitionAsync(ContestantCompetition contestandCompetition);

        Task<int> DeleteContestantCompetitionAsync(ContestantCompetition contestandCompetition);

        Task<bool> SaveChanges();
    }
}