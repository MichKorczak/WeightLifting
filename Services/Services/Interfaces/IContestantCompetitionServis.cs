using Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Services.Interfaces
{
    public interface IContestantCompetitionServis
    {
        Task<List<ContestantCompetition>> GetContestantCompetition();

        Task AddConstestandCompetition(ContestantCompetition contestandCompetition);
    }
}
