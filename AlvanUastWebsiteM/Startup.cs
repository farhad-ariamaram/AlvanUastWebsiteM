using AlvanUastWebsiteM.Middleware;
using AlvanUastWebsiteM.Models;
using AlvanUastWebsiteM.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AlvanUastWebsiteM
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
            services.AddDbContextPool<AlvanUastDBContext>(options => options.UseMySQL(EncryptStringSample.Decrypt(Configuration.GetConnectionString("cs"))));
            services.AddRazorPages();
            //services.AddDbContextPool<AlvanUastDBContext>(options => options.UseMySQL("server=localhost;port=3306;user=root;password=123123;database=alvanuastdb;CharSet=utf8"));
            //services.AddRazorPages().AddRazorPagesOptions(o =>
            //{
            //    o.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute());
            //});
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Error");
            //}

            app.UseExceptionHandler("/status500");
            app.UseStatusCodePages();
            app.UseStatusCodePagesWithReExecute("/status{0}");

            app.UseStaticFiles();

            app.UseSession();

            app.UseMiddleware<AuthenticationMiddleware>();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
