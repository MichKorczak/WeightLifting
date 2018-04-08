using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Competitions",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Competitions", x => x.Id); });

            migrationBuilder.CreateTable(
                "Contestants",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateOfBirthday = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Sex = table.Column<int>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Contestants", x => x.Id); });

            migrationBuilder.CreateTable(
                "Attempts",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompetitionId = table.Column<Guid>(nullable: false),
                    Correct = table.Column<bool>(nullable: false),
                    NameOfAttempt = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attempts", x => x.Id);
                    table.ForeignKey(
                        "FK_Attempts_Competitions_CompetitionId",
                        x => x.CompetitionId,
                        "Competitions",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ContestantCompetitions",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Club = table.Column<string>(nullable: true),
                    CompetitionId = table.Column<Guid>(nullable: false),
                    ContestandId = table.Column<Guid>(nullable: false),
                    Sincler = table.Column<decimal>(nullable: false),
                    Weight = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestantCompetitions", x => x.Id);
                    table.ForeignKey(
                        "FK_ContestantCompetitions_Competitions_CompetitionId",
                        x => x.CompetitionId,
                        "Competitions",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_ContestantCompetitions_Contestants_ContestandId",
                        x => x.ContestandId,
                        "Contestants",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_Attempts_CompetitionId",
                "Attempts",
                "CompetitionId");

            migrationBuilder.CreateIndex(
                "IX_ContestantCompetitions_CompetitionId",
                "ContestantCompetitions",
                "CompetitionId");

            migrationBuilder.CreateIndex(
                "IX_ContestantCompetitions_ContestandId",
                "ContestantCompetitions",
                "ContestandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Attempts");

            migrationBuilder.DropTable(
                "ContestantCompetitions");

            migrationBuilder.DropTable(
                "Competitions");

            migrationBuilder.DropTable(
                "Contestants");
        }
    }
}