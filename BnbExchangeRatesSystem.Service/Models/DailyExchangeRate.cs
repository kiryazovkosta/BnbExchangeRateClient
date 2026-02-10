namespace BnbExchangeRatesSystem.Service.Models;

using System;

public sealed record DailyExchangeRate(
    DateTime Date,
    string Code,
    decimal RateInBgn)
{
    public override string ToString()
    {
        return $"{Date:yyyy-MM-dd}\t{Code}\t{RateInBgn}\t\t{RoundToSignificantDigits(1.00M / RateInBgn)}{Environment.NewLine}";
    }

    private static decimal RoundToSignificantDigits(decimal value)
    {
        if (value == 0m)
        {
            return 0m;
        }


        var abs = Math.Abs(value);

        if (abs >= 1m)
        {
            return Math.Round(value, 4, MidpointRounding.AwayFromZero);
        }


        var scale = (int)Math.Floor(Math.Log10((double)abs));
        var decimals = Math.Max(0, 4 - scale - 1);

        return Math.Round(value, decimals, MidpointRounding.AwayFromZero);
    }
}