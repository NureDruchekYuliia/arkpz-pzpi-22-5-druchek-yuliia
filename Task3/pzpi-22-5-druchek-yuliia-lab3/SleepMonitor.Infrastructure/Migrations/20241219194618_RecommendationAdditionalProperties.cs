using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SleepMonitor.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RecommendationAdditionalProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Comparison",
                table: "Recommendations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Property",
                table: "Recommendations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Value",
                table: "Recommendations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comparison",
                table: "Recommendations");

            migrationBuilder.DropColumn(
                name: "Property",
                table: "Recommendations");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Recommendations");
        }
    }
}
