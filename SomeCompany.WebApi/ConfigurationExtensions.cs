using System;
using System.Net;
using System.Reflection;
using FluentValidation.AspNetCore;
using GlobalExceptionHandler.WebApi;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SomeCompany.Application.Departments.Add;
using SomeCompany.Application.Departments.Get;
using SomeCompany.Application.Exceptions;
using SomeCompany.Application.PipelineBehaviors;
using SomeCompany.Database;

namespace SomeCompany.WebApi
{
    public static class ConfigurationExtensions
    {
        #region MediatR

        public static IServiceCollection ConfigureMediatR(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
            services.AddMediatR(typeof(GetDepartmentQuery).GetTypeInfo().Assembly);

            return services;
        }

        #endregion

        #region Entity framework

        public static IServiceCollection ConfigureEntityFramework(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CompanyDbContext>(b => b.UseSqlServer(connectionString));

            return services;
        }

        #endregion

        #region Fluent validation

        public static IMvcBuilder ConfigureFluentValidation(this IMvcBuilder mvcBuilder)
        {
            mvcBuilder.AddFluentValidation(fv =>
                fv.RegisterValidatorsFromAssemblyContaining<AddDepartmentCommandValidation>());

            return mvcBuilder;
        }

        #endregion

        #region Global exception handling

        public static IApplicationBuilder ConfigureGlobalExceptionHandling(this IApplicationBuilder app)
        {
            app.UseGlobalExceptionHandler(ConfigureExceptionMapping);

            return app;
        }

        private static void ConfigureExceptionMapping(ExceptionHandlerConfiguration configuration)
        {
            configuration
                .Map<BadRequestException>()
                .ToStatusCode(HttpStatusCode.BadRequest)
                .WithBody((ex, context) => ExceptionResponseBody(ex));
        }

        public static string ExceptionResponseBody(Exception ex)
        {
            return JsonConvert.SerializeObject(new { ex.Message }, Formatting.Indented);
        }

        #endregion
    }
}
