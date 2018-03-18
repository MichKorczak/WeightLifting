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

        Task<List<Contestant>> GetContestantsByName(string lastName);

        Task AddContestant(Contestant contestant);

        Task DeleteContestant(Guid id);

        Task UpdateContestant(Guid id, [FromBody] Contestant contestant);
    }
}
