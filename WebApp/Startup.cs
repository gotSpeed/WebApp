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
using WebApp.Domain.Core;


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

			services.AddIdentity<User, IdentityRole<int>>()
					.AddEntityFrameworkStores<PostgresDbContext>();

			services.AddSingleton<CustomDbContext, PostgresDbContext>()
					.AddSingleton<IPollRepository, PollRepository>()
					.AddSingleton<IPetitionRepository, PetitionRepository>()
					.AddSingleton<IUserRepository, UserRepository>();

			services.AddControllersWithViews();

			services.AddAuthentication()
					.AddGoogle(options => {
						options.ClientId = "519521638508-rclrukh52njcn09pqqa4ase6r0elhp9k.apps.googleusercontent.com";
						options.ClientSecret = "COOtYOY701tJRvNO-O4QWfnW";
						options.CallbackPath = "/SignIn-google";
					});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			}

			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints => {
				endpoints.MapControllerRoute(
					name: "id",
					pattern: "~/{controller}/{action}/{id}/"
				);
				endpoints.MapControllerRoute(
					name: "action",
					pattern: "~/{controller}/{action}/"
				);
				endpoints.MapControllerRoute(
					name: "controller",
					pattern: "~/{controller}/"
				);
			});
		}

	}

}
