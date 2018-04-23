using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;

namespace Services.Services.Interfaces
{
    public interface IContestantServis
    {
        Task<List<Contestant>> GetContestants(); // nazwa powinna byc GetContestantsAsync bo to metoda asynchroniczna 
                                                 //i wtedy byś od razu wiedział ze trzeba dac await
                                                 // to sie odnosi do wszystkich metod nie tylko do tej jednej

        Task<Contestant> GetContestantsById(Guid contestantId);

        Task<List<Contestant>> GetContestantsByName(string lastName);

        Task AddContestant(Contestant contestant);  // tu nie powinienes zwaracac int tylko akurat void a save changes dawac w kontrolerze w tym przypadku
        // napisze ci ta metode zebys wiedział i reszte analogicznie

        Task<int> DeleteContestant(Contestant contestant);

        Task<bool> SaveChangesContestantAsync(); // tu jest git :D
    }
}