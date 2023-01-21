using Microsoft.EntityFrameworkCore;
using OnlineDars.DataAccess.DbContexts;
using OnlineDars.DataAccess.Interfaces;
using OnlineDars.DataAccess.Repositories;
using OnlineDars.Service.Interfaces.Categories;
using OnlineDars.Service.Interfaces.Videos;
using OnlineDars.Service.Services.Categories;
using OnlineDars.Service.Services.Video;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();


string connectionString = builder.Configuration.GetConnectionString("Database");
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IVideoService, VideoService>();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
