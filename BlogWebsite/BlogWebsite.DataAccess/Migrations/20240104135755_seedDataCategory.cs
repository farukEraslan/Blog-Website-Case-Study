using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogWebsite.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seedDataCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5af5f45b-7682-479c-a6e5-7dd90e1915c5"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7d73ae79-440f-4c39-b863-e90c4bea3c7c"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0f3573b3-2846-40f4-8070-4bef5edccb11"), null, "Admin", null },
                    { new Guid("811261b9-01fd-4c44-a14d-1e2aecbcba3d"), null, "Author", null }
                });

            migrationBuilder.InsertData(
                table: "CategoryEntity",
                columns: new[] { "Id", "CategoryName", "CreatedDate", "ModifiedDate" },
                values: new object[,]
                {
                    { new Guid("37a6f3db-f9b3-4f19-9ec6-c2e1cc020ff7"), "Javascript", new DateTime(2024, 1, 4, 16, 57, 55, 34, DateTimeKind.Local).AddTicks(5903), new DateTime(2024, 1, 4, 16, 57, 55, 34, DateTimeKind.Local).AddTicks(5903) },
                    { new Guid("3bfa17da-4df1-4a5d-bacf-e91ca5d119a9"), "Phyton", new DateTime(2024, 1, 4, 16, 57, 55, 34, DateTimeKind.Local).AddTicks(5911), new DateTime(2024, 1, 4, 16, 57, 55, 34, DateTimeKind.Local).AddTicks(5912) },
                    { new Guid("71843361-06e1-4840-9314-2d165b4af1f7"), "C-Sharp", new DateTime(2024, 1, 4, 16, 57, 55, 34, DateTimeKind.Local).AddTicks(5859), new DateTime(2024, 1, 4, 16, 57, 55, 34, DateTimeKind.Local).AddTicks(5874) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0f3573b3-2846-40f4-8070-4bef5edccb11"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("811261b9-01fd-4c44-a14d-1e2aecbcba3d"));

            migrationBuilder.DeleteData(
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: new Guid("37a6f3db-f9b3-4f19-9ec6-c2e1cc020ff7"));

            migrationBuilder.DeleteData(
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: new Guid("3bfa17da-4df1-4a5d-bacf-e91ca5d119a9"));

            migrationBuilder.DeleteData(
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: new Guid("71843361-06e1-4840-9314-2d165b4af1f7"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("5af5f45b-7682-479c-a6e5-7dd90e1915c5"), null, "Admin", null },
                    { new Guid("7d73ae79-440f-4c39-b863-e90c4bea3c7c"), null, "Author", null }
                });
        }
    }
}
