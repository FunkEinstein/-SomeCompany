using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SomeCompany.Application.Departments.Get;
using SomeCompany.Application.PipelineBehaviors;
using SomeCompany.Database;
using FluentValidation.AspNetCore;
using SomeCompany.Application.Departments.Add;

namespace SomeCompany.WebApi
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
            // configure MediatR
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
            services.AddMediatR(typeof(GetDepartmentQuery).GetTypeInfo().Assembly);

            // configure EF
            var connectionString = Configuration.GetConnectionString("CompanyDatabase");
            services.AddDbContext<CompanyDbContext>(b => b.UseSqlServer(connectionString));

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                // configure FluentValidation
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddDepartmentCommandValidation>());
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
