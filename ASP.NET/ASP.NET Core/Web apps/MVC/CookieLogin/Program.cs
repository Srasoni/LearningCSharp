using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(options =>
{
	options.DefaultScheme = CookieScheme.Name;
	//options.DefaultAuthenticateScheme = CookieScheme.Name; // 인증 스키마
	//options.DefaultChallengeScheme = CookieScheme.Name; // 도전 스키마
}).AddCookie(CookieScheme.Name, options =>
{
	options.AccessDeniedPath = "/account/denied";
	options.LoginPath = "/account/login";
});

builder.Services.AddSingleton<IConfigureOptions<CookieAuthenticationOptions>, CookieLogin.ConfigureMyCookie>();
builder.Services.AddSingleton<MyService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
