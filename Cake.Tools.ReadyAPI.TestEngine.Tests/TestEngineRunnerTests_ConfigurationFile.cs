using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestEngine.Tests
{
    public partial class TestEngineRunnerTests
    {
        [Fact]
        public void GetArguments_ConfigurationFileProvidedHasArgument()
        {
            var settings = new TestEngineSettings
            {
                ConfigurationFile = "HelloWorld.json"
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "-c HelloWorld.json"));
        }

        [Fact]
        public void GetArguments_EmptyConfigurationFileNoArgument()
        {
            var settings = new TestEngineSettings
            {
                ConfigurationFile = string.Empty
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-c")));
        }

        [Fact]
        public void GetArguments_NullConfigurationFileNoArgument()
        {
            var settings = new TestEngineSettings
            {
                ConfigurationFile = null
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-c")));
        }
    }
}
