//using Data.DataAccessLayer;
//using Data.Models;
//using System;

//namespace Services.Provider
//{
//    public static class DBInitializeProvider
//    {
//        public static void Init(ApplicationDbContext dbContext)
//        {
//            dbContext.Database.EnsureDeleted();
//            dbContext.Database.EnsureCreated();

//            var competition = new Competition
//            {
//                Id = Guid.NewGuid(),
//                Date = DateTime.Now,
//                Name = "Polish Championship",
//            };

//            var attempt = new Attempt
//            {
//                Id = Guid.NewGuid(),
//                Competition = competition,
//                NameOfAttempt = Data.Enums.NameOfAttempt.Snach,
//                Weight = 150,
//                Correct = true,
//                CompetitionId = competition.Id
                
//            };

//            var contestant = new Contestant
//            {
//                Id = Guid.NewGuid(),
//                FirstName = "Jan",
//                LastName = "Kowalski",
//                DateOfBirthday = DateTime.Parse("1999-05-15"),
//                Sex = Data.Enums.Sex.Male
//            };

//            var contestantCompetition = new ContestantCompetition
//            {
//                Id = Guid.NewGuid(),
//                Club = "Lechia",
//                Weight = 90,
//                Sincler = 310,
//                Contestant = contestant,
//                ContestandId = contestant.Id,
//                Competition = competition,
//                CompetitionId = competition.Id,
//            };

//            dbContext.Attempts.Add(attempt);
//            dbContext.Contestants.Add(contestant);
//            dbContext.Competitions.Add(competition);
//            dbContext.ContestantCompetitions.Add(contestantCompetition);

//            dbContext.SaveChanges();
//        }
//    }
//}
