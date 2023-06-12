using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using GJM.Areas.Identity;
using GJM.Data;
using GJM.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<User>>();
builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
        options.LicenseKey = "CjxRA3F4NAk9WwNwejE1BlEAc3o1DjxSAXF+Nwo6bjoNJ2ZdYhBVCCo/CjhQPUsNalV8Al44B2ECAWllMit3cWhZPUsqM1M8GwZ1eUtueyhEcCR/QmIlfjsndFl6W3p4CEh/NABiJDZccX0uXzQCUW52J1MxIm13WBFIDj1RbiM1UhYPVQ9pWgkVAmdTeRdzOSt3XHQ7BygUXwpmC2hwYUhJRCpJDH9xc04FZwkhaUJkFn0XGF1WbzZTIHxPWTQOAjthRFE4NwgXCDZdfhkIDSluTUotUxQsYA50LXctFk1uWCJDcSc8CkI7YyMlf08x";
    })
    .AddBootstrapProviders()
    .AddFontAwesomeIcons();
builder.Services.AddScoped<ModalService>();
builder.Services.AddSingleton<EventService>();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
