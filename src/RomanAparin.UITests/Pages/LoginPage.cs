using RomanAparin.SeleniumWebDriver.Elements.Attributes;
using RomanAparin.SeleniumWebDriver.Elements.BaseTypes;
using RomanAparin.SeleniumWebDriver.Elements.Locators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AIT.AUTOTESTING.UI.BDD.Pages.Elements.LoginPageElements;
using static RomanAparin.SeleniumWebDriver.Elements.Extensions.WebElementExtensions;

namespace RomanAparin.UITests.Pages
{
    [Url("squash/login")]
    public class LoginPage : WebPage
    {
        [FindBy(By.XPath, "//sqtm-app-login-form")] public SigninView SigninView { get; set; }
        [FindBy(By.XPath, "//sqtm-core-nav-bar")] public WebElement NavBar { get; set; }

        public void Login(string login, string password)
        {
            SigninView.LoginInput.WaitFor(x => x.Displayed, 5);
            SigninView.LoginInput.SendKeys(login);
            SigninView.PasswordInput.SendKeys(password);
            SigninView.SignInButton.Click();
            SigninView.SignInButton.WaitForNotDisplayed();
        }
    }
}
