using Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Services.Interfaces
{
    public interface IAttemptServis
    {
        Task<List<Attempt>> GetAttempt();

        Task AddAttempt(Attempt attempt);
    }
}
