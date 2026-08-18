using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CtrlZJournal.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkEntries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    WorkDescription = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: false),
                    ProblemDescription = table.Column<string>(type: "TEXT", nullable: true),
                    SolutionDescription = table.Column<string>(type: "TEXT", nullable: true),
                    LearnedDescription = table.Column<string>(type: "TEXT", nullable: true),
                    WorkDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    DurationMinutes = table.Column<int>(type: "INTEGER", nullable: false),
                    Mood = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkEntries", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkEntries");
        }
    }
}
