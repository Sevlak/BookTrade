using BookTrade.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BookTrade.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<UserService>();

        return services;
    }
}