using IdentityServer.Api.Constants;
using IdentityServer.Api.Data;
using IdentityServer.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var migrationsAssembly = typeof(Program).GetTypeInfo().Assembly.GetName().Name;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(opt =>
    opt.UseSqlite(builder.Configuration.GetConnectionString("IdentityConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddIdentityServer()
     .AddConfigurationStore(options =>
     {
         options.ConfigureDbContext = b => b.UseSqlite(builder.Configuration.GetConnectionString("IdentityServerConnection"),
             sql => sql.MigrationsAssembly(migrationsAssembly));
     })
     .AddOperationalStore(options =>
     {
         options.ConfigureDbContext = b => b.UseSqlite(builder.Configuration.GetConnectionString("IdentityServerConnection"),
             sql => sql.MigrationsAssembly(migrationsAssembly));
     })
     .AddAspNetIdentity<ApplicationUser>();


builder.Services.AddAuthorization();

builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();


var app = builder.Build();
// REGISTER MIDDLEWARE HERE

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(config =>
    {
        config.RoutePrefix = string.Empty;
        config.SwaggerEndpoint(SwaggerConstants.Url, SwaggerConstants.Name);
    });
}

app.MapIdentityApi<IdentityUser>();

app.Run();

// Add-Migration InitialPersistedGranMigration -c PersistedGrantDbContext -o Migrations/IdentityServer/PersistedGrantDb
// Add-Migration InitialConfigurationMigration -c ConfigurationDbContext -o Migrations/IdentityServer/ConfigurationDb
// Add-Migration InitialApplicationMigration -c ApplicationDbContext -o Migrations/IdentityServer/ApplicationDb

// Update-Database InitialPersistedGranMigration -Context PersistedGrantDbContext
// Update-Database InitialConfigurationMigration -Context ConfigurationDbContext
// Update-Database InitialApplicationMigration -Context ApplicationDbContext