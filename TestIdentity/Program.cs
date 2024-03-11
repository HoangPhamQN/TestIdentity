using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TestIdentity.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("TestIdentityContextConnection") ?? throw new InvalidOperationException("Connection string 'TestIdentityContextConnection' not found.");

builder.Services.AddDbContext<TestIdentityContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<TestIdentityContext>();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
