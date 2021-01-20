using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestEngine.Tests
{
    public partial class TestEngineRunnerTests
    {
        [Fact]
        public void GetArguments_EnvironmentProvidedHasArgument()
        {
            var settings = new TestEngineSettings
            {
                Environment = "NewEnvironment"
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "environment=NewEnvironment"));
        }

        [Fact]
        public void GetArguments_EmptyEnvironmentNoArgument()
        {
            var settings = new TestEngineSettings
            {
                Environment = string.Empty
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("environment")));
        }

        [Fact]
        public void GetArguments_NullEnvironmentNoArgument()
        {
            var settings = new TestEngineSettings
            {
                Environment = null
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("environment")));
        }
    }
}
