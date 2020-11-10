using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageBase.WebApp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AutoMapper;
using ImageBase.WebApp.Data.Models.Authentication;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json.Serialization;
using ImageBase.WebApp.Repository;
using ImageBase.WebApp.Repository.Storage;
using ImageBase.WebApp.Service.Interface;
using ImageBase.WebApp.Service.Implementation;

namespace ImageBase.WebApp
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
            services.AddControllers();
            services.AddDbContextPool<AspPostgreSQLContext>(options =>
                    options.UseNpgsql(Configuration.GetConnectionString("AspPostgreSQLContext")));
            services.AddControllers().AddNewtonsoftJson(s =>
            {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddIdentity<User, IdentityRole>().
               AddEntityFrameworkStores<AspPostgreSQLContext>();

            services.AddScoped(typeof(IImageRepository), typeof(ImageRepository));
            services.AddScoped(typeof(ICatalogRepository), typeof(CatalogRepository));
            services.AddScoped(typeof(IImageCatalogRepository), typeof(ImageCatalogRepository));

            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<ICatalogService, CatalogService>();
            services.AddTransient<IImageCatalogService, ImageCatalogService>();

            services.AddMvc();

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "ImageBase.Cookie";
                options.Cookie.HttpOnly = true;

                options.ExpireTimeSpan = TimeSpan.FromDays(36500);

                options.LoginPath = "/api/Authentication/login";
                options.SlidingExpiration = true;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
