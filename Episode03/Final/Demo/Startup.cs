using Demo.Infrastructure;
using Demo.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Demo
{
    public class Startup
    {
        private string ConnectionString => @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SecurityDemo";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages(options =>
                options.Conventions.AuthorizePage("/Products"));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Login";
                    options.LogoutPath = "/Logout";
                });
            
            services.AddDbContext<EntireContext>(options => options.UseSqlServer(this.ConnectionString));
            services.AddDbContext<AuthenticationContext>(options => options.UseSqlServer(this.ConnectionString));
            //services.AddDbContext<ContentContext>(options => options.UseSqlServer(this.ConnectionString));

            services.AddLogging(builder => builder.AddFilter(DbLoggerCategory.Name, LogLevel.Debug).AddConsole());
            services.AddSingleton<IContentGatewayFactory, ContentContextFactory>(svc => new ContentContextFactory(this.ConnectionString, svc.GetService<ILoggerFactory>()));
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
