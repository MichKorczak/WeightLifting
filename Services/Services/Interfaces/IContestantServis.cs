using Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Services.Interfaces
{
    public interface IContestantServis
    {
        Task<List<Contestant>> GetContestans();

        Task AddContestant(Contestant contestant);
    }
}
