using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using RomanAparin.SeleniumWebDriver.DriverManager;
using RomanAparin.SeleniumWebDriver.Elements.BaseTypes.Interfaces;
using RomanAparin.SeleniumWebDriver.Elements.Extensions;
using RomanAparin.SeleniumWebDriver.Elements.Factories;
using RomanAparin.SeleniumWebDriver.Elements.Locators;
using System;
using System.Collections.Generic;
using static RomanAparin.SeleniumWebDriver.Helpers.WaitHelper;
using WebElementFactory = RomanAparin.SeleniumWebDriver.Elements.Factories.WebElementFactory;

namespace RomanAparin.SeleniumWebDriver.Elements.BaseTypes
{
    public abstract class WebPage : IWebPage
    {
        public string Title { get; set; }
        public string Address { get; set; }
        public bool Opened(int retryCount = 4) => DoRetryWithReturn(() => DriverFactory.GetDriver.Url.StartsWith(((IWebPage)this).Address), retryCount);
        public void Open(string query = null) => DriverFactory.GetDriver.Navigate().GoToUrl(Address + query);

        public virtual void WaitForLoaded(int retryCount = 4)
            => DoRetryWithReturn(() => (DriverFactory.GetDriver as IJavaScriptExecutor)?
                .ExecuteScript("if (document.readyState) return document.readyState;").ToString().ToLower() == "complete", retryCount);
        public T Find<T>(Locators.By by, string locator) where T : IElement, new() => WebElementFactory.Create<T>(this, new Locator(by, locator));
        public IEnumerable<T> FindAll<T>(Locators.By by, string locator) where T : IElement, new() => WebElementsCollectionFactory.Create<T>(this, new Locator(by, locator));
        IWebElement INative.FindElement(Locators.By by, string locator, int index) => DriverFactory.GetDriver.FindElement(new Locator(by, locator).ToSeleniumLocator());
        IReadOnlyCollection<IWebElement> INative.FindElements(Locators.By by, string locator) => DriverFactory.GetDriver.FindElements(new Locator(by, locator).ToSeleniumLocator());

        public virtual void ScrollDown(string number) => DriverFactory.GetDriver.ExecuteJavaScript("scroll(0," + number + ")");
    }
}