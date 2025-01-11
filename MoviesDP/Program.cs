using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MoviesDP.Models.Movies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

// Movies
builder.Services.AddDbContext<MoviesContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("MoviesDatabase"));
});


// User login
builder.Services.AddDbContext<LoginDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("LoginDatabase"));
});

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LoginDbContext>();

builder.Services.AddTransient<IMovieServices, EFMovieService>();

builder.Services.AddMemoryCache();
builder.Services.AddSession();

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
app.UseSession();
app.MapRazorPages();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
