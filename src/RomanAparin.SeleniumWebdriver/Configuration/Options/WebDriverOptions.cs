using System.Collections.Generic;

namespace RomanAparin.SeleniumWebDriver.Configuration.Options
{
    public class WebDriverOptions
    {
        public SelenoidOptions SelenoidOptions { get; set; }
        public PageOptions PageOptions { get; set; }
        public TimeoutOptions TimeoutOptions { get; set; }
        public AngularOptions AngularOptions { get; set; }
        public List<string> ChromeArguments { get; set; }
    }
}