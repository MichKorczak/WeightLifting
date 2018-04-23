using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;

namespace Services.Services.Interfaces
{
    public interface IAttemptServis
    {
        Task<List<Attempt>> GetAttempt(); // powinno by getAttempts bo pobierasz liste
        Task<Attempt> GetAttemptById(Guid attemptId); // tu ewentualnie mogło by pozostac get Attemp ale by Id jest jak najbardziej OK
        // ale brakuje async dla Asyncronicznych
        Task<int> AddAttempt(Attempt attempt);

        Task<int> DeleteAttempt(Attempt attempt);

        Task<bool> SaveChangesContestantAsync();
    }
}