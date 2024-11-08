using IntergalacticConflict.Core.ServiceInterface;
using InterGalacticConflict.Data;
using Microsoft.EntityFrameworkCore;
using InterGalacticConflict.ApplicationServices.Services;
using InterGalacticConflict.ApplicationServices.GalacticTitans.ApplicationServices.Services;

var builder = WebApplication.CreateBuilder(args);
    

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IShipServices, ShipServices>();
builder.Services.AddScoped<IFileServices, FileServices>();
builder.Services.AddDbContext<InterGalacticConflictContext>(                                                                                               
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); 

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
