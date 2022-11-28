using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RomanAparin.SeleniumWebDriver.Configuration;
using RomanAparin.SeleniumWebDriver.DriverManager;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace RomanAparin.UITests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class TestsBase
    {
        
        private static string CurrentTestName => TestContext.CurrentContext.Test.Name;
        
        [SetUp]
        public void Init()
        {
            Console.WriteLine($"Test {CurrentTestName} started");
            Selenoid.SetBrowserName(CurrentTestName);
        }

        [TearDown]
        public void Cleanup()
        {
            switch (TestContext.CurrentContext.Result.Outcome.Status)
            {
                case TestStatus.Failed:
                    Browser.TakeScreenshots(CurrentTestName);
                    Browser.CloseBrowser();
                    break;
                case TestStatus.Passed:
                    Browser.CloseBrowser();
                    break;
            }
        }
    }
    
    [SetUpFixture]
    public class AssemblySetUp
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Settings.ConfigureWebDriver();
        }
        
        [OneTimeTearDown]
        public void BaseTearDown()
        {
        }
    }
}