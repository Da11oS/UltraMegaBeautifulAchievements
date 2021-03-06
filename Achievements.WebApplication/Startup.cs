using Achievements.Database;
using Achievements.Domain.Models.Achievements;
using Achievements.WebApplication.Repositories;
using Achievements.WebApplication.Repositories.AchievementTypes;
using Achievements.WebApplication.Services;
using Achievements.WebApplication.Services.Interfaces;
using Achievements.WebApplication.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VueCliMiddleware;

namespace Achievements.WebApplication
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["DefaultConnection"]));

            #region DependecyInjection

            services.AddScoped(typeof(IEfRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IAchievementTypesRepository), typeof(AchievementTypesRepository));
            services.AddScoped(typeof(IAchievementColumnRepository), typeof(AchievementColumnRepository));
            services.AddScoped(typeof(IAchievementInstanceRepository), typeof(AchievementInstanceRepository));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IStoredFileService, StoredFileService>();
            services.AddScoped<IAchievementGroupsService, AchievementGroupsService>();
            services.AddScoped<IAchievementTypesService, AchievementTypesService>();
            services.AddScoped<IAchievementInstanceService, AchievementInstanceService>();
            services.AddScoped<IAchievementColumnService, AchievementColumnService>();
            #endregion
            
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            _ = Arguments.TryGetOptions(System.Environment.GetCommandLineArgs(), false, out string mode, out ushort port, out bool https);
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            if (https) app.UseHttpsRedirection();

            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseMiddleware<JwtMiddleware>();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    if (mode == "start") {
                        spa.UseVueCli(npmScript: "serve", port: port, forceKill: true, https: https);
                    }
                    
                    if (mode == "attach") {
                        spa.UseProxyToSpaDevelopmentServer($"{(https ? "https" : "http")}://localhost:{port}"); // your Vue app port
                    }
                }
            });
        }
    }
}
