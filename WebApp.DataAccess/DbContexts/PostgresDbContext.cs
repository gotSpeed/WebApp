using Microsoft.EntityFrameworkCore;
using WebApp.DataAccess.DbContexts.Extensions;
using WebApp.Domain.Core;


namespace WebApp.DataAccess.DbContexts {

	public class PostgresDbContext : DbContext {

		public DbSet<User> Users { get; set; }
		public DbSet<Poll> Polls { get; set; }
		public DbSet<Petition> Petitions { get; set; }
		public DbSet<VotingOption> Options { get; set; }

		public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			modelBuilder.SetCustomSeed();
			base.OnModelCreating(modelBuilder);
		}

	}

}
