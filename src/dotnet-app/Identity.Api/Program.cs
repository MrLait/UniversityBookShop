using Identity.Api.Constants;
using Identity.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIdentityPersistence(builder.Configuration);

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
        config.SwaggerEndpoint(SwaggerConstants.Url, SwaggerConstants.Name);
    });
}

app.UseRouting();
app.UseAuthorization();

app.MapDefaultControllerRoute();

app.Run();
