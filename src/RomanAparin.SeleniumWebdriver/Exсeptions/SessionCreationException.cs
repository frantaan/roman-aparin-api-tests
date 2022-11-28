using System;

namespace RomanAparin.SeleniumWebDriver.Exсeptions
{
    public class SessionCreationException : SeleniumWebDriverException
    {
        public SessionCreationException(string exception) : base(exception) { }
        public SessionCreationException(string message, Exception innerException) : base(message, innerException) { }
    }
}