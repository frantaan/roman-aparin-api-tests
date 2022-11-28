using RomanAparin.SeleniumWebDriver.Elements.BaseTypes.Interfaces;

namespace RomanAparin.SeleniumWebDriver.Elements.CustomTypes.Interface
{
    public interface ITextInput : IElement
    {
        void Clear();
        void SendKeys(string text);
    }
}