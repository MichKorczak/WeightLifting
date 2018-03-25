﻿// <auto-generated />
using Data.DataAccessLayer;
using Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180323203401_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Models.Attempt", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CompetitionId");

                    b.Property<bool>("Correct");

                    b.Property<int>("NameOfAttempt");

                    b.Property<int>("Weight");

                    b.HasKey("Id");

                    b.HasIndex("CompetitionId");

                    b.ToTable("Attempts");
                });

            modelBuilder.Entity("Data.Models.Competition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Competitions");
                });

            modelBuilder.Entity("Data.Models.Contestant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfBirthday");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int>("Sex");

                    b.HasKey("Id");

                    b.ToTable("Contestants");
                });

            modelBuilder.Entity("Data.Models.ContestantCompetition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Club");

                    b.Property<Guid>("CompetitionId");

                    b.Property<Guid>("ContestandId");

                    b.Property<decimal>("Sincler");

                    b.Property<decimal>("Weight");

                    b.HasKey("Id");

                    b.HasIndex("CompetitionId");

                    b.HasIndex("ContestandId");

                    b.ToTable("ContestantCompetitions");
                });

            modelBuilder.Entity("Data.Models.Attempt", b =>
                {
                    b.HasOne("Data.Models.Competition", "Competition")
                        .WithMany("Attempt")
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Models.ContestantCompetition", b =>
                {
                    b.HasOne("Data.Models.Competition", "Competition")
                        .WithMany("ContestantCompetition")
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Models.Contestant", "Contestant")
                        .WithMany("ContestantCompetition")
                        .HasForeignKey("ContestandId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
