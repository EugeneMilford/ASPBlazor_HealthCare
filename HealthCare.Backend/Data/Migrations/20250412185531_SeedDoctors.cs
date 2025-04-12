using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HealthCare.Backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDoctors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorId", "Name" },
                values: new object[,]
                {
                    { 1, "Dr. Smith" },
                    { 2, "Dr. Johnson" },
                    { 3, "Dr. Williams" },
                    { 4, "Dr. Brown" },
                    { 5, "Dr. Davis" }
                });

            migrationBuilder.InsertData(
                table: "Statusses",
                columns: new[] { "StatusId", "CurrentStatus" },
                values: new object[,]
                {
                    { 1, "Scheduled" },
                    { 2, "Confirmed" },
                    { 3, "Completed" },
                    { 4, "Cancelled" },
                    { 5, "No-Show" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Statusses",
                keyColumn: "StatusId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Statusses",
                keyColumn: "StatusId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Statusses",
                keyColumn: "StatusId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Statusses",
                keyColumn: "StatusId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Statusses",
                keyColumn: "StatusId",
                keyValue: 5);
        }
    }
}
