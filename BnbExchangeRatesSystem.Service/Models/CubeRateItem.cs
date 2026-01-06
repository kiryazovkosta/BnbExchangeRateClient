using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BnbExchangeRatesSystem.Service.Models;

public sealed class CubeRateItem
{
    [XmlAttribute("currency")]
    public required string Currency { get; set; }

    [XmlAttribute("rate")]
    public required decimal Rate { get; set; }
}

public sealed class CubeRatesList
{
    [XmlAttribute("time")]
    public string? Time { get; set; }

    [XmlElement("Cube", Namespace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref")]
    public CubeRateItem[]? Rates { get; set; }
}
