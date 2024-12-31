using Microsoft.EntityFrameworkCore;
using Store.Infrastructure.Persistence;

namespace Store.WebApi;

public static class ConfigureService
{
    public static IServiceCollection AddWebServiceCollection(this WebApplicationBuilder builder)
    {
       
        return builder.Services;
    }
}