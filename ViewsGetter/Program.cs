using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();   
builder.Services.AddDefaultIdentity<IdentityUser>()       // dodać
    .AddRoles<IdentityRole>()                             //
    .AddEntityFrameworkStores<AppDbContext>();     // 


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddTransient<IComputerService, EFComputerService>();

builder.Services.AddMemoryCache();                        // dodać
builder.Services.AddSession();                            // dodać 

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

app.UseAuthentication();                                 // dodać
app.UseAuthorization();                                  // dodać
app.UseSession();                                        // dodać 
app.MapRazorPages();                                     // dodać

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
