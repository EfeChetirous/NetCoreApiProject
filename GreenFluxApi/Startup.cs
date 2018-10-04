using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreenFluxApi.Domain.Models;
using GreenFluxApi.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace GreenFluxApi
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
            services.AddMvc();
            services.AddTransient<IFlickrService, FlickrService>();
            services.AddTransient<IFlickrManager, FlickrManager>();
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<IRedisCacheSerivice, RedisCacheService>();

            services.AddDistributedRedisCache(option =>
            {
                option.Configuration = Configuration.GetConnectionString("RedisConnection");
                option.InstanceName = "master";
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Greenflux", Version = "v1", Description = "this is a test web api for GreenFlux!" });
            });
            services.Configure<FlickrModel>(Configuration.GetSection("Flickr"));
            services.Configure<RedisSettingModel>(Configuration.GetSection("RedisSettings"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Greenflux v1");
            });
        }
    }
}
