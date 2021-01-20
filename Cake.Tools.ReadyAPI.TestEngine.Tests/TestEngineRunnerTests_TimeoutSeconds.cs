using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestEngine.Tests
{
    public partial class TestEngineRunnerTests
    {
        [Fact]
        public void GetArguments_TimeoutSecondsProvidedHasArgument()
        {
            var settings = new TestEngineSettings
            {
                TimeoutSeconds = 120
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "timeout=120"));
        }

        [Fact]
        public void GetArguments_NullTimeoutSecondsNoArgument()
        {
            var settings = new TestEngineSettings
            {
                TimeoutSeconds = null
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("timeout")));
        }
    }
}
