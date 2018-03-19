using Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Services.Interfaces
{
    public interface IContestantServis
    {
        Task<List<Contestant>> GetContestants();

        Task<Contestant> GetContestantsById(Guid contestantId);

        Task<List<Contestant>> GetContestantsByName(string lastName);

        Task<int> AddContestant(Contestant contestant);

        Task<int> DeleteContestant(Contestant contestant);

        Task<int> UpdateContestant(Contestant originContestant, Contestant contestant);
    }
}
