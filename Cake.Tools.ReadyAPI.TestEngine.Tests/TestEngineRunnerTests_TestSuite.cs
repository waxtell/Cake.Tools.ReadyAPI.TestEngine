using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestEngine.Tests
{
    public partial class TestEngineRunnerTests
    {
        [Fact]
        public void GetArguments_TestSuiteProvidedHasArgument()
        {
            var settings = new TestEngineSettings
            {
                TestSuite = "TestSuite1"
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "testsuite=TestSuite1"));
        }

        [Fact]
        public void GetArguments_EmptyTestSuiteNoArgument()
        {
            var settings = new TestEngineSettings
            {
                TestSuite = string.Empty
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("testsuite")));
        }

        [Fact]
        public void GetArguments_NullTestSuiteNoArgument()
        {
            var settings = new TestEngineSettings
            {
                TestSuite = null
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("testsuite")));
        }
    }
}
