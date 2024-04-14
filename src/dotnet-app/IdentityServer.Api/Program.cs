using Identity.Persistence;
using IdentityServer.Persistence;
using IdentityServer.Api.Constants;

//var seed = args.Contains("/seed");
//if (seed)
//{
//    args = args.Except(new[] { "/seed" }).ToArray();
//}

var builder = WebApplication.CreateBuilder(args);

//if (seed)
//{
//    //Log.Information("Seeding database...");
//    var connectionString = builder.Configuration.GetConnectionString("IdentityConnection");
//    SeedData.EnsureSeedData(connectionString);
//    //Log.Information("Done seeding database.");
//}


//var migrationsAssembly = typeof(Program).GetTypeInfo().Assembly.GetName().Name;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIdentityPersistence(builder.Configuration);
builder.Services.AddIdentityServerPersistence(builder.Configuration);

//builder.Services.AddDbContext<ApplicationDbContext>(opt =>
//    opt.UseSqlite(builder.Configuration.GetConnectionString("IdentityConnection")));

//builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
//    //.AddApiEndpoints()
//    .AddEntityFrameworkStores<ApplicationDbContext>()
//    .AddDefaultTokenProviders();

//builder.Services.AddIdentityServer(options =>
//    {
//        options.Events.RaiseErrorEvents = true;
//        options.Events.RaiseInformationEvents = true;
//        options.Events.RaiseFailureEvents = true;
//        options.Events.RaiseSuccessEvents = true;

//        // see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
//        options.EmitStaticAudienceClaim = true;
//    })
//     .AddConfigurationStore(options =>
//     {
//         options.ConfigureDbContext = b => b.UseSqlite(builder.Configuration.GetConnectionString("IdentityServerConnection"),
//             sql => sql.MigrationsAssembly(migrationsAssembly));
//     })
//     .AddOperationalStore(options =>
//     {
//         options.ConfigureDbContext = b => b.UseSqlite(builder.Configuration.GetConnectionString("IdentityServerConnection"),
//             sql => sql.MigrationsAssembly(migrationsAssembly));
//     })
//     .AddAspNetIdentity<ApplicationUser>()
//     .AddDeveloperSigningCredential();

builder.Services.AddAuthentication();

//builder.Services.AddIdentityApiEndpoints<IdentityUser>()
//    .AddEntityFrameworkStores<ApplicationDbContext>();


var app = builder.Build();
// REGISTER MIDDLEWARE HERE

SyncData.InitializeDatabase(app);

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
app.MapDefaultControllerRoute();

//app.MapGroup("/account").MapIdentityApi<ApplicationUser>();

//app.MapIdentityApi<IdentityUser>();

app.Run();

// Add-Migration InitialPersistedGranMigration -c PersistedGrantDbContext -o Migrations/IdentityServer/PersistedGrantDb
// Add-Migration InitialConfigurationMigration -c ConfigurationDbContext -o Migrations/IdentityServer/ConfigurationDb
// Add-Migration InitialApplicationDb -c ApplicationDbContext -o Migrations/IdentityServer/ApplicationDb

// Update-Database InitialPersistedGranMigration -Context PersistedGrantDbContext
// Update-Database InitialConfigurationMigration -Context ConfigurationDbContext
// Update-Database InitialApplicationDb -Context ApplicationDbContext

// connect/token?grant_type=password&username=alice&password=Pass123$&scope=api1&client_id=external


