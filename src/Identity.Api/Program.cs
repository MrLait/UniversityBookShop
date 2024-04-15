using Identity.Persistence;

var seed = args.Contains("/seed");
if (seed)
{
    args = args.Except(["/seed"]).ToArray();
}

var builder = WebApplication.CreateBuilder(args);

if (seed)
{
    SeedData.EnsureSeedData(builder.Configuration);
}

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIdentityPersistence(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
