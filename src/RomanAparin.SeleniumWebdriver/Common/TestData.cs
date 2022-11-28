using System;
using System.Collections.Generic;
using System.Text;

namespace RomanAparin.SeleniumWebDriver.Common
{
    public class TestData
    {
        public Dictionary<string, string[]> StringArrays = new Dictionary<string, string[]>();
        public Dictionary<string, string> Strings = new Dictionary<string, string>();
        public Dictionary<string, int?> Integers = new Dictionary<string, int?>();
        public Dictionary<string, bool> Booleans = new Dictionary<string, bool>();
        public Dictionary<string, List<KeyValuePair<string, string>>> KeyValuePairs = new Dictionary<string, List<KeyValuePair<string, string>>>();
        public Dictionary<string, Dictionary<string, string>> DictionariesOfStrings = new Dictionary<string, Dictionary<string, string>>();
    }
}
