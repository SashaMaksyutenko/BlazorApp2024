
// using Microsoft.AspNetCore.Components.Authorization;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Logging;
// using BlazorApp1.Components;
// using BlazorApp1.Components.Account;
// using BlazorApp1.Data;
// using DotNetEnv;
// using BlazorApp1.Repository.IRepository;
// using BlazorApp1.Repository;
// using Radzen;
// using BlazorApp1.Services;
// using Stripe;
// using Microsoft.Extensions.Logging;
// var builder = WebApplication.CreateBuilder(args);

// // Налаштування логування
// builder.Logging.ClearProviders();
// builder.Logging.AddConsole();
// builder.Logging.AddDebug();

// // Завантаження змінних середовища
// DotNetEnv.Env.Load();

// var loggerFactory = LoggerFactory.Create(logging =>
// {
//     logging.AddConsole();
//     logging.AddDebug();
// });
// var logger = loggerFactory.CreateLogger<Program>();

// try
// {
//     // Завантаження рядка підключення
//     var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
//         throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

//     // Налаштування DbContext
//     builder.Services.AddDbContext<ApplicationDbContext>(options =>
//         options.UseSqlServer(connectionString)
//                .EnableSensitiveDataLogging() // Для більш детальних логів
//                .EnableDetailedErrors(),      // Показує більше інформації про помилки
//         ServiceLifetime.Transient);

//     logger.LogInformation("Database connection configured successfully.");
// }
// catch (Exception ex)
// {
//     logger.LogError(ex, "Error during database connection configuration.");
//     throw;
// }

// // Додавання сервісів
// builder.Services.AddDatabaseDeveloperPageExceptionFilter();
// builder.Services.AddRazorComponents()
//     .AddInteractiveServerComponents();
// builder.Services.AddCascadingAuthenticationState();
// builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
// builder.Services.AddScoped<IProductRepository, ProductRepository>();
// builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
// builder.Services.AddScoped<IOrderRepository, OrderRepository>();
// builder.Services.AddScoped<IdentityUserAccessor>();
// builder.Services.AddScoped<IdentityRedirectManager>();
// builder.Services.AddRadzenComponents();
// builder.Services.AddSingleton<SharedStateService>();
// builder.Services.AddScoped<PaymentService>();
// builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();
// builder.Services.AddAuthentication(options =>
//     {
//         options.DefaultScheme = IdentityConstants.ApplicationScheme;
//         options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
//     })
//     .AddFacebook(options =>
//     {
//         options.AppId = Env.GetString("FACEBOOK_APP_ID");
//         options.AppSecret = Env.GetString("FACEBOOK_APP_SECRET");
//     })
//     .AddMicrosoftAccount(options =>
//     {
//         options.ClientId = Env.GetString("MICROSOFT_CLIENT_ID");
//         options.ClientSecret = Env.GetString("MICROSOFT_CLIENT_SECRET");
//     })
//     .AddGoogle(options =>
//     {
//         options.ClientId = Env.GetString("GOOGLE_CLIENT_ID");
//         options.ClientSecret = Env.GetString("GOOGLE_CLIENT_SECRET");
//     })
//     .AddIdentityCookies();

// builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
//     .AddRoles<IdentityRole>()
//     .AddEntityFrameworkStores<ApplicationDbContext>()
//     .AddSignInManager()
//     .AddDefaultTokenProviders();
// builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

// var app = builder.Build();
// StripeConfiguration.ApiKey= builder.Configuration.GetSection("StripeApiKey").Value;
// try
// {
//     // Налаштування HTTP-запитів
//     if (app.Environment.IsDevelopment())
//     {
//         app.UseMigrationsEndPoint();
//     }
//     else
//     {
//         app.UseExceptionHandler("/Error", createScopeForErrors: true);
//         app.UseHsts();
//     }

//     // HTTPS Redirection з логуванням
//     try
//     {
//         app.UseHttpsRedirection();
//     }
//     catch (Exception ex)
//     {
//         logger.LogError(ex, "Error during HTTPS redirection configuration.");
//         throw;
//     }
//     app.UseAntiforgery();
//     app.UseAuthentication();
//     app.UseAuthorization();
//     app.MapStaticAssets();
//     app.MapRazorComponents<App>()
//         .AddInteractiveServerRenderMode();
//     // Додаткові ендпоінти для Identity
//     app.MapAdditionalIdentityEndpoints();

//     logger.LogInformation("Application started successfully.");
//     app.Run();
// }
// catch (Exception ex)
// {
//     logger.LogCritical(ex, "Application failed to start.");
//     throw;
// }


using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using BlazorApp1.Components;
using BlazorApp1.Components.Account;
using BlazorApp1.Data;
using DotNetEnv;
using BlazorApp1.Repository.IRepository;
using BlazorApp1.Repository;
using Radzen;
using BlazorApp1.Services;
using Stripe;
var builder = WebApplication.CreateBuilder(args);
DotNetEnv.Env.Load();
// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();
builder.Services.AddRadzenComponents();
builder.Services.AddSingleton<SharedStateService>();
builder.Services.AddScoped<PaymentService>();
builder.Services.AddAuthentication(options =>
	{
		options.DefaultScheme = IdentityConstants.ApplicationScheme;
		options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
	})//https://developers.google.com/identity/oauth2/web/guides/get-google-api-clientid

    .AddFacebook(options =>
    {
        options.AppId = Env.GetString("FACEBOOK_APP_ID");
        options.AppSecret = Env.GetString("FACEBOOK_APP_SECRET");
    })
    .AddMicrosoftAccount(options =>
    {
        options.ClientId = Env.GetString("MICROSOFT_CLIENT_ID");
        options.ClientSecret = Env.GetString("MICROSOFT_CLIENT_SECRET");
    })
    .AddGoogle(options =>
    {
        options.ClientId = Env.GetString("GOOGLE_CLIENT_ID");
        options.ClientSecret = Env.GetString("GOOGLE_CLIENT_SECRET");
    })
.AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(connectionString),ServiceLifetime.Transient);
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
	.AddRoles<IdentityRole>()
	.AddEntityFrameworkStores<ApplicationDbContext>()
	.AddSignInManager()
	.AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

var app = builder.Build();
StripeConfiguration.ApiKey= builder.Configuration.GetSection("StripeApiKey").Value;
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
}
else
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();