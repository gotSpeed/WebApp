using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class AddCoreAndSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, null, "testuser@mail.ru", false, false, null, null, null, null, null, false, null, false, "testUser" },
                    { 2, 0, null, "testuser1@mail.ru", false, false, null, null, null, null, null, false, null, false, "testUser1" },
                    { 3, 0, null, "testuser2@mail.ru", false, false, null, null, null, null, null, false, null, false, "testUser2" }
                });

            migrationBuilder.InsertData(
                table: "Petitions",
                columns: new[] { "Id", "AuthorId", "Description", "ExpirationDate", "Header", "NextGoal", "PublicationDate", "ShortDescription", "TotalGoal", "VotersAmount" },
                values: new object[] { 1, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Eu nislnunc mi ipsum faucibus vitae aliquet nec.", new DateTime(2020, 12, 7, 22, 44, 11, 122, DateTimeKind.Utc).AddTicks(1493), "TestPetition", 100L, new DateTime(2020, 12, 7, 22, 44, 11, 122, DateTimeKind.Utc).AddTicks(490), "ShortDescription", 20000L, 15L });

            migrationBuilder.InsertData(
                table: "Polls",
                columns: new[] { "Id", "AuthorId", "Description", "Header", "IsAnonymous", "PublicationDate", "ShortDescription", "VotersAmount" },
                values: new object[] { 1, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Eu nislnunc mi ipsum faucibus vitae aliquet nec.", "TestPetition", false, new DateTime(2020, 12, 7, 22, 44, 11, 122, DateTimeKind.Utc).AddTicks(3427), "ShortDescription", 15L });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "Content", "PollId", "VotersAmount" },
                values: new object[,]
                {
                    { 1, "1", 1, 3L },
                    { 2, "2", 1, 2L }
                });

            migrationBuilder.InsertData(
                table: "PetitionUser",
                columns: new[] { "UserId", "PetitionId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "VotingOptionUser",
                columns: new[] { "UserId", "VotingOptionId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 1, 2 },
                    { 2, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PetitionUser",
                keyColumns: new[] { "UserId", "PetitionId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PetitionUser",
                keyColumns: new[] { "UserId", "PetitionId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "PetitionUser",
                keyColumns: new[] { "UserId", "PetitionId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "VotingOptionUser",
                keyColumns: new[] { "UserId", "VotingOptionId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "VotingOptionUser",
                keyColumns: new[] { "UserId", "VotingOptionId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "VotingOptionUser",
                keyColumns: new[] { "UserId", "VotingOptionId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "VotingOptionUser",
                keyColumns: new[] { "UserId", "VotingOptionId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "VotingOptionUser",
                keyColumns: new[] { "UserId", "VotingOptionId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Petitions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Polls",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
