using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DataAccessLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Attempt> Attempts { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<ContestandCompetition> ContestandCompetitions { get; set; }
        public DbSet<Contestant> Contestants { get; set; }

    }
}
