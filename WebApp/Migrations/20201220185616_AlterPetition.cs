using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class AlterPetition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsClosed",
                table: "Petitions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Petitions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExpirationDate", "PublicationDate" },
                values: new object[] { new DateTime(2020, 12, 20, 18, 56, 15, 482, DateTimeKind.Utc).AddTicks(8195), new DateTime(2020, 12, 20, 18, 56, 15, 482, DateTimeKind.Utc).AddTicks(7728) });

            migrationBuilder.UpdateData(
                table: "Polls",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicationDate",
                value: new DateTime(2020, 12, 20, 18, 56, 15, 482, DateTimeKind.Utc).AddTicks(9166));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsClosed",
                table: "Petitions");

            migrationBuilder.UpdateData(
                table: "Petitions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExpirationDate", "PublicationDate" },
                values: new object[] { new DateTime(2020, 12, 11, 16, 57, 37, 754, DateTimeKind.Utc).AddTicks(3606), new DateTime(2020, 12, 11, 16, 57, 37, 754, DateTimeKind.Utc).AddTicks(3120) });

            migrationBuilder.UpdateData(
                table: "Polls",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicationDate",
                value: new DateTime(2020, 12, 11, 16, 57, 37, 754, DateTimeKind.Utc).AddTicks(4564));
        }
    }
}
