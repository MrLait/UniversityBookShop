using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using System.Reflection;
using UniversityBookShop.Api.Constants;
using UniversityBookShop.Api.Filters;
using UniversityBookShop.Application;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Mappings;
using UniversityBookShop.Persistence;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

//REGISTER SERVICES HERE
services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IApplicationDbContext).Assembly));
});

services.AddApplication();
services.AddPersistence(builder.Configuration);
services.AddControllers(configure: options =>
    options.Filters.Add<ApiExceptionFilterAttribute>());

var paginationHeaderCorsPolicy = "PaginationHeader";

services.AddCors(option =>
{
    option.AddPolicy(paginationHeaderCorsPolicy, policy =>
    {
        policy.AllowAnyHeader().WithExposedHeaders("x-pagination");
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
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
    catch (Exception)
    {
        //ToDo
    }
}

app.UseSwagger();
app.UseSwaggerUI(config =>
{
    config.RoutePrefix = string.Empty;
    config.SwaggerEndpoint(SwaggerConstants.Url, SwaggerConstants.Name);
});


app.UseHttpsRedirection();
app.UseCors(paginationHeaderCorsPolicy); //ToDo


app.MapControllers();
app.Run();