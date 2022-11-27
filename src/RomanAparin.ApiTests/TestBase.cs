using NUnit.Framework;
using RomanAparin.Common;

namespace RomanAparin.ApiTests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class TestBase
    {
        [SetUp]
        public void Init() { }

        [TearDown]
        public void Cleanup() { }

        protected static int Rand => TestServices.Random.Next(int.MaxValue);
        protected static string NewId => TestServices.NewId;
    }

    [SetUpFixture]
    public class AssemblySetUp
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            
        }

        [OneTimeTearDown]
        public void BaseTearDown()
        {

        }
    }
}