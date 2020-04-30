using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Misc.Song.ShareClub.BLL;
using Misc.Song.ShareClub.DAL;
using Misc.Song.ShareClub.DataAccess;
using Misc.Song.ShareClub.IBLL;
using Misc.Song.ShareClub.IDAL;
using Misc.Song.ShareClub.Models;

namespace Misc.Song.ShareClub.UI
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
            services.AddSession();

            services.AddDbContext<ShareContext>(options => options.UseMySQL(Configuration.GetConnectionString("DBStr")));
            services.AddScoped<IFileTypeService, FileTypeService>();
            services.AddScoped<IFileTypeDal, FileTypeDal>();
            services.AddScoped<IBaseDal<FileType>, BaseDal<FileType>>();

            services.AddScoped<IUserInfoService, UserinfoService>();
            services.AddScoped<IUserInfoDal, UserInfoDal>();
            services.AddScoped<IBaseDal<UserInfo>, BaseDal<UserInfo>>();

            services.AddScoped<IUserLogService, UserLogService>();
            services.AddScoped<IUserLogDal, UserLogDal>();
            services.AddScoped<IBaseDal<UserLog>, BaseDal<UserLog>>();

            services.AddScoped<IFileInfoService, FileInfoService>();
            services.AddScoped<IFileInfoDal, FileInfoDal>();
            services.AddScoped<IBaseDal<FileInfo>, BaseDal<FileInfo>>();


            services.AddControllersWithViews();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
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
