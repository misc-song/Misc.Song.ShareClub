using Microsoft.EntityFrameworkCore;
using Misc.Song.ShareClub.BLL;
using Misc.Song.ShareClub.DAL;
using Misc.Song.ShareClub.DataAccess;
using Misc.Song.ShareClub.IBLL;
using Misc.Song.ShareClub.IDAL;
using Misc.Song.ShareClub.Models;
using System.Configuration;
using FileInfo = Misc.Song.ShareClub.Models.FileInfo;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AppDbConnectionString");
builder.Services.AddDbContext<ShareContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IFileTypeService, FileTypeService>();
builder.Services.AddScoped<IFileTypeDal, FileTypeDal>();
builder.Services.AddScoped<IBaseDal<FileType>, BaseDal<FileType>>();

builder.Services.AddScoped<IUserInfoService, UserinfoService>();
builder.Services.AddScoped<IUserInfoDal, UserInfoDal>();
builder.Services.AddScoped<IBaseDal<UserInfo>, BaseDal<UserInfo>>();

builder.Services.AddScoped<IUserLogService, UserLogService>();
builder.Services.AddScoped<IUserLogDal, UserLogDal>();
builder.Services.AddScoped<IBaseDal<UserLog>, BaseDal<UserLog>>();

builder.Services.AddScoped<IFileInfoService, FileInfoService>();
builder.Services.AddScoped<IFileInfoDal, FileInfoDal>();
builder.Services.AddScoped<IBaseDal<FileInfo>, BaseDal<FileInfo>>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
