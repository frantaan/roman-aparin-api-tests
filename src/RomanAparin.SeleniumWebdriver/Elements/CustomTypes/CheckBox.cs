using RomanAparin.SeleniumWebDriver.Elements.BaseTypes;
using RomanAparin.SeleniumWebDriver.Elements.CustomTypes.Interface;

namespace RomanAparin.SeleniumWebDriver.Elements.CustomTypes
{
    public class CheckBox : WebElement, ICheckBox
    {
        public void Check()
        {
            if (!Checked) Click();
        }

        public void Uncheck()
        {
            if (Checked) Click();
        }
        public bool Checked => bool.Parse(GetAttribute("checked"));
    }
}