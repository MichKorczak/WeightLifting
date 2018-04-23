using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;

namespace Services.Services.Interfaces
{
    public interface IContestantCompetitionServis
    {
        Task<List<ContestantCompetition>> GetContestantCompetition();

        Task<ContestantCompetition> GetContestantCompetitionById(Guid contestantCompetitionId);

        Task<int> AddConstestandCompetition(ContestantCompetition contestandCompetition);

        Task<int> DeleteContestantCompetition(ContestantCompetition contestandCompetition);

        Task<bool> SaveChangesContestanCompetitionAsync();
    }
}