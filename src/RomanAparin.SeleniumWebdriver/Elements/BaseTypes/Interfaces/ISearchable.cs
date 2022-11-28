using RomanAparin.SeleniumWebDriver.Elements.Locators;
using System;
using System.Collections.Generic;

namespace RomanAparin.SeleniumWebDriver.Elements.BaseTypes.Interfaces
{
    public interface ISearchable
    {
        T Find<T>(By by, string locator) where T : IElement, new();
        IEnumerable<T> FindAll<T>(By by, string locator) where T : IElement, new();
    }
}