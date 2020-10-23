using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using WebApp.Domain.Core;


namespace WebApp.DataAccess.DbContexts.Extensions {

	public static class ModelBuilderExtension {

		public static void SetCustomSeed(this ModelBuilder modelBuilder) {
			var userSeed = new {
				Id                      = 1U,
				UserName                = "testUser",
				Email                   = "testuser@mail.ru",
				UserPolls               = new List<object>(),
				UserPetitions           = new List<object>(),
				AccessFailedCount       = 0,
				EmailConfirmed          = false,
				PhoneNumberConfirmed    = false,
				TwoFactorEnabled        = false,
				LockoutEnabled          = false
			};
			var userSeed1 = new {
				Id                      = 2U,
				UserName                = "testUser1",
				Email                   = "testuser1@mail.ru",
				UserPolls               = new List<object>(),
				UserPetitions           = new List<object>(),
				AccessFailedCount       = 0,
				EmailConfirmed          = false,
				PhoneNumberConfirmed    = false,
				TwoFactorEnabled        = false,
				LockoutEnabled          = false
			};
			var userSeed2 = new {
				Id                      = 3U,
				UserName                = "testUser2",
				Email                   = "testuser2@mail.ru",
				UserPolls               = new List<object>(),
				UserPetitions           = new List<object>(),
				AccessFailedCount       = 0,
				EmailConfirmed          = false,
				PhoneNumberConfirmed    = false,
				TwoFactorEnabled        = false,
				LockoutEnabled          = false
			};

			var option1 = new {
				Id              = 1U,
				Content         = "1",
				VotersAmount    = 2U,
				//VotersId        = new List<uint> { userSeed.Id, userSeed1.Id },
			};
			var option2 = new {
				Id              = 2U,
				Content         = "2",
				VotersAmount    = 3U,
				//VotersId        = new List<uint> { userSeed.Id, userSeed1.Id, userSeed2.Id },
			};

			var petition = new {
				Id                  = 1U,
				Header              = "TestPetition",
				ShortDescription    = "ShortDescription",
				Description         = "Lorem ipsum dolor sit amet, consectetur adipiscing elit," +
									  "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Eu nisl" +
									  "nunc mi ipsum faucibus vitae aliquet nec.",
				PublicationDate     = DateTime.UtcNow,
				AuthorId            = userSeed.Id,
				VotersAmount        = 15U,
				//VotersId            = new List<uint> { userSeed.Id, userSeed1.Id, userSeed2.Id },
				ExpirationDate      = DateTime.UtcNow,
				NextGoal            = 100U,
				TotalGoal           = 20000U
			};
			var poll = new {
				Id                  = 1U,
				Header              = "TestPetition",
				ShortDescription    = "ShortDescription",
				Description         = "Lorem ipsum dolor sit amet, consectetur adipiscing elit," +
									  "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Eu nisl" +
									  "nunc mi ipsum faucibus vitae aliquet nec.",
				PublicationDate     = DateTime.UtcNow,
				AuthorId            = userSeed.Id,
				VotersAmount        = 15U,
				//VotersId            = new List<uint> { userSeed.Id, userSeed2.Id },
				IsAnonymous         = false,
				//OptionsId           = new List<uint> { option1.Id, option2.Id }
			};

			modelBuilder.Entity<Petition>().HasData(petition);
			modelBuilder.Entity<Poll>().HasData(poll);
			modelBuilder.Entity<VotingOption>().HasData(option1, option2);
			modelBuilder.Entity<User>().HasData(userSeed, userSeed1, userSeed2);
		}

	}

}
