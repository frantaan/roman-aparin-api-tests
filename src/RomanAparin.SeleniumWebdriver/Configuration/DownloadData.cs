using System;
using System.Xml.Serialization;

namespace RomanAparin.SeleniumWebDriver.Configuration
{
    [Serializable]
    [XmlRoot("pre")]
    public class DownloadData
    {
        [XmlElement("a")]
        public string[] Items { get; set; }
    }
}
