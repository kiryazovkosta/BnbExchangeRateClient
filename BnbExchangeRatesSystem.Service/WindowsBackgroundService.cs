using BnbExchangeRatesSystem.Service.Contracts;

namespace BnbExchangeRatesSystem.Service;

public sealed class WindowsBackgroundService : BackgroundService
{
    private readonly IExchangeRatesService _exchangeRatesService;
    private readonly ILogger<WindowsBackgroundService> _logger;

    public WindowsBackgroundService(
        IExchangeRatesService exchangeRatesService,
        ILogger<WindowsBackgroundService> logger)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(exchangeRatesService));
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(logger));

        _exchangeRatesService = exchangeRatesService;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var rates = await this._exchangeRatesService.GetRates(stoppingToken);
                if (rates is not null)
                {
                    rates.ToList().ForEach(rate => _logger.LogWarning("{Exchange Rates}", rate));
                }
                _logger.LogWarning("{Exchange Rates}", rates);

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
        catch (TaskCanceledException)
        {

        }
        catch (Exception ex)
        {
            this._logger.LogError(ex, "{Message}", ex!.Message);
            Environment.Exit(1);
        }
    }
}