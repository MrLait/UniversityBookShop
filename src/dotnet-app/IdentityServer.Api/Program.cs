using Identity.Persistence;
using IdentityServer.Persistence;
using IdentityServer.Api.Constants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIdentityPersistence(builder.Configuration);
builder.Services.AddIdentityServerPersistence(builder.Configuration);

builder.Services.AddAuthentication();


var app = builder.Build();
// REGISTER MIDDLEWARE HERE

//SyncData.InitializeDatabase(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(config =>
    {
        config.RoutePrefix = string.Empty;
        config.SwaggerEndpoint(SwaggerConstants.Url, SwaggerConstants.Name);
    });
}

app.UseStaticFiles();
app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});


app.Run();


//app.MapGroup("/account").MapIdentityApi<ApplicationUser>();

//app.MapIdentityApi<IdentityUser>();

// Add-Migration InitialPersistedGranMigration -c PersistedGrantDbContext -o Migrations/IdentityServer/PersistedGrantDb
// Add-Migration InitialConfigurationMigration -c ConfigurationDbContext -o Migrations/IdentityServer/ConfigurationDb
// Add-Migration InitialApplicationDb -c ApplicationDbContext -o Migrations/IdentityServer/ApplicationDb

// Update-Database InitialPersistedGranMigration -Context PersistedGrantDbContext
// Update-Database InitialConfigurationMigration -Context ConfigurationDbContext
// Update-Database InitialApplicationDb -Context ApplicationDbContext

// connect/token?grant_type=password&username=alice&password=Pass123$&scope=api1&client_id=external


