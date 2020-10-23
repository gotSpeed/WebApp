using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;


namespace WebApp.Migrations {

	public partial class SetCoreData : Migration {

		protected override void Up(MigrationBuilder migrationBuilder) {
			migrationBuilder.CreateTable(
				name: "Options",
				columns: table => new {
					Id = table.Column<long>(nullable: false),
					Content = table.Column<string>(nullable: true),
					VotersAmount = table.Column<long>(nullable: false),
					VotersId = table.Column<List<uint>>(nullable: true)
				},
				constraints: table => {
					table.PrimaryKey("PK_Options", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Users",
				columns: table => new {
					Id = table.Column<long>(nullable: false),
					UserName = table.Column<string>(nullable: true),
					NormalizedUserName = table.Column<string>(nullable: true),
					Email = table.Column<string>(nullable: true),
					NormalizedEmail = table.Column<string>(nullable: true),
					EmailConfirmed = table.Column<bool>(nullable: false),
					PasswordHash = table.Column<string>(nullable: true),
					SecurityStamp = table.Column<string>(nullable: true),
					ConcurrencyStamp = table.Column<string>(nullable: true),
					PhoneNumber = table.Column<string>(nullable: true),
					PhoneNumberConfirmed = table.Column<bool>(nullable: false),
					TwoFactorEnabled = table.Column<bool>(nullable: false),
					LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
					LockoutEnabled = table.Column<bool>(nullable: false),
					AccessFailedCount = table.Column<int>(nullable: false)
				},
				constraints: table => {
					table.PrimaryKey("PK_Users", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Petitions",
				columns: table => new {
					Id = table.Column<long>(nullable: false),
					Header = table.Column<string>(nullable: true),
					ShortDescription = table.Column<string>(nullable: true),
					Description = table.Column<string>(nullable: true),
					PublicationDate = table.Column<DateTime>(nullable: false),
					AuthorId = table.Column<long>(nullable: true),
					VotersAmount = table.Column<long>(nullable: false),
					VotersId = table.Column<List<uint>>(nullable: true),
					ExpirationDate = table.Column<DateTime>(nullable: false),
					NextGoal = table.Column<long>(nullable: false),
					TotalGoal = table.Column<long>(nullable: false)
				},
				constraints: table => {
					table.PrimaryKey("PK_Petitions", x => x.Id);
					table.ForeignKey(
						name: "FK_Petitions_Users_AuthorId",
						column: x => x.AuthorId,
						principalTable: "Users",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Polls",
				columns: table => new {
					Id = table.Column<long>(nullable: false),
					Header = table.Column<string>(nullable: true),
					ShortDescription = table.Column<string>(nullable: true),
					Description = table.Column<string>(nullable: true),
					PublicationDate = table.Column<DateTime>(nullable: false),
					AuthorId = table.Column<long>(nullable: true),
					VotersAmount = table.Column<long>(nullable: false),
					VotersId = table.Column<List<uint>>(nullable: true),
					IsAnonymous = table.Column<bool>(nullable: false),
					OptionsId = table.Column<List<uint>>(nullable: true)
				},
				constraints: table => {
					table.PrimaryKey("PK_Polls", x => x.Id);
					table.ForeignKey(
						name: "FK_Polls_Users_AuthorId",
						column: x => x.AuthorId,
						principalTable: "Users",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Petitions_AuthorId",
				table: "Petitions",
				column: "AuthorId");

			migrationBuilder.CreateIndex(
				name: "IX_Polls_AuthorId",
				table: "Polls",
				column: "AuthorId");
		}

		protected override void Down(MigrationBuilder migrationBuilder) {
			migrationBuilder.DropTable(
				name: "Options");

			migrationBuilder.DropTable(
				name: "Petitions");

			migrationBuilder.DropTable(
				name: "Polls");

			migrationBuilder.DropTable(
				name: "Users");
		}

	}

}
