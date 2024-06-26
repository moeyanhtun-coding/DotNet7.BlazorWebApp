using System.Collections.Immutable;
using DotNet7.BlazorWebApp.WebApi.Database;
using DotNet7.BlazorWebApp.WebApi.Features.Blog;
using Microsoft.EntityFrameworkCore;

namespace DotNet7.BlazorWebApp.WebApi;

public static class ModularServices
{
    public static IServiceCollection AddServices(this IServiceCollection service, WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext(builder).AddDataAccess().AddBusinessLogic();
        return service;
    }

    public static IServiceCollection AddDataAccess(this IServiceCollection service)
    {
        return service.AddScoped<DA_Blog>();
    }

    public static IServiceCollection AddBusinessLogic(this IServiceCollection service)
    {
        return service.AddScoped<BL_BLog>();
    }

    public static IServiceCollection AddDbContext(this IServiceCollection service, WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DbConnection");
        builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString),
            ServiceLifetime.Transient, ServiceLifetime.Transient);
        return service;
    }
}