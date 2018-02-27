using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interfaces
{
    public interface ICompetitionServis
    {
        Task<List<Competition>> GetCompetition();
        Task AddCompetition(Competition competition);
    }
}
