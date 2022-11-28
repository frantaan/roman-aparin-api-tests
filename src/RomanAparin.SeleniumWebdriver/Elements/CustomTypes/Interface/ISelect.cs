using RomanAparin.SeleniumWebDriver.Elements.BaseTypes.Interfaces;

namespace RomanAparin.SeleniumWebDriver.Elements.CustomTypes.Interface
{
    public interface ISelect : IElement
    {
        bool Selected { get; }
        void Select(string value);
        string GetSelected();
    }
}