using RomanAparin.SeleniumWebDriver.Elements.Attributes;
using RomanAparin.SeleniumWebDriver.Elements.BaseTypes;
using RomanAparin.SeleniumWebDriver.Elements.CustomTypes;
using RomanAparin.SeleniumWebDriver.Elements.Locators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIT.AUTOTESTING.UI.BDD.Pages.Elements
{
    public class LoginPageElements
    {
        public class SigninView : WebElement
        {
            [FindBy(By.CssSelector, @"[formcontrolname='login'")] public TextInput LoginInput { get; set; }

            [FindBy(By.CssSelector, @"[formcontrolname='password']")] public TextInput PasswordInput { get; set; }

            [FindBy(By.CssSelector, @"[type='button']")] public Button SignInButton { get; set; }

        }
    }   
}
