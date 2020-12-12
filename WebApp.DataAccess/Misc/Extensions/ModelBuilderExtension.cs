using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using WebApp.Domain.Core;


namespace WebApp.DataAccess.Misc.Extensions {

	public static class ModelBuilderExtension {

		public static void SetCustomSeed(this ModelBuilder modelBuilder) {
			// Users
			var userSeed = new {
				Id                      = 1,
				UserName                = "testUser",
				Email                   = "testuser@mail.ru",
				AccessFailedCount       = 0,
				EmailConfirmed          = false,
				PhoneNumberConfirmed    = false,
				TwoFactorEnabled        = false,
				LockoutEnabled          = false
			};
			var userSeed1 = new {
				Id                      = 2,
				UserName                = "testUser1",
				Email                   = "testuser1@mail.ru",
				AccessFailedCount       = 0,
				EmailConfirmed          = false,
				PhoneNumberConfirmed    = false,
				TwoFactorEnabled        = false,
				LockoutEnabled          = false
			};
			var userSeed2 = new {
				Id                      = 3,
				UserName                = "testUser2",
				Email                   = "testuser2@mail.ru",
				AccessFailedCount       = 0,
				EmailConfirmed          = false,
				PhoneNumberConfirmed    = false,
				TwoFactorEnabled        = false,
				LockoutEnabled          = false
			};

			// Voting options
			var option = new {
				Id              = 1,
				Content         = "1",
				VotersAmount    = 3U,
				PollId          = (int?) 1
			};
			var option1 = new {
				Id              = 2,
				Content         = "2",
				VotersAmount    = 2U,
				PollId          = (int?) 1
			};

			// Petition, poll
			var petition = new {
				Id                  = 1,
				Header              = "TestPetition",
				ShortDescription    = "ShortDescription",
				Description         = "Lorem ipsum dolor sit amet, consectetur adipiscing elit," +
									  "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Eu nisl" +
									  "nunc mi ipsum faucibus vitae aliquet nec.",
				PublicationDate     = DateTime.UtcNow,
				AuthorId            = userSeed.Id,
				VotersAmount        = 15U,
				ExpirationDate      = DateTime.UtcNow,
				NextGoal            = 100U,
				TotalGoal           = 20000U
			};
			var poll = new {
				Id                  = 1,
				Header              = "TestPetition",
				ShortDescription    = "ShortDescription",
				Description         = "Lorem ipsum dolor sit amet, consectetur adipiscing elit," +
									  "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Eu nisl" +
									  "nunc mi ipsum faucibus vitae aliquet nec.",
				PublicationDate     = DateTime.UtcNow,
				AuthorId            = userSeed.Id,
				VotersAmount        = 15U,
				IsAnonymous         = false
			};

			// M2M tables
			var petitionUser = new {
				UserId		= 1,
				PetitionId	= 1
			};
			var petitionUser1 = new {
				UserId		= 2,
				PetitionId	= 1
			};
			var petitionUser2 = new {
				UserId		= 3,
				PetitionId	= 1
			};

			var voptionUser = new {
				UserId			= 1,
				VotingOptionId	= 1,
			};
			var voptionUser1 = new {
				UserId			= 2,
				VotingOptionId	= 1,
			};
			var voptionUser2 = new {
				UserId			= 3,
				VotingOptionId	= 1,
			};
			var voptionUser3 = new {
				UserId			= 1,
				VotingOptionId	= 2,
			};
			var voptionUser4 = new {
				UserId			= 2,
				VotingOptionId	= 2,
			};


			modelBuilder.Entity<Petition>().HasData(petition);
			modelBuilder.Entity<Poll>().HasData(poll);
			modelBuilder.Entity<VotingOption>().HasData(option, option1);
			modelBuilder.Entity<User>().HasData(userSeed, userSeed1, userSeed2);
			modelBuilder.Entity<PetitionUser>().HasData(petitionUser, petitionUser1, petitionUser2);
			modelBuilder.Entity<VotingOptionUser>().HasData(voptionUser, voptionUser1, voptionUser2, voptionUser3, voptionUser4);
		}

	}

}
