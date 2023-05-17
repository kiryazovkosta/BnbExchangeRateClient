namespace BnbExchangeRatesSystem.Service.Contracts;

using BnbExchangeRatesSystem.Service.Models;

public interface IExchangeRatesService
{
    Task<IEnumerable<DailyExchangeRate>> GetRates(CancellationToken cancellationToken = default);
}