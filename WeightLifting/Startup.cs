using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Data.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Services.Provider;
using AutoMapper;
using Services.Services.Interfaces;
using Services.Services.Implementations;

namespace WeightLifting
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper();
            services.AddTransient<IContestantServis, ContestantServis>();
            services.AddTransient<IAttemptServis, AttemptServis>();
            services.AddTransient<ICompetitionServis, CompetitionServis>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ApplicationDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            
            else
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{conteroller}/{action=Index}/{id}");
            });

            DBInitializeProvider.Init(dbContext);
        }
    }
}
