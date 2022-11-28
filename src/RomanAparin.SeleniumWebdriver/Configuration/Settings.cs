using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using RomanAparin.SeleniumWebDriver.Configuration.Options;
using RomanAparin.SeleniumWebDriver.DriverManager;
using System;
using static RomanAparin.SeleniumWebDriver.DriverManager.CapabilitiesFactory;

namespace RomanAparin.SeleniumWebDriver.Configuration
{
    public static class Settings
    {
        public static ServiceProvider ServiceProvider { get; set; }
        public static IOptions<WebDriverOptions> WebDriverOptions { get; private set; }
        public static string CurrentPath => AppContext.BaseDirectory;
        public static void ConfigureWebDriver()
        {
            var configuration = new ConfigurationBuilder()
                                    .AddJsonFile("appsettings.json")
                                    .Build();
            var services = new ServiceCollection();
            services.Configure<WebDriverOptions>(configuration.GetSection("WebDriverOptions"));
            ServiceProvider = services.BuildServiceProvider();
            WebDriverOptions = ServiceProvider.GetService<IOptions<WebDriverOptions>>();
        }
        
        public static void AddBrowserCapability(string name, string value) => AddChromeCapabilities(name, value);

        public static IWebDriver GetWebDriver() => DriverFactory.GetDriver;
    }
}