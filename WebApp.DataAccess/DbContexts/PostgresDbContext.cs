using Microsoft.EntityFrameworkCore;

using WebApp.DataAccess.Misc.Extensions;
using WebApp.Domain.Core;


namespace WebApp.DataAccess.DbContexts {

	public class PostgresDbContext : CustomDbContext {

		public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			modelBuilder.SetCustomSeed();
			base.OnModelCreating(modelBuilder);
		}

	}

}
