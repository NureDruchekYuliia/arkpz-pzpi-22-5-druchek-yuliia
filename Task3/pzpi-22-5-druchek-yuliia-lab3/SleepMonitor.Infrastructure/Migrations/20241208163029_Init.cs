using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SleepMonitor.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IoTData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoiseLevel = table.Column<double>(type: "float", nullable: false),
                    LightLevel = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IoTData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recommendations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recommendations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SleepRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    SleepStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SleepEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quality = table.Column<int>(type: "int", nullable: false),
                    AvgNoiseLevel = table.Column<double>(type: "float", nullable: false),
                    AvgLightLevel = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SleepRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SleepRecord_Recommendations",
                columns: table => new
                {
                    SleepRecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecommendationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SleepRecord_Recommendations", x => new { x.SleepRecordId, x.RecommendationId });
                    table.ForeignKey(
                        name: "FK_SleepRecord_Recommendations_Recommendations_RecommendationId",
                        column: x => x.RecommendationId,
                        principalTable: "Recommendations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SleepRecord_Recommendations_SleepRecords_SleepRecordId",
                        column: x => x.SleepRecordId,
                        principalTable: "SleepRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SleepRecord_Recommendations_RecommendationId",
                table: "SleepRecord_Recommendations",
                column: "RecommendationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IoTData");

            migrationBuilder.DropTable(
                name: "SleepRecord_Recommendations");

            migrationBuilder.DropTable(
                name: "Recommendations");

            migrationBuilder.DropTable(
                name: "SleepRecords");
        }
    }
}
