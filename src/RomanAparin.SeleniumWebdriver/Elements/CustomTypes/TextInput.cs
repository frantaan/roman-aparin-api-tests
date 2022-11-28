using RomanAparin.SeleniumWebDriver.Elements.BaseTypes;
using RomanAparin.SeleniumWebDriver.Elements.CustomTypes.Interface;
using System;
using static RomanAparin.SeleniumWebDriver.Helpers.WaitHelper;

namespace RomanAparin.SeleniumWebDriver.Elements.CustomTypes
{
    public class TextInput : WebElement, ITextInput
    {
        public void SendKeys(string text) => DoRetry(() => { GetNative().SendKeys(text); });
        public void Clear() => DoRetry(() => { GetNative().Clear(); });
        public string GetText => GetAttribute("text") ?? string.Empty;
    }
}