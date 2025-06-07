using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PC4___CONTINUA.Migrations
{
    /// <inheritdoc />
    public partial class AddMlEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SentimentRecords",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    Prediction = table.Column<bool>(type: "INTEGER", nullable: false),
                    Probability = table.Column<float>(type: "REAL", nullable: false),
                    Score = table.Column<float>(type: "REAL", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SentimentRecords", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SentimentRecords");
        }
    }
}
