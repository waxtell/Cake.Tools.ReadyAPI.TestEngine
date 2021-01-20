using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestEngine.Tests
{
    public partial class TestEngineRunnerTests
    {
        [Fact]
        public void GetArguments_RunAsyncTrueHasArgument()
        {
            var settings = new TestEngineSettings
            {
                RunAsync = true
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "async" ));
        }

        [Fact]
        public void GetArguments_RunAsyncFalseNoArgument()
        {
            var settings = new TestEngineSettings
            {
                RunAsync = false
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render() == "async"));
        }

        [Fact]
        public void GetArguments_RunAsyncNullNoArgument()
        {
            var settings = new TestEngineSettings
            {
                RunAsync = null
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render() == "async"));
        }
    }
}
