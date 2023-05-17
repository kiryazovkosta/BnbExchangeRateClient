using BnbExchangeRatesSystem.Service.Contracts;

namespace BnbExchangeRatesSystem.Service;

public sealed class WindowsBackgroundService : BackgroundService
{
    private readonly IJokeService _jokeService;
    private readonly ILogger<WindowsBackgroundService> _logger;

    public WindowsBackgroundService(
        IJokeService jokeService,
        ILogger<WindowsBackgroundService> logger)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(jokeService));
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(logger));
        
        _jokeService = jokeService;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                string joke = this._jokeService.GetJoke();
                _logger.LogWarning("{Joke", joke);

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