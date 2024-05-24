using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobCandidate.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobCandidateDetails",
                columns: table => new
                {
                    Email = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    LinkedInProfileUrl = table.Column<string>(type: "text", nullable: true),
                    GithubProfileUrl = table.Column<string>(type: "text", nullable: true),
                    FreeTextComment = table.Column<string>(type: "text", nullable: false),
                    IntervalStartTime = table.Column<TimeSpan>(type: "interval", nullable: true),
                    IntervalEndTime = table.Column<TimeSpan>(type: "interval", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCandidateDetails", x => x.Email);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobCandidateDetails");
        }
    }
}
