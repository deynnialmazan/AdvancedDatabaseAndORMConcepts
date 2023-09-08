using Microsoft.EntityFrameworkCore;
using AdvancedDatabase_Lab4.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HotelMVCAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HotelMVCAppContext") ?? throw new InvalidOperationException("Connection string 'HotelMVCAppContext' not found.")));

builder.Services.AddControllersWithViews(options =>
{
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
});

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