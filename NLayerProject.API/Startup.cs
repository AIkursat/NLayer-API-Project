using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLayerProject.Data;
using Microsoft.EntityFrameworkCore;
using NLayerProject.Core.UnitOfWorks;
using NLayerProject.Data.UnitOfWorks;
using NLayerProject.Core.Repositories;
using NLayerProject.Data.Repositories;
using NLayerProject.Core.Service;
using NLayerProject.Service.Services;
using AutoMapper;
using NLayerProject.API.Filters;
using Microsoft.AspNetCore.Diagnostics;
using NLayerProject.API.DTOs;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NLayerProject.API.Extensions;

namespace NLayerProject.API
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
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<NotFoundFilter>();
            services.AddScoped(typeof(IService<>), typeof(Service.Services.Service<>));
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>(); // It will use same object example (First created one) and create one by going to ctor of the class.

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"].ToString(), o =>
                {
                    o.MigrationsAssembly("NLayerProject.Data");
                });
            });
            
            services.AddControllers(o => { // Made possible for ValidationFilter for all method.
                o.Filters.Add(new ValidationFilter());
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddCors( options =>
           {
               options.AddDefaultPolicy(builder =>
               builder.WithOrigins("http://localhost:50500")
               .AllowAnyHeader()
               .AllowAnyOrigin());
           }
            );
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCustomException();
          
            app.UseCors();

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
