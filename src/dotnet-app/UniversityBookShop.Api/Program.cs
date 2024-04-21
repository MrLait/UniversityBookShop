using IdentityServer4.AccessTokenValidation;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using UniversityBookShop.Api.Filters;
using UniversityBookShop.Application;
using UniversityBookShop.Application.Common.Constants;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Mappings;
using UniversityBookShop.Persistence;

var builder = WebApplication.CreateBuilder(args);
var identityAuthority = builder.Configuration[ApiConstants.Identity.IdentityAuthority];
var services = builder.Services;

//REGISTER SERVICES HERE
services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IApplicationDbContext).Assembly));
});

services.AddApplication();
services.AddPersistence(builder.Configuration);

services.AddAuthentication(
    IdentityServerAuthenticationDefaults.AuthenticationScheme)
    .AddJwtBearer(IdentityServerAuthenticationDefaults.AuthenticationScheme, options =>
    {
        options.Authority = identityAuthority;
        //options.ApiName = $"{serviceAddressOptions.IdentityServer}/resources";
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters() { ValidateAudience = false };
    });

services.AddAuthorization(options =>
{
    options.AddPolicy(ApiConstants.Policy.Authorization, policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim(ApiConstants.Identity.ClaimTypeScope, ApiConstants.Identity.WebScope);
    });
});

services.AddControllers(configure: options =>
    options.Filters.Add<ApiExceptionFilterAttribute>());

services.AddCors(option =>
{
    option.AddPolicy(ApiConstants.Policy.Cors, policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

services.AddSwaggerGen(config =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    config.IncludeXmlComments(xmlPath);
});
services.AddFluentValidationRulesToSwagger();

var app = builder.Build();

// REGISTER MIDDLEWARE HERE
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
        DbInitializer.Initializer(context);
    }
    catch (Exception message)
    {
        Console.WriteLine(message); //TODO: V5621 https://pvs-studio.ru/ru/docs/warnings/v5621/ Error message contains potentially sensitive data, in 'message', that may be exposed.
    }
}

app.UseSwagger();
app.UseSwaggerUI(config =>
{
    config.RoutePrefix = string.Empty;
    config.SwaggerEndpoint(ApiConstants.Swagger.Url, ApiConstants.Swagger.Name);
});

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors(ApiConstants.Policy.Cors);

app.MapControllers().RequireAuthorization(ApiConstants.Policy.Authorization); ;
app.Run();
