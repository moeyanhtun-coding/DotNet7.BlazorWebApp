using DotNet7.BlazorWebApp.BlazorServerApp.Database;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace DotNet7.BlazorWebApp.BlazorServerApp;

public static class ModularServices
{
    public static IServiceCollection AddServices(this IServiceCollection services, WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext(builder);
        return services;
    }
    public static IServiceCollection AddDbContext(this IServiceCollection services, WebApplicationBuilder builder)
    {
        string connectionString = builder.Configuration.GetConnectionString("DbConnection")!;
        services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlServer(connectionString);
        },ServiceLifetime.Transient,ServiceLifetime.Transient);
        return services;
    }
}
