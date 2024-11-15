using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Radzen;
using BlazorApp2024.Areas.Identity;
using BlazorApp2024.Data;
using BlazorApp2024.Repository.IRepository;
using BlazorApp2024.Repository;
using Microsoft.AspNetCore.Identity.UI.Services;
using BlazorApp2024.Services;
using DotNetEnv;
var builder = WebApplication.CreateBuilder(args);
DotNetEnv.Env.Load();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => 
    options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();
builder.Services.AddAuthentication(
    options =>
	{
		options.DefaultScheme = IdentityConstants.ApplicationScheme;
		options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
	}
)
    .AddFacebook(options =>
    {
        options.AppId = Env.GetString("FACEBOOK_APP_ID");
        options.AppSecret = Env.GetString("FACEBOOK_APP_SECRET");
    })
    .AddMicrosoftAccount(
        options =>
    {
        options.ClientId = Env.GetString("MICROSOFT_CLIENT_ID");
        options.ClientSecret = Env.GetString("MICROSOFT_CLIENT_SECRET");
    }
    ).AddGoogle(
        options =>
    {
        options.ClientId = Env.GetString("GOOGLE_CLIENT_ID");
        options.ClientSecret = Env.GetString("GOOGLE_CLIENT_SECRET");
    }
    );
builder.Services.AddScoped<SignInManager<ApplicationUser>>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddRadzenComponents();
builder.Services.AddSingleton<SharedStateService>();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<ApplicationUser>>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<IEmailSender, IdentityNoOpEmailSender>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();
