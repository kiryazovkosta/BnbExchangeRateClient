using BnbExchangeRatesSystem.Service.Models;
using System.Reflection;

namespace BnbExchangeRatesSystem.UnitTests
{
    public class DailyExchangeRateTests
    {
        private static readonly MethodInfo RoundMethod = typeof(DailyExchangeRate)
            .GetMethod("RoundToSignificantDigits", BindingFlags.NonPublic | BindingFlags.Static)
            ?? throw new InvalidOperationException("Unable to find DailyExchangeRate.RoundToSignificantDigits via reflection.");

        private static decimal Round(decimal value)
            => (decimal)(RoundMethod.Invoke(null, [value]) ?? throw new InvalidOperationException("Round method returned null."));

        [Theory]
        [InlineData("1.1750", "0.8511")]
        [InlineData("1.1664", "0.8573")]
        [InlineData("1.1707", "0.8542")]
        [InlineData("1.1684", "0.8559")]
        [InlineData("1.1675", "0.8565")]
        [InlineData("1.1642", "0.8590")]
        [InlineData("1.1692", "0.8553")]
        [InlineData("1.1654", "0.8581")]
        [InlineData("1.1651", "0.8583")]
        [InlineData("1.1624", "0.8603")]
        [InlineData("1.1617", "0.8608")]
        [InlineData("1.1631", "0.8598")]
        [InlineData("1.1728", "0.8527")]
        [InlineData("1.1739", "0.8519")]
        [InlineData("1.1706", "0.8543")]
        [InlineData("1.1742", "0.8516")]
        [InlineData("1.1836", "0.8449")]
        [InlineData("1.1929", "0.8383")]
        [InlineData("1.1974", "0.8351")]
        [InlineData("1.1968", "0.8356")]
        [InlineData("1.1919", "0.8390")]
        [InlineData("1.1840", "0.8446")]
        [InlineData("1.1801", "0.8474")]
        [InlineData("1.1820", "0.8460")]
        [InlineData("1.1798", "0.8476")]
        [InlineData("1.1794", "0.8479")]
        [InlineData("1.1886", "0.8413")]
        public void Round_USD(string eur2usd, string usd2eur)
        {
            decimal e2c = Convert.ToDecimal(eur2usd);
            decimal c2e = Convert.ToDecimal(usd2eur);
            Assert.Equal(c2e, Round(1.00m / e2c));
        }

        [Theory]
        [InlineData("0.87260", "1.1460")]
        [InlineData("0.86760", "1.1526")]
        [InlineData("0.86630", "1.1543")]
        [InlineData("0.86640", "1.1542")]
        [InlineData("0.86870", "1.1511")]
        [InlineData("0.86770", "1.1525")]
        [InlineData("0.86740", "1.1529")]
        [InlineData("0.86600", "1.1547")]
        [InlineData("0.86680", "1.1537")]
        [InlineData("0.86740", "1.1529")]
        [InlineData("0.86700", "1.1534")]
        [InlineData("0.86710", "1.1533")]
        [InlineData("0.87220", "1.1465")]
        [InlineData("0.87440", "1.1436")]
        [InlineData("0.87220", "1.1465")]
        [InlineData("0.86810", "1.1519")]
        [InlineData("0.86750", "1.1527")]
        [InlineData("0.86830", "1.1517")]
        [InlineData("0.86850", "1.1514")]
        [InlineData("0.86620", "1.1545")]
        [InlineData("0.86620", "1.1545")]
        [InlineData("0.86580", "1.1550")]
        [InlineData("0.86230", "1.1597")]
        [InlineData("0.86160", "1.1606")]
        [InlineData("0.86910", "1.1506")]
        [InlineData("0.86790", "1.1522")]
        [InlineData("0.87010", "1.1493")]
        public void Round_GBP(string eur2gbp, string gbp2eur)
        {
            decimal e2c = Convert.ToDecimal(eur2gbp);
            decimal c2e = Convert.ToDecimal(gbp2eur);
            Assert.Equal(c2e, Round(1.00m / e2c));
        }

