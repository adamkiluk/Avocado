namespace Avocado.FunctionalTests.Infrastructure
{
    using Avocado.Application.Interfaces;
    using Avocado.WebAPI.Filters;
    using Avocado.Persistence;
    using Avocado.Persistence.Repository;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class TestStartup
    {
        public TestStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();

            services.AddMvc(options =>
                options.Filters.Add(typeof(CustomExceptionFilterAttribute)))
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);


            services.AddDbContext<AvocadoDbContext>(options =>
                options.UseInMemoryDatabase("TEST"));

            services.AddScoped<IAvocadoDbContext, AvocadoDbContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ISignboardRepository, SignboardRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseMvc();
            //app.UseSignalR(routes => routes.MapHub<NotificationTestHub>("/Notifications"));
        }
    }
}
