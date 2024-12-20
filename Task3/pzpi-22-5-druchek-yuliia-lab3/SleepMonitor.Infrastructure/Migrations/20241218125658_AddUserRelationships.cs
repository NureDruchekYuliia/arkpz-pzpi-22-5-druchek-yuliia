using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SleepMonitor.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "SleepRecords",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "IoTData",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_SleepRecords_UserId",
                table: "SleepRecords",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_IoTData_UserId",
                table: "IoTData",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_IoTData_AspNetUsers_UserId",
                table: "IoTData",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SleepRecords_AspNetUsers_UserId",
                table: "SleepRecords",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IoTData_AspNetUsers_UserId",
                table: "IoTData");

            migrationBuilder.DropForeignKey(
                name: "FK_SleepRecords_AspNetUsers_UserId",
                table: "SleepRecords");

            migrationBuilder.DropIndex(
                name: "IX_SleepRecords_UserId",
                table: "SleepRecords");

            migrationBuilder.DropIndex(
                name: "IX_IoTData_UserId",
                table: "IoTData");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SleepRecords");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "IoTData");
        }
    }
}
