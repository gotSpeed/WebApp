using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using WebApp.DataAccess.DbContexts;
using WebApp.DataAccess.Repositories;
using WebApp.Domain.Interfaces;


namespace WebApp {
	public class Startup {

		private readonly IConfiguration _appConfig;

		public Startup(IConfiguration config) {
			_appConfig = config;
		}

		public void ConfigureServices(IServiceCollection services) {
			services.AddDbContextPool<PostgresDbContext>(
				options => options.UseNpgsql(_appConfig.GetConnectionString("Postgres"),
											 npgqslOptions => npgqslOptions.MigrationsAssembly("WebApp"))
								  .EnableSensitiveDataLogging()
			);

			services.AddIdentity<IdentityUser, IdentityRole>()
					.AddEntityFrameworkStores<PostgresDbContext>();

			services.AddSingleton<CustomDbContext, PostgresDbContext>()
			        .AddSingleton<IPollRepository, PollRepository>();

			services.AddControllersWithViews();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			}

			app.UseStaticFiles();
			app.UseAuthentication();
			app.UseRouting();

			app.UseEndpoints(endpoints => {
				endpoints.MapControllerRoute(
					name: "controller",
					pattern: "~/{controller}"
				);
				endpoints.MapControllerRoute(
					name: "action",
					pattern: "~/{controller}/{action}"
				);
			});
		}

	}

}
