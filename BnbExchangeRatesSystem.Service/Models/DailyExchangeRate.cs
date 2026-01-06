namespace BnbExchangeRatesSystem.Service.Models;

using System;

public sealed record DailyExchangeRate(
    DateTime Date,
    string Code,
    decimal RateInBgn)
{
    public override string ToString()
    {
        return $"{Date:yyyy-MM-dd}\t{Code}\t{RateInBgn}\t\t{RoundTo4SignificantDigits(1.00M/RateInBgn)}{Environment.NewLine}";
    }

    private decimal RoundTo4SignificantDigits(decimal value)
    {
        if (value == 0)
            return 0;

        int scale = (int)Math.Floor(Math.Log10((double)Math.Abs(value)));
        int decimals = Math.Max(0, 4 - scale - 1);

        return Math.Round(value, decimals, MidpointRounding.AwayFromZero);
    }
}