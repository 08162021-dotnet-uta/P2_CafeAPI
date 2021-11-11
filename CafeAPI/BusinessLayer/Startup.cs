using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StorageLayer.Interfaces;
using StorageLayer.Repositories;
using StorageLayer;
using ModelsLayer.EfModels;
using BusinessLayer.Controllers;
using DatabaseLayer;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer
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

            services.AddCors((options) =>
            {
                options.AddPolicy(name: "dev", builder =>
                {
                    builder.WithOrigins(
                    "http://localhost:4200",
                    "http://127.0.0.1:5500",
                    "http://127.0.0.1:8080",
                    "http://127.0.0.1:8081",
                    "http://localhost:8081",
                    "https://localhost:5001",
                    "http://localhost:5000",
                    "http://localhost:5001"
                    )
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BusinessLayer", Version = "v1" });
            });
            services.AddDbContext<CafeContext>(options =>
            {
                //if (options.IsConfigured)
                //{
                //    options.UseSqlServer(Configuration.GetConnectionString("DevDb"));
                //}
                //if db options is already configured, done do anything..
                // otherwise use the Connection string I have in secrets.json

                if (!options.IsConfigured)
                {
                    options.UseSqlServer(Configuration.GetConnectionString("Default"));
                }
            });

            //registering classes with the DI system.
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IModelMapper, ModelMapper>();
            services.AddScoped<IProductRepository, ProductRepository>();
           // services.AddMvc(c => c.Conventions.Add(new ApiExplorerIgnores()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BusinessLayer v1"));
            }

            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("dev");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
