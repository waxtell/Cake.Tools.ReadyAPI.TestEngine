using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestEngine.Tests
{
    public partial class TestEngineRunnerTests
    {
        [Fact]
        public void GetArguments_TestCaseProvidedHasArgument()
        {
            var settings = new TestEngineSettings
            {
                TestCase = "HelloWorld"
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "testcase=HelloWorld"));
        }

        [Fact]
        public void GetArguments_EmptyTestCaseNoArgument()
        {
            var settings = new TestEngineSettings
            {
                TestCase = string.Empty
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("testcase")));
        }

        [Fact]
        public void GetArguments_NullTestCaseNoArgument()
        {
            var settings = new TestEngineSettings
            {
                TestCase = null
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("testcase=")));
        }
    }
}
