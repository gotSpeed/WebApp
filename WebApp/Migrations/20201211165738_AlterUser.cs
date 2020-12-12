using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class AlterUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondName",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SecondName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Petitions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExpirationDate", "PublicationDate" },
                values: new object[] { new DateTime(2020, 12, 11, 14, 31, 3, 135, DateTimeKind.Utc).AddTicks(1638), new DateTime(2020, 12, 11, 14, 31, 3, 135, DateTimeKind.Utc).AddTicks(814) });

            migrationBuilder.UpdateData(
                table: "Polls",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicationDate",
                value: new DateTime(2020, 12, 11, 14, 31, 3, 135, DateTimeKind.Utc).AddTicks(3206));
        }
    }
}
