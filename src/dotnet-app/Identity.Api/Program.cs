using Identity.Application.Common.Constants;
using Identity.Persistence;
using IdentityServer4.AccessTokenValidation;

var builder = WebApplication.CreateBuilder(args);
var identityAuthority = builder.Configuration[ApiConstants.Identity.IdentityAuthority];

// Add services to the container.
builder.Services.AddIdentityPersistence(builder.Configuration);
builder.Services.AddAuthentication(
      IdentityServerAuthenticationDefaults.AuthenticationScheme)
      .AddIdentityServerAuthentication(options =>
      {
          options.Authority = identityAuthority;
          //options.ApiName = "Api";
          options.RequireHttpsMetadata = false;
      });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(ApiConstants.Policy.ApiScope, policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim(ApiConstants.Identity.ClaimTypeScope, ApiConstants.Identity.ApiScope);
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{

    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
        SeedData.EnsureSeedData(context, builder.Services);
    }
    catch (Exception m)
    {
        Console.WriteLine(m);
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(config =>
    {
        config.RoutePrefix = string.Empty;
        config.SwaggerEndpoint(ApiConstants.Swagger.Url, ApiConstants.Swagger.Name);
    });
}

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers().RequireAuthorization(ApiConstants.Policy.ApiScope);
});

app.Run();
