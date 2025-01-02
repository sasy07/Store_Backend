using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Store.Application;

public static class ConfigureService
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}