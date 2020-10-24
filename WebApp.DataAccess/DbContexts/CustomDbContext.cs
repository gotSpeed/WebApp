using Microsoft.EntityFrameworkCore;

using WebApp.Domain.Core;


namespace WebApp.DataAccess.DbContexts {

	public class CustomDbContext : DbContext {

		public DbSet<User> Users { get; set; }
		public DbSet<Poll> Polls { get; set; }
		public DbSet<Petition> Petitions { get; set; }
		public DbSet<VotingOption> Options { get; set; }

		public CustomDbContext(DbContextOptions<PostgresDbContext> options) : base(options) { }

	}

}
