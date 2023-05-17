namespace BnbExchangeRatesSystem.Service.Models;

using System;

public sealed record DailyExchangeRate(
    DateTime Date,
    string Name,
    string Code,
    int? PerUnit,
    decimal? RateInBgn,
    decimal? ReverseForOneBgn)
{
    public override string ToString()
    {
        return $"{Date};{Name};{Code};{PerUnit};{RateInBgn};{ReverseForOneBgn}{Environment.NewLine}";
    }
}