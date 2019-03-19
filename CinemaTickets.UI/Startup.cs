using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.Repositories;
using CinemaTickets.Domain.Service;
using CinemaTickets.Infrastructure;
using CinemaTickets.Infrastructure.Repositories;
using CinemaTickets.Infrastructure.Service;
using CinemaTickets.UI.Middleware;
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

        public IContainer Container { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
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

            services.AddMvc(setup =>
                {
                    setup.Filters.Add<FakeAuthorizationFilter>();
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSingleton(Configuration.GetSection("EmailSettings").Get<EmailSettings>());


            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(services);

            containerBuilder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<RoomService>().As<IRoomService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<EmailSender>().As<IEmailSender>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<EmailService>().As<IEmailService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<MoviesRepository>().As<IMoviesRepository>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<RoomRepository>().As<IRoomRepository>().InstancePerLifetimeScope();
            containerBuilder.ConfigureMediator();

            Container = containerBuilder.Build();
            return new AutofacServiceProvider(Container);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime appLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
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

            appLifetime.ApplicationStopped.Register(Container.Dispose);
        }
    }
}