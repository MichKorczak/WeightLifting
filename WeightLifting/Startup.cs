﻿using AutoMapper;
using Data.DataAccessLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Services.Implementations;
using Services.Services.Interfaces;

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

            services.AddAutoMapper();
            services.AddTransient<IContestantService, ContestantService>();
            services.AddTransient<IAttemptService, AttemptService>();
            services.AddTransient<ICompetitionService, CompetitionService>();
            services.AddTransient<IContestantCompetitionService, ContestantCompetitionService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IHashService, HashService>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ApplicationDbContext dbContext)
        {
            /*if (env.IsDevelopment())*/ app.UseDeveloperExceptionPage();

            app.UseMvc();
        }
    }
}