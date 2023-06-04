using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using poruke_namespace;
using rvas_projekat.Areas.Identity.Data;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("rvas_projekatContextConnection") ?? throw new InvalidOperationException("Connection string 'rvas_projekatContextConnection' not found.");

builder.Services.AddDbContext<rvas_projekatContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<rvas_projekatUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<rvas_projekatContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHealthChecks();
builder.Services.AddSignalR();

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
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<MessageHub>("/messages");
});

app.MapRazorPages();
app.Run();
