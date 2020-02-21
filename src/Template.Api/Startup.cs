using System;
using System.Collections.Generic;
using System.Reflection;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Template.Domain.V1.Implementation;
using Template.Domain.V1.Interfaces;
using Template.Repositories.Abstractions.Interfaces;
using Template.Repositories.Example.Implementation;
using Template.Services.Abstractions.Interfaces;
using Template.Services.Example.Implementation;

namespace Template.Api
{
    public sealed class Startup
    {
        private IConfiguration _configuration;

        private static IEnumerable<Assembly> Assemblies => AppDomain.CurrentDomain.GetAssemblies();

        public Startup(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IExampleService, ExampleService>();
            services.AddTransient<IExampleRepository, ExampleRepository>();
            services.AddTransient<ITypedExample, Example>();

            services.AddAutoMapper(Assemblies);

            services.AddMvc().AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblies(Assemblies));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
