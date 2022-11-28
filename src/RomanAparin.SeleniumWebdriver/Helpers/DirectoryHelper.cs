using System.IO;
using RomanAparin.SeleniumWebDriver.Configuration;

namespace RomanAparin.SeleniumWebDriver.Helpers
{
    internal static class DirectoryHelper
    {
        internal static string CreateAndReturn(string directoryName, string testName) => Directory.CreateDirectory(Path.Combine(Settings.CurrentPath, directoryName, testName)).ToString();
    }
}