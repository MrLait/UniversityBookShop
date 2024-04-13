using IdentityServer.Api.Constants;
using IdentityServer.Api.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(opt =>
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

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

//app.MapGet("/", () => "Hello World!");

app.Run();


//services.AddIdentityServer()
// .AddApiAuthorization<ApplicationUser, ApplicationDbContext>((config) =>
//  {
//      config.Clients[0].AccessTokenLifetime = 3600
//                });
//services.AddIdentityServer().AddDeve
//.AddApiAuthorization<ApplicationUser, ApplicationDbContext>();
//app.UseIdentityServer();

//services.AddEntityFrameworkSqlite().AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connection));
//services.AddEntityFrameworkSqlite().AddDbContext<ApplicationDbContext>(opt => opt.UseSqlite(builder.Configuration.GetConnectionString("WebApiDatabase")));