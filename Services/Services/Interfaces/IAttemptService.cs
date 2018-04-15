using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;

namespace Services.Services.Interfaces
{
    public interface IAttemptService
    {
        Task<List<Attempt>> GetAttemptsAsync(); 

        Task<Attempt> GetAttemptByIdAsync(Guid attemptId); 

        Task AddAttemptAsync(Attempt attempt);

        Task<int> DeleteAttemptAsync(Attempt attempt);

        Task<bool> SaveChanges();
    }
}