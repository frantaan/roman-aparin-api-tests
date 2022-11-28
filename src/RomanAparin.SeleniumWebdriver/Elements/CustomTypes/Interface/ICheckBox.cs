using RomanAparin.SeleniumWebDriver.Elements.BaseTypes.Interfaces;

namespace RomanAparin.SeleniumWebDriver.Elements.CustomTypes.Interface
{
    public interface ICheckBox : IElement
    {
        void Check();
        void Uncheck();
        bool Checked { get; }
    }
}