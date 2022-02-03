using Adopte1Dev.BLL.Entities;
using Adopte1Dev.BLL.Repositories;
using Adopte1Dev.Common;
using Adpote1Dev.Handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adpote1Dev
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
            services.AddControllersWithViews();
            // INJECTER LES DEPENDANCES ICI POUR QUE LES VUES FONCTIONNENT
            // Injection de dépendance pour la DAL
            services.AddScoped<IDeveloperRepository<Adopte1Dev.DAL.Entities.Developer>, Adopte1Dev.DAL.Repositories.DeveloperService>();
            services.AddScoped<ICategoriesRepository<Adopte1Dev.DAL.Entities.Categories>, Adopte1Dev.DAL.Repositories.CategoriesService>();

            // Injection de dépendance pour le BLL
            services.AddScoped<IDeveloperRepository<DeveloperBLL>, DeveloperService>();
            services.AddScoped<ICategoriesRepository<CategoriesBLL>, CategoriesService>();
            
            //services.AddScoped<SessionManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            // SESSION
            //app.UseSession();
            //

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
