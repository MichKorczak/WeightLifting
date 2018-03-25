using Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Services.Interfaces
{
    public interface IAttemptServis
    {
        Task<List<Attempt>> GetAttempt();

        Task<Attempt> GetAttemptById(Guid attemptId);

        Task<int> AddAttempt(Attempt attempt);

        Task<int> DeleteAttempt(Attempt attempt);

        Task<bool> SaveChangesContestantAsync();
    }
}
