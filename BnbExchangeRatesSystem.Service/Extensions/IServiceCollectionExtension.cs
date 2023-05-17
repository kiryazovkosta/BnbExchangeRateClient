namespace BnbExchangeRatesSystem.Service.Extensions;

using BnbExchangeRatesSystem.Service.Contracts;
using BnbExchangeRatesSystem.Service.Services;

public static class IServiceCollectionExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IJokeService, JokeService>();
        services.AddSingleton<IExchangeRatesService, ExchangeRatesService>();
        services.AddSingleton<IDailyExchangeRatesService, DailyExchangeRatesService>();

        return services;
    }
}