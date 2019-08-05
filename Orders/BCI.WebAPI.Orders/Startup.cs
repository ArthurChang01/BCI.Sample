using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using BCI.Orders.Application;
using BCI.Orders.WebAPI.Modules;
using MediatR.Extensions.Autofac.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace BCI.Orders.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddControllersAsServices()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info() { Title = "BCI Product API", Version = "v1" });
            });

            var containerBuilder = new ContainerBuilder();
            containerBuilder.AddMediatR(typeof(OrderApplication).Assembly);

            containerBuilder.RegisterModule<AutofacModule>();
            containerBuilder.Populate(services);

            var container = containerBuilder.Build();
            return new AutofacServiceProvider(container);
        }

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