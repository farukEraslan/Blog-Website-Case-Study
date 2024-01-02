using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogWebsite.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seedDataRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("5af5f45b-7682-479c-a6e5-7dd90e1915c5"), null, "Admin", null },
                    { new Guid("7d73ae79-440f-4c39-b863-e90c4bea3c7c"), null, "Author", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5af5f45b-7682-479c-a6e5-7dd90e1915c5"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7d73ae79-440f-4c39-b863-e90c4bea3c7c"));
        }
    }
}
