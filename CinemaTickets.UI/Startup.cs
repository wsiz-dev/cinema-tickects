using System.Collections.Generic;
using CinemaTicket.Infrastructure;
using CinemaTicket.Infrastructure.Repositories;
using CinemaTickets.Core.Command;
using CinemaTickets.Core.Query;
using CinemaTickets.Core.Query.DTO;
using CinemaTickets.Domain;
using CinemaTickets.Domain.Command;
using CinemaTickets.Domain.Query;
using CinemaTickets.Domain.Repositories;
using CinemaTickets.Domain.Service;
using CinemaTickets.Infrastructure;
using CinemaTickets.Infrastructure.Repositories;
using CinemaTickets.Infrastructure.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaTickets.UI
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services
                .AddDbContext<CinemaTicketDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("CinemaTicketDatabase"),
                        b => b.MigrationsAssembly("CinemaTickets.Infrastructure")
                    ));

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services
                .AddScoped<ICommandHandler<BuyTicketCommand>, BuyTicketCommandHandler>()
                .AddScoped<ICommandHandler<AddMovieCommand>, AddMovieCommandHandler>()
                .AddScoped<ICommandHandler<RegisterSeanceCommand>, RegisterSeanceCommandHandler>();

            services
                .AddScoped<IQueryHandler<GetAllMoviesQuery, List<MovieDto>>, GetAllMoviesQueryHandler>()
                .AddScoped<IQueryHandler<GetSeatsInUseQuery, int>, GetSeatsInUseQueryHandler>()
                .AddScoped<IQueryHandler<GetMovieQuery, MovieDetailsDTO>, GetMovieQueryHandler>()
                .AddScoped<IQueryHandler<GetSeanceQuery, MovieSeanceDetailsDTO>, GetSeanceQueryHanlder>();


            services
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IRoomService, RoomService>();

            services
                .AddScoped<IMoviesRepository, MoviesRepository>()
                .AddScoped<IRoomRepository, RoomRepository>();

            services
                .AddSingleton<Messages>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}