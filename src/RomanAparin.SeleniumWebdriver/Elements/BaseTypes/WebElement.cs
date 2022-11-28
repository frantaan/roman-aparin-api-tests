using OpenQA.Selenium;
using RomanAparin.SeleniumWebDriver.DriverManager;
using RomanAparin.SeleniumWebDriver.Elements.BaseTypes.Interfaces;
using RomanAparin.SeleniumWebDriver.Elements.Extensions;
using RomanAparin.SeleniumWebDriver.Elements.Factories;
using RomanAparin.SeleniumWebDriver.Elements.Locators;
using System;
using System.Collections.Generic;
using System.Drawing;
using static RomanAparin.SeleniumWebDriver.Helpers.WaitHelper;

namespace RomanAparin.SeleniumWebDriver.Elements.BaseTypes
{
    public class WebElement : IElement
    {
        private IWebElement _nativeElement;
        public IWebElement GetNative()
        {
            if (_nativeElement == null || !_nativeElement.Exists())
                _nativeElement = Parent.FindElement(SearchStrategy.Locator.By, SearchStrategy.Locator.Using, SearchStrategy.Index);

            return _nativeElement;
        }
        public INative Parent { get; set; }
        public Locator Locator { get; set; }
        public SearchStrategy SearchStrategy { get; set; }
        public Size Size => DoRetryWithReturn(() => GetNative().Size);
        public Point Location => DoRetryWithReturn(() => GetNative().Location);
        public bool Displayed => DoRetryWithReturn(() => GetNative().Displayed);
        public bool Enabled => DoRetryWithReturn(() => GetNative().Enabled);
        public string TagName => DoRetryWithReturn(() => GetNative().TagName);
        public bool Selected => DoRetryWithReturn(() => GetNative().Selected);
        public string Text => DoRetryWithReturn(() => GetNative().Text);
        public string GetAttribute(string attributeName) => DoRetryWithReturn(() => GetNative().GetAttribute(attributeName));
        public string GetProperty(string property) => DoRetryWithReturn(() => GetNative().GetProperty(property));
        public string GetCssValue(string cssName) => DoRetryWithReturn(() => GetNative().GetCssValue(cssName));
        public bool Exists()
        {
            try
            {
                GetNative().Exists();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public WebElement() { }
        public WebElement(Locator locator) => Locator = locator;
        public WebElement(INative parent, Locator locator)
        {
            Parent = parent;
            Locator = locator;
        }

        public void MouseOver() => DoRetry(() => { DriverFactory.Action.MoveToElement(GetNative()).Build().Perform(); });
        public void ActionClick() => DoRetry(() => { DriverFactory.Action.MoveToElement(GetNative()).Click().Build().Perform(); });
        public void Click() => DoRetry(() => { GetNative().Click(); });
        public T Find<T>(Locators.By by, string locator) where T : IElement, new() => WebElementFactory.Create<T>(this, new Locator(by, locator));
        public IEnumerable<T> FindAll<T>(Locators.By by, string locator) where T : IElement, new() => WebElementsCollectionFactory.Create<T>(this, new Locator(by, locator));
        IWebElement IElement.GetNative() => GetNative();
        void IElement.SetNativeElement(IWebElement nativeElement) => _nativeElement = nativeElement;
        IWebElement INative.FindElement(Locators.By by, string locator, int index) => GetNative().FindElement(new Locator(by, locator).ToSeleniumLocator());
        IReadOnlyCollection<IWebElement> INative.FindElements(Locators.By by, string locator) => GetNative().FindElements(new Locator(by, locator).ToSeleniumLocator());
    }
}