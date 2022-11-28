using System;
using System.Collections;
using System.Linq;
using System.Threading;

using NUnit.Framework;
using OpenQA.Selenium;
using RomanAparin.Common.DataBuilders.TestData;
using RomanAparin.SeleniumWebDriver.Elements.Factories;
using RomanAparin.UITests.Pages;

namespace RomanAparin.UITests
{
    [TestFixture]
    public class LoginTests : TestsBase
    {
        [TestCaseSource(typeof(LoginTestsCases), nameof(LoginTestsCases.SuccessLogin))]
        [TestCaseSource(typeof(LoginTestsCases), nameof(LoginTestsCases.FailedLogin))]
        public void LoginPage_Login_VerifyLoginPossibility(TestData data)
        {
            var loginPage = PageFactory.Get<LoginPage>();
            loginPage.Open();
            Assert.That(loginPage.Opened(), Is.True, $"Login page is not open");
            Assert.That(loginPage.SigninView.Displayed);

            loginPage.Login(data.Strings["login"], data.Strings["password"]);
            Assert.True(loginPage.NavBar.Displayed, "NavBar after login is not displayed");
        }
    }

    internal static class LoginTestsCases
    {
        internal static IEnumerable SuccessLogin
        {
            get
            {
                var data1 = new TestData();
                data1.Strings["login"] = "guest_tr";
                data1.Strings["password"] = "P@ssw0rd!123";
                yield return new TestCaseData(data1).SetArgDisplayNames("Success login");
            }
        }
        
        internal static IEnumerable FailedLogin
        {
            get
            {
                var data1 = new TestData();
                data1.Strings["login"] = "guest_trr";
                data1.Strings["password"] = "P@ssw0rd!123";
                yield return new TestCaseData(data1).SetArgDisplayNames("Failed login");
            }
        }
    }
}

   
