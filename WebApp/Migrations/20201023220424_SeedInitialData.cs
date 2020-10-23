using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;


namespace WebApp.Migrations {

	public partial class SeedInitialData : Migration {

		protected override void Up(MigrationBuilder migrationBuilder) {
			//migrationBuilder.AlterColumn<long>(
			//    name: "Id",
			//    table: "Users",
			//    nullable: false,
			//    oldClrType: typeof(long),
			//    oldType: "bigint")
			//    .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

			//migrationBuilder.AlterColumn<long>(
			//    name: "Id",
			//    table: "Polls",
			//    nullable: false,
			//    oldClrType: typeof(long),
			//    oldType: "bigint")
			//    .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

			//migrationBuilder.AlterColumn<long>(
			//    name: "Id",
			//    table: "Petitions",
			//    nullable: false,
			//    oldClrType: typeof(long),
			//    oldType: "bigint")
			//    .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

			//migrationBuilder.AlterColumn<long>(
			//    name: "Id",
			//    table: "Options",
			//    nullable: false,
			//    oldClrType: typeof(long),
			//    oldType: "bigint")
			//    .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

			migrationBuilder.InsertData(
				table: "Options",
				columns: new[] { "Id", "Content", "VotersAmount", "VotersId" },
				values: new object[,]
				{
					{ 1L, "1", 2L, null },
					{ 2L, "2", 3L, null }
				});

			migrationBuilder.InsertData(
				table: "Users",
				columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
				values: new object[,]
				{
					{ 1L, 0, null, "testuser@mail.ru", false, false, null, null, null, null, null, false, null, false, "testUser" },
					{ 2L, 0, null, "testuser1@mail.ru", false, false, null, null, null, null, null, false, null, false, "testUser1" },
					{ 3L, 0, null, "testuser2@mail.ru", false, false, null, null, null, null, null, false, null, false, "testUser2" }
				});

			migrationBuilder.InsertData(
				table: "Petitions",
				columns: new[] { "Id", "AuthorId", "Description", "ExpirationDate", "Header", "NextGoal", "PublicationDate", "ShortDescription", "TotalGoal", "VotersAmount", "VotersId" },
				values: new object[] { 1L, 1L, "Lorem ipsum dolor sit amet, consectetur adipiscing elit,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Eu nislnunc mi ipsum faucibus vitae aliquet nec.", new DateTime(2020, 10, 23, 22, 4, 24, 277, DateTimeKind.Utc).AddTicks(3751), "TestPetition", 100L, new DateTime(2020, 10, 23, 22, 4, 24, 277, DateTimeKind.Utc).AddTicks(3290), "ShortDescription", 20000L, 15L, null });

			migrationBuilder.InsertData(
				table: "Polls",
				columns: new[] { "Id", "AuthorId", "Description", "Header", "IsAnonymous", "OptionsId", "PublicationDate", "ShortDescription", "VotersAmount", "VotersId" },
				values: new object[] { 1L, 1L, "Lorem ipsum dolor sit amet, consectetur adipiscing elit,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Eu nislnunc mi ipsum faucibus vitae aliquet nec.", "TestPetition", false, null, new DateTime(2020, 10, 23, 22, 4, 24, 277, DateTimeKind.Utc).AddTicks(4619), "ShortDescription", 15L, null });
		}

		protected override void Down(MigrationBuilder migrationBuilder) {
			migrationBuilder.DeleteData(
				table: "Options",
				keyColumn: "Id",
				keyValue: 1L);

			migrationBuilder.DeleteData(
				table: "Options",
				keyColumn: "Id",
				keyValue: 2L);

			migrationBuilder.DeleteData(
				table: "Petitions",
				keyColumn: "Id",
				keyValue: 1L);

			migrationBuilder.DeleteData(
				table: "Polls",
				keyColumn: "Id",
				keyValue: 1L);

			migrationBuilder.DeleteData(
				table: "Users",
				keyColumn: "Id",
				keyValue: 2L);

			migrationBuilder.DeleteData(
				table: "Users",
				keyColumn: "Id",
				keyValue: 3L);

			migrationBuilder.DeleteData(
				table: "Users",
				keyColumn: "Id",
				keyValue: 1L);

			migrationBuilder.AlterColumn<long>(
				name: "Id",
				table: "Users",
				type: "bigint",
				nullable: false,
				oldClrType: typeof(long))
				.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

			//migrationBuilder.AlterColumn<long>(
			//    name: "Id",
			//    table: "Polls",
			//    type: "bigint",
			//    nullable: false,
			//    oldClrType: typeof(long))
			//    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

			//migrationBuilder.AlterColumn<long>(
			//    name: "Id",
			//    table: "Petitions",
			//    type: "bigint",
			//    nullable: false,
			//    oldClrType: typeof(long))
			//    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

			//migrationBuilder.AlterColumn<long>(
			//    name: "Id",
			//    table: "Options",
			//    type: "bigint",
			//    nullable: false,
			//    oldClrType: typeof(long))
			//    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
		}

	}

}
