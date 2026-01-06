namespace BnbExchangeRatesSystem.Service.Services
{
    using BnbExchangeRatesSystem.Service.Contracts;
    using BnbExchangeRatesSystem.Service.Extensions;
    using BnbExchangeRatesSystem.Service.Models;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Xml.Linq;
    using System.Xml.Serialization;

    public class DailyExchangeRatesService : IDailyExchangeRatesService
    {
        private static readonly XNamespace EcbNs = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref";

        public IEnumerable<DailyExchangeRate> Convert(Stream ratesAsStream)
        {
            ArgumentNullException.ThrowIfNull(ratesAsStream, nameof(ratesAsStream));

            XName cubeRootName = XName.Get("Cube");
            XDocument doc = XDocument.Load(ratesAsStream);
            if (doc.Root is null)
            {
                throw new ArgumentException("Invalid exchange rates file");
            }

            XElement? cubeRootElement = doc.Root.Element(EcbNs + "Cube")?.Element(EcbNs + "Cube");
            if (cubeRootElement is null)
            {
                throw new ArgumentException("Invalid exchange rates file");
            }

            Console.WriteLine(cubeRootElement.ToString());

            var serializer = new XmlSerializer(
                typeof(CubeRatesList),
                new XmlRootAttribute("Cube") { Namespace = EcbNs.NamespaceName });
            CubeRatesList? rates = null; 
            using var reader = new StringReader(cubeRootElement.ToString());
            rates = serializer.Deserialize(reader) as CubeRatesList;

            if (rates is null || rates.Time is null || rates.Rates is null || rates.Rates.Length == 0)
            {
                return [];
            }

            var ratesDate = DateTime.ParseExact(rates.Time, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var result = new List<DailyExchangeRate>();
            foreach (var item in rates.Rates)
            {
                result.Add(new DailyExchangeRate(ratesDate, item.Currency, item.Rate));
            }

            return result;
        }
    }
}
