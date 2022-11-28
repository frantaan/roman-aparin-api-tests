using OpenQA.Selenium;
using RomanAparin.SeleniumWebDriver.Elements.Locators;
using System;
using System.Collections.Generic;

namespace RomanAparin.SeleniumWebDriver.Elements.BaseTypes.Interfaces
{
    public interface INative
    {
        IWebElement FindElement(Locators.By by, string locator, int index);
        IReadOnlyCollection<IWebElement> FindElements(Locators.By by, string locator);
    }
}