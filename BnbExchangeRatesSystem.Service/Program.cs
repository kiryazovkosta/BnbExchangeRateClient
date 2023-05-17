using BnbExchangeRatesSystem.Service;
using BnbExchangeRatesSystem.Service.Extensions;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services
            .AddHostedService<WindowsBackgroundService>()
            .AddServices();
    })
    .Build();

host.Run();
