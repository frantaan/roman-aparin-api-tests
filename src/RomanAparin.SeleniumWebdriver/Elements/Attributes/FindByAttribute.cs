using System;
using RomanAparin.SeleniumWebDriver.Elements.Locators;

namespace RomanAparin.SeleniumWebDriver.Elements.Attributes
{
    public class FindByAttribute : Attribute
    {
        public By By { get; }

        public string Locator { get; }

        public FindByAttribute(By by, string locator)
        {
            By = by;
            Locator = locator;
        }
    }
}