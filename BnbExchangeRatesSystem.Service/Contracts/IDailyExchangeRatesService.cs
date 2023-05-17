namespace BnbExchangeRatesSystem.Service.Contracts;

using BnbExchangeRatesSystem.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IDailyExchangeRatesService
{
    IEnumerable<DailyExchangeRate> Convert(string ratesAsString);
}