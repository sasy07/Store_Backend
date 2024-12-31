using Microsoft.EntityFrameworkCore;
using Store.Infrastructure;
using Store.Infrastructure.Persistence;
using Store.Infrastructure.Persistence.SeedData;
using Store.WebApi;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region configuration

builder.AddWebServiceCollection();
builder.Services.AddInfrastructureServices(builder.Configuration);

#endregion



var app = builder.Build();
var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var loggerFactory = services.GetRequiredService<ILoggerFactory>();
var context = services.GetRequiredService<ApplicationDbContext>();

#region auto migration

try
{
    await context.Database.MigrateAsync();
    await GenerateFakeData.SeedDataAsync(context, loggerFactory);
}
catch (Exception e)
{
   var logger = loggerFactory.CreateLogger<Program>();
   logger.LogError(e, "migration error");
}

#endregion


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();
app.MapControllers();

app.Run();