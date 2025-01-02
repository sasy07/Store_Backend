using Store.Application;
using Store.Infrastructure;
using Store.WebApi;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.AddWebServiceCollection();

var app = builder.Build();
await app.AddWebAppService().ConfigureAwait(false);    