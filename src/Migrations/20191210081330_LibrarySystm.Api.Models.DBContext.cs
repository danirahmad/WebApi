using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibrarySystm.Api.Migrations
{
    public partial class LibrarySystmApiModelsDBContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id_books", "Created", "Id_authors", "Name", "Year" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, "Java", "2019" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id_books", "Created", "Id_authors", "Name", "Year" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 2, "asp.NET", "2019" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id_books",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id_books",
                keyValue: 2);
        }
    }
}
