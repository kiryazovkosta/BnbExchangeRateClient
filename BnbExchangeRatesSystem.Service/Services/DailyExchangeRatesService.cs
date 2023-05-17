namespace BnbExchangeRatesSystem.Service.Services
{
    using BnbExchangeRatesSystem.Service.Contracts;
    using BnbExchangeRatesSystem.Service.Extensions;
    using BnbExchangeRatesSystem.Service.Models;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;

    public class DailyExchangeRatesService : IDailyExchangeRatesService
    {
        public IEnumerable<DailyExchangeRate> Convert(string ratesAsString)
        {
            var rates = ratesAsString.Split("\n", StringSplitOptions.RemoveEmptyEntries)
                .Select(line => line.Split(','))
                .Where(line => line.Length == 6)
                .Skip(1)
                .Select(line => new DailyExchangeRate(
                    DateTime.ParseExact(line[0], "dd.MM.yyyy", CultureInfo.InvariantCulture),
                    line[1].Trim(), 
                    line[2].Trim(),
                    line[3].ToNulableInteger(), 
                    line[4].ToNulableDecimal(),
                    line[5].ToNulableDecimal())
                );

            return rates;
        }
    }
}
