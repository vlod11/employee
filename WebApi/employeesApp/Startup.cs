using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.MongoDb;
using EmployeesApp.DataAccess;
using EmployeesApp.Web.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;
using UniHub.WebApi.Web.Helpers.Mappers;

namespace EmployeesApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            WebHostEnvironment = webHostEnvironment;
        }

        private IConfiguration Configuration { get; }
        private IWebHostEnvironment WebHostEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<MongoDbOptions>(
                Configuration.GetSection(nameof(MongoDbOptions)));

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UniHub API", Version = "v1" });
                c.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        Description = "JWT Authorization header using the Bearer scheme.",
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer"
                    });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                                         {
                                             {
                                                 new OpenApiSecurityScheme
                                                 {
                                                     Reference = new OpenApiReference
                                                                 {
                                                                     Id = "Bearer",
                                                                     Type = ReferenceType.SecurityScheme
                                                                 }
                                                 },
                                                 new List<string>()
                                             }
                                         });
            });
            
            services.AddAutoMapper(typeof(Startup).Assembly);
            services.AddScoped<IServiceResultMapper, ServiceResultMapper>();
            services.AddScoped<IDateHelper, DateHelper>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseMongoDbRepository<>));

            
            services.AddApiVersioning(
                o =>
                {
                    o.AssumeDefaultVersionWhenUnspecified = true;
                    o.DefaultApiVersion = new ApiVersion(1, 0);
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //TODO add only friendly origins
            app.UseCors(options =>
            {
                options.AllowAnyMethod();
                options.AllowAnyHeader();
                options.AllowAnyOrigin();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "UniHub API V1"); });

            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}