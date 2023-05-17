using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnbExchangeRatesSystem.Service.Extensions
{
    public static class StringExtensions
    {
        public static int? ToNulableInteger(this string? str) 
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return null;
            }

            if (int.TryParse(str, out int result))
            {
                return result;
            }

            return null;
        }

        public static decimal? ToNulableDecimal(this string? str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return null;
            }

            if (decimal.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture,  out decimal result))
            {
                return result;
            }

            return null;
        }
    }
}
