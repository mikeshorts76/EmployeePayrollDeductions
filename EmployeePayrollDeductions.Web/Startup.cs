using AutoMapper;
using EmployeePayrollDeductions.Domain;
using EmployeePayrollDeductions.Domain.Interfaces;
using EmployeePayrollDeductions.Domain.Models;
using EmployeePayrollDeductions.Domain.Repositories;
using EmployeePayrollDeductions.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace EmployeePayrollDeductions.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            //services.AddAutoMapper();

            var dbName = Guid.NewGuid().ToString();
            services.AddDbContext<DatabaseContext>(options => options.UseInMemoryDatabase(dbName));

            Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());

            // Repositories
            services.AddTransient<IRepository<Employee>, EmployeeRepository>();
            services.AddTransient<IRepository<Dependent>, DependentRepository>();

            // Services
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IDependentService, DependentService>();            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            
            AddSeedData(app);           

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }

        private static void AddSeedData(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();

                // Seed the database
                var employees = new List<Employee>();

                var dependent = new Dependent
                {
                    DependentId = 1,
                    //EmployeeId = 1,
                    FirstName = "Lori",
                    LastName = "Schwartz"
                };

                var dependent2 = new Dependent
                {
                    DependentId = 2,
                    //EmployeeId = 1,
                    FirstName = "Elle",
                    LastName = "Schwartz"
                };

                var employee1 = new Employee
                {
                    FirstName = "Michael",
                    LastName = "Schwartz",
                    EmployeeId = 1
                };
                employee1.Dependents.Add(dependent);
                employee1.Dependents.Add(dependent2);

                //-----------------------------------------------------------
                
                var dependent3 = new Dependent
                {
                    DependentId = 3,
                    EmployeeId = 2,
                    FirstName = "Adam",
                    LastName = "Doe"
                };

                var dependent4 = new Dependent
                {
                    DependentId = 4,
                    EmployeeId = 2,
                    FirstName = "Kevin",
                    LastName = "Doe"
                };

                var employee2 = new Employee
                {
                    FirstName = "John",
                    LastName = "Doe",
                    EmployeeId = 2
                };
                employee2.Dependents.Add(dependent3);
                employee2.Dependents.Add(dependent4);
                //context.Dependents.Add(dependent);
                //context.Dependents.Add(dependent2);

                context.Employees.Add(employee1);

                context.Employees.Add(employee2);

                context.SaveChanges();                
            }            
        }
    }
}