        [Theory]
        [InlineData("184.09", "0.005432")]
        [InlineData("182.93", "0.005467")]
        [InlineData("183.14", "0.005460")]
        [InlineData("182.91", "0.005467")]
        [InlineData("182.97", "0.005465")]
        [InlineData("183.52", "0.005449")]
        [InlineData("184.42", "0.005422")]
        [InlineData("185.12", "0.005402")]
        [InlineData("184.82", "0.005411")]
        [InlineData("184.31", "0.005426")]
        [InlineData("183.67", "0.005445")]
        [InlineData("183.69", "0.005444")]
        [InlineData("185.18", "0.005400")]
        [InlineData("185.23", "0.005399")]
        [InlineData("185.88", "0.005380")]
        [InlineData("185.71", "0.005385")]
        [InlineData("182.52", "0.005479")]
        [InlineData("182.92", "0.005467")]
        [InlineData("182.76", "0.005472")]
        [InlineData("183.48", "0.005450")]
        [InlineData("183.59", "0.005447")]
        [InlineData("183.59", "0.005447")]
        [InlineData("183.92", "0.005437")]
        [InlineData("185.15", "0.005401")]
        [InlineData("185.11", "0.005402")]
        [InlineData("185.27", "0.005398")]
        [InlineData("185.65", "0.005386")]
        public void Round_JPY(string eur2jpy, string jpy2eur)
        {
            decimal e2c = Convert.ToDecimal(eur2jpy);
            decimal c2e = Convert.ToDecimal(jpy2eur);
            Assert.Equal(c2e, Round(1.00m / e2c));
        }

        [Theory]
        [InlineData("1696.94", "0.0005893")]
        [InlineData("1690.44", "0.0005916")]
        [InlineData("1695.93", "0.0005896")]
        [InlineData("1691.47", "0.0005912")]
        [InlineData("1695.57", "0.0005898")]
        [InlineData("1699.55", "0.0005884")]
        [InlineData("1715.11", "0.0005831")]
        [InlineData("1717.89", "0.0005821")]
        [InlineData("1719.00", "0.0005817")]
        [InlineData("1706.77", "0.0005859")]
        [InlineData("1711.10", "0.0005844")]
        [InlineData("1713.48", "0.0005836")]
        [InlineData("1731.99", "0.0005774")]
        [InlineData("1719.32", "0.0005816")]
        [InlineData("1718.11", "0.0005820")]
        [InlineData("1723.20", "0.0005803")]
        [InlineData("1713.58", "0.0005836")]
        [InlineData("1719.21", "0.0005817")]
        [InlineData("1710.88", "0.0005845")]
        [InlineData("1712.42", "0.0005840")]
        [InlineData("1719.47", "0.0005816")]
        [InlineData("1719.74", "0.0005815")]
        [InlineData("1709.44", "0.0005850")]
        [InlineData("1720.70", "0.0005812")]
        [InlineData("1728.58", "0.0005785")]
        [InlineData("1730.68", "0.0005778")]
        [InlineData("1737.79", "0.0005754")]
        public void Round_KRW(string eur2krw, string krw2eur)
        {
            decimal e2c = Convert.ToDecimal(eur2krw);
            decimal c2e = Convert.ToDecimal(krw2eur);
            Assert.Equal(c2e, Round(1.00m / e2c));
        }

        [Theory]
        [InlineData("11.8430", "0.08444")]
        [InlineData("11.7795", "0.08489")]
        [InlineData("11.7285", "0.08526")]
        [InlineData("11.7585", "0.08504")]
        [InlineData("11.7935", "0.08479")]
        [InlineData("11.7765", "0.08491")]
        [InlineData("11.7445", "0.08515")]
        [InlineData("11.7560", "0.08506")]
        [InlineData("11.7330", "0.08523")]
        [InlineData("11.7200", "0.08532")]
        [InlineData("11.7203", "0.08532")]
        [InlineData("11.7295", "0.08526")]
        [InlineData("11.7155", "0.08536")]
        [InlineData("11.6365", "0.08594")]
        [InlineData("11.5760", "0.08639")]
        [InlineData("11.5420", "0.08664")]
        [InlineData("11.6015", "0.08620")]
        [InlineData("11.5670", "0.08645")]
        [InlineData("11.5230", "0.08678")]
        [InlineData("11.4180", "0.08758")]
        [InlineData("11.3885", "0.08781")]
        [InlineData("11.4655", "0.08722")]
        [InlineData("11.4220", "0.08755")]
        [InlineData("11.3995", "0.08772")]
        [InlineData("11.4740", "0.08715")]
        [InlineData("11.4695", "0.08719")]
        [InlineData("11.4290", "0.08750")]
        public void Round_NOK(string eur2nok, string nok2eur)
        {
            decimal e2c = Convert.ToDecimal(eur2nok);
            decimal c2e = Convert.ToDecimal(nok2eur);
            Assert.Equal(c2e, Round(1.00m / e2c));
        }
    }
}