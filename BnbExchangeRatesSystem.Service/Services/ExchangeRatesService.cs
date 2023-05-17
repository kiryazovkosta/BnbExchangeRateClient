
namespace BnbExchangeRatesSystem.Service.Services;

using BnbExchangeRatesSystem.Service.Contracts;
using BnbExchangeRatesSystem.Service.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


public class ExchangeRatesService : IExchangeRatesService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IDailyExchangeRatesService _dailyExchangeRatesService;

    public ExchangeRatesService(
        IHttpClientFactory httpClientFactory, 
        IDailyExchangeRatesService dailyExchangeRatesService)
    {
        ArgumentNullException.ThrowIfNull(httpClientFactory, nameof(httpClientFactory));
        ArgumentNullException.ThrowIfNull(dailyExchangeRatesService, nameof(dailyExchangeRatesService));

        _httpClientFactory = httpClientFactory;
        _dailyExchangeRatesService = dailyExchangeRatesService;
    }

    public async Task<IEnumerable<DailyExchangeRate>> GetRates(CancellationToken cancellationToken)
    {
        var client = this._httpClientFactory.CreateClient();
        var response = await client.GetAsync("https://www.bnb.bg/Statistics/StExternalSector/StExchangeRates/StERForeignCurrencies/index.htm?download=csv&search=&lang=BG", cancellationToken);
        var content = await response.Content.ReadAsStringAsync();
        var rates = this._dailyExchangeRatesService.Convert(content);
        return rates;
    }
}
