using Microsoft.EntityFrameworkCore;
using OnlineDars.DataAccess.DbContexts;
using OnlineDars.DataAccess.Interfaces;
using OnlineDars.DataAccess.Repositories;
using OnlineDars.Service.Interfaces.Accounts;
using OnlineDars.Service.Interfaces.Categories;
using OnlineDars.Service.Interfaces.Common;
using OnlineDars.Service.Interfaces.Videos;
using OnlineDars.Service.Services.Accounts;
using OnlineDars.Service.Services.Categories;
using OnlineDars.Service.Services.Common;
using OnlineDars.Service.Services.Video;
using OnlineDars.Web.Configuration.LayerConfiguration;
using OnlineDars.Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

string connectionString = builder.Configuration.GetConnectionString("Database");
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IVideoService, VideoService>();
builder.Services.AddScoped<IAuthManager, AuthManager>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.ConfigureWeb(builder.Configuration);
builder.Services.AddScoped<IIdentityService, IdentityService>();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseStatusCodePages(async context =>
{
	if (context.HttpContext.Response.StatusCode == 401)
	{
		context.HttpContext.Response.Redirect("accounts/login");
	}	

});
app.UseMiddleware<TokenRedirectMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
