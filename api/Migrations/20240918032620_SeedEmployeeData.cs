using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class SeedEmployeeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Phone", "Position" },
                values: new object[,]
                {
                    { 1, "email1@example.com", "FirstName1", "LastName1", "123-456-7801", "Position1" },
                    { 2, "email2@example.com", "FirstName2", "LastName2", "123-456-7802", "Position2" },
                    { 3, "email3@example.com", "FirstName3", "LastName3", "123-456-7803", "Position3" },
                    { 4, "email4@example.com", "FirstName4", "LastName4", "123-456-7804", "Position4" },
                    { 5, "email5@example.com", "FirstName5", "LastName5", "123-456-7805", "Position5" },
                    { 6, "email6@example.com", "FirstName6", "LastName6", "123-456-7806", "Position6" },
                    { 7, "email7@example.com", "FirstName7", "LastName7", "123-456-7807", "Position7" },
                    { 8, "email8@example.com", "FirstName8", "LastName8", "123-456-7808", "Position8" },
                    { 9, "email9@example.com", "FirstName9", "LastName9", "123-456-7809", "Position9" },
                    { 10, "email10@example.com", "FirstName10", "LastName10", "123-456-7810", "Position10" },
                    { 11, "email11@example.com", "FirstName11", "LastName11", "123-456-7811", "Position11" },
                    { 12, "email12@example.com", "FirstName12", "LastName12", "123-456-7812", "Position12" },
                    { 13, "email13@example.com", "FirstName13", "LastName13", "123-456-7813", "Position13" },
                    { 14, "email14@example.com", "FirstName14", "LastName14", "123-456-7814", "Position14" },
                    { 15, "email15@example.com", "FirstName15", "LastName15", "123-456-7815", "Position15" },
                    { 16, "email16@example.com", "FirstName16", "LastName16", "123-456-7816", "Position16" },
                    { 17, "email17@example.com", "FirstName17", "LastName17", "123-456-7817", "Position17" },
                    { 18, "email18@example.com", "FirstName18", "LastName18", "123-456-7818", "Position18" },
                    { 19, "email19@example.com", "FirstName19", "LastName19", "123-456-7819", "Position19" },
                    { 20, "email20@example.com", "FirstName20", "LastName20", "123-456-7820", "Position20" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
