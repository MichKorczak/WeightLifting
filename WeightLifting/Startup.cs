using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Data.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Data.User;
using Microsoft.AspNetCore.Identity;
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
            
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(option =>
            {
                option.Password.RequireDigit = true;
                option.Password.RequiredLength = 8;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireUppercase = true;
                option.Password.RequiredUniqueChars = 6;

                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(30);
                option.Lockout.MaxFailedAccessAttempts = 10;
                option.Lockout.AllowedForNewUsers = true;

                option.User.RequireUniqueEmail = true;
            }); // tego wszystko nie należało by wypisać w innym miejscu? 
            services.ConfigureApplicationCookie(optional =>
            {
                optional.Cookie.HttpOnly = true;
                optional.ExpireTimeSpan = TimeSpan.FromMinutes(30);

                optional.LoginPath = "/Account/Login";
                optional.AccessDeniedPath = "/Account/AccessDenied";
                optional.SlidingExpiration = true;
            }); // tego wszystko nie należało by wypisać w innym miejscu? 
            services.AddAutoMapper();
            services.AddTransient<IEmailSender, UserServices>();
            services.AddTransient<IContestantServis, ContestantServis>();
            services.AddTransient<IAttemptServis, AttemptServis>();
            services.AddTransient<ICompetitionServis, CompetitionServis>();
            services.AddTransient<IContestantCompetitionServis, ContestantCompetitionServis>();
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
        }
    }
}
