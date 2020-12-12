using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using WebApp.Domain.Core;


namespace WebApp.DataAccess.DbContexts {

	public class CustomDbContext : IdentityDbContext<User, IdentityRole<int>, int> {

		public override DbSet<User>	Users { get; set; }
		public DbSet<Poll>			Polls { get; set; }
		public DbSet<Petition>		Petitions { get; set; }
		public DbSet<VotingOption>	Options { get; set; }

		public CustomDbContext(DbContextOptions<PostgresDbContext> options) : base(options) { }

	}

}
