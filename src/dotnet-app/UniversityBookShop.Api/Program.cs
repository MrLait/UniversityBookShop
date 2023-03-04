using System.Reflection;
using UniversityBookShop.Application;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Mappings;
using UniversityBookShop.Persistence;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
//REGISTER SERVICES HERE
//services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IApplicationDbContext).Assembly));
});

services.AddApplication();
services.AddPersistence(builder.Configuration);
services.AddControllers();

services.AddCors(option =>
{
    option.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
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
    catch (Exception e)
    {
        //ToDo
    }
}
app.UseSwagger();
app.UseSwaggerUI(config =>
{
    config.RoutePrefix = string.Empty;
    config.SwaggerEndpoint("swagger/v1/swagger.json", "University book shop API");
});

app.UseHttpsRedirection();
app.UseCors("AllowAll"); //ToDo
app.MapControllers();
app.Run();