using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.ConfigureMediatR();

            // configure CORS
            services.AddClientCors();

            // configure EF
            var connectionString = Configuration.GetConnectionString("CompanyDatabase");
            services.ConfigureEntityFramework(connectionString);

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .ConfigureFluentValidation(); // configure fluent validation
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

            // configure global exception handling
            app.ConfigureGlobalExceptionHandling();

            // configure CORS
            app.UseClientCors();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
