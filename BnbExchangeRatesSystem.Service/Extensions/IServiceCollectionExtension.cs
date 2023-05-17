namespace BnbExchangeRatesSystem.Service.Extensions;

using BnbExchangeRatesSystem.Service.Contracts;
using BnbExchangeRatesSystem.Service.Services;

public static class IServiceCollectionExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IJokeService, JokeService>();

        return services;
    }
}