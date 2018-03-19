using Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Services.Interfaces
{
    public interface IContestantCompetitionServis
    {
        Task<List<ContestantCompetition>> GetContestantCompetition();

        Task<ContestantCompetition> GetContestantCompetitionById(Guid contestantCompetitionId);

        Task<int> AddConstestandCompetition(ContestantCompetition contestandCompetition);

        Task<int> DeleteContestantCompetition(ContestantCompetition contestandCompetition);

        Task<int> UpdateContestantCompetition(ContestantCompetition originContestantCompetition, ContestantCompetition contestantCompetition);
    }
}
