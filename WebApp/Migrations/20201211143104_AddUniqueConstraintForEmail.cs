using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class AddUniqueConstraintForEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AspNetUsers_Email",
                table: "AspNetUsers",
                column: "Email");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_AspNetUsers_Email",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);

            migrationBuilder.UpdateData(
                table: "Petitions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExpirationDate", "PublicationDate" },
                values: new object[] { new DateTime(2020, 12, 10, 22, 5, 57, 317, DateTimeKind.Utc).AddTicks(7617), new DateTime(2020, 12, 10, 22, 5, 57, 317, DateTimeKind.Utc).AddTicks(6392) });

            migrationBuilder.UpdateData(
                table: "Polls",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicationDate",
                value: new DateTime(2020, 12, 10, 22, 5, 57, 318, DateTimeKind.Utc).AddTicks(237));
        }
    }
}
