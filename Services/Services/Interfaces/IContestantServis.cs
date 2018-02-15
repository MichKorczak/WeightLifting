using Data.DataTransferObject;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interfaces
{
    public interface IContestantServis
    {
        Task<List<Contestant>> GetContestans();

        Task AddContestant(Contestant contestant);
    }
}
