using Microsoft.EntityFrameworkCore;

using WebApp.DataAccess.Misc.Extensions;
using WebApp.Domain.Core;


namespace WebApp.DataAccess.DbContexts {

	public class PostgresDbContext : CustomDbContext {

		public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			base.OnModelCreating(modelBuilder);

			modelBuilder.Ignore<Post>();

			modelBuilder.Entity<User>().HasAlternateKey(user => user.UserName);
			modelBuilder.Entity<User>().HasAlternateKey(user => user.Email);

			modelBuilder.Entity<Poll>().HasOne(post => post.Author)
									   .WithMany(user => user.UserPolls)
									   .HasForeignKey(post => post.AuthorId)
									   .OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<Petition>().HasOne(post => post.Author)
										   .WithMany(user => user.UserPetitions)
										   .HasForeignKey(post => post.AuthorId)
										   .OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<Petition>().HasMany(post => post.Voters)
										   .WithOne(petitionUser => petitionUser.Petition)
										   .HasForeignKey(petitionUser => petitionUser.PetitionId)
										   .OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<VotingOption>().HasOne(option => option.Poll)
											   .WithMany(poll => poll.Options)
											   .HasForeignKey(option => option.PollId)
											   .OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<VotingOption>().HasMany(option => option.Voters)
											   .WithOne(optionUser => optionUser.VotingOption)
											   .HasForeignKey(optionUser => optionUser.VotingOptionId)
											   .OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<User>().HasMany<VotingOptionUser>()
									   .WithOne(optionUser => optionUser.User)
									   .HasForeignKey(optionUser => optionUser.UserId)
									   .OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<User>().HasMany<PetitionUser>()
									   .WithOne(petitionUser => petitionUser.User)
									   .HasForeignKey(petitionUser => petitionUser.UserId)
									   .OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<PetitionUser>().HasKey(petUs => new { petUs.UserId, petUs.PetitionId });
			modelBuilder.Entity<VotingOptionUser>().HasKey(voptUs => new { voptUs.UserId, voptUs.VotingOptionId });


			modelBuilder.SetCustomSeed();
		}

	}

}
