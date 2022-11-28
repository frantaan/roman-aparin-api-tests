using System;

namespace RomanAparin.SeleniumWebDriver.Exсeptions
{
    public class SeleniumWebDriverException : Exception
    {
        public SeleniumWebDriverException(string exception) : base(exception) { }
        public SeleniumWebDriverException(string message, Exception innerException) : base(message, innerException) { }
    }
}