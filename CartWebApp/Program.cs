using Microsoft.EntityFrameworkCore;
using CartWebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Configure DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<CartWebApp.Services.ProductService>();

//builder.Services.AddSingleton<ProductService>();


// Add services to the container.
builder.Services.AddControllersWithViews();

// Register services for session and HTTP context accessor.
builder.Services.AddSession(options =>
{
    // Optional: Configure session timeout (e.g., 30 minutes).
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});
builder.Services.AddHttpContextAccessor();

// Register ShoppingCart as a scoped service.
builder.Services.AddScoped<CartWebApp.Models.ShoppingCart>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession(); // Ensure UseSession is called after UseRouting and before UseEndpoints.

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
