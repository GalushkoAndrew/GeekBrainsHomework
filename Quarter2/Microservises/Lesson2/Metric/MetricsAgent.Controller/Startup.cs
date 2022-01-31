using System;
using System.IO;
using System.Reflection;
using FluentMigrator.Runner;
using GeekBrains.Learn.Core.DAO.Model;
using GeekBrains.Learn.Core.Infrastructure.DI;
using GeekBrains.Learn.Core.Infrastructure.Jobs.Service;
using GeekBrains.Learn.Core.Infrastructure.Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace GeekBrains.Learn.Core.MetricsAgent.Controller
{
    /// <inheritdoc/>
    public class Startup
    {
        private readonly IWebHostEnvironment _environment;

        /// <inheritdoc/>
        public Startup(IWebHostEnvironment environment)
        {
            _environment = environment;
            Configuration = new ConfigurationBuilder()
                .SetBasePath(_environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{_environment.EnvironmentName}.json", optional: true)
                .Build();
        }

        private IConfiguration Configuration { get; }

        /// <inheritdoc/>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddServices();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Core.Metric.Controller info", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
            });

            services.AddMapper();

            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            var uri = Configuration.GetSection("Urls").Value;
            var managerUri = Configuration.GetSection("ManagerUri").Value;
            services.AddSingleton(new StartOptions(connectionString, uri, managerUri));

            services.AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSQLite()
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(typeof(Startup).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole());

            services.AddHostedService<QuartzHostedService>();

            services.AddHttpClient();
        }

        /// <inheritdoc/>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMigrationRunner migrationRunner)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            migrationRunner.MigrateUp();
        }
    }
}
