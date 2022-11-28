using OpenQA.Selenium.Support.UI;
using RomanAparin.SeleniumWebDriver.Elements.BaseTypes;
using RomanAparin.SeleniumWebDriver.Elements.CustomTypes.Interface;
using static RomanAparin.SeleniumWebDriver.Helpers.WaitHelper;

namespace RomanAparin.SeleniumWebDriver.Elements.CustomTypes
{
    public class DropDown : WebElement, ISelect
    {
        public void Select(string value) => DoRetry(() => new SelectElement(GetNative()).SelectByText(value));
        public string GetSelected() => DoRetryWithReturn(() => new SelectElement(GetNative()).SelectedOption.Text);
    }
}