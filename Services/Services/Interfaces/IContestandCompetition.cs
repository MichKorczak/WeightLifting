using Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Services.Interfaces
{
    public interface IContestandCompetition
    {
        Task<List<ContestandCompetition>> GetContestandCompetition();

        Task AddConstestandCompetition(ContestandCompetition contestandCompetition);
    }
}
