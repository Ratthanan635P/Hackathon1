using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EWallet.DataAccess.Contexts;
using EWallet.DataAccess.Repositories;
using EWallet.Domain.Interfaces.Repositories;
using EWallet.Domain.Interfaces.Services;
using EWallet.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EWallet.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors();
			services.AddControllers();
			services.AddDbContext<EWalletContext>();
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IAgrentRepository, AgrentRepository>();
			services.AddScoped<IMarchantRepository, MarchantRepository>();

			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IAgrentService, AgrentService>();
			//services.AddScoped<IMarchantService, MarchantService>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			//app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
