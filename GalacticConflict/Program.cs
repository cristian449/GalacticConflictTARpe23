using IntergalacticConflict.Core.ServiceInterface;
using InterGalacticConflict.Data;
using Microsoft.EntityFrameworkCore;
using InterGalacticConflict.ApplicationServices.Services;
using InterGalacticConflict.ApplicationServices.GalacticTitans.ApplicationServices.Services;
using IntergalacticConflict.Core.Domain;
using Microsoft.AspNetCore.Identity;
using InterGalacticConflict.Security;

var builder = WebApplication.CreateBuilder(args);
    

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IShipServices, ShipServices>();
builder.Services.AddScoped<IFileServices, FileServices>();
builder.Services.AddScoped<IAccountServices, AccountsServices>();
builder.Services.AddScoped<IEmailsServices, EmailServices>();
builder.Services.AddDbContext<InterGalacticConflictContext>(                                                                                               
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequiredLength = 3;
    options.Tokens.EmailConfirmationTokenProvider = "CustomEmailConfirmation";
    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
})
    .AddEntityFrameworkStores<InterGalacticConflictContext>()
    .AddDefaultTokenProviders()
    .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>("CustomEmailConfirmation")
    .AddDefaultUI();
//all tokenss
builder.Services.Configure<DataProtectionTokenProviderOptions>(
    options => options.TokenLifespan = TimeSpan.FromHours(5)
    );
//email tokens confirmation
builder.Services.Configure<CustomEmailConfirmationTokenProviderOptions>(
    options => options.TokenLifespan = TimeSpan.FromDays(3)
    );

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
