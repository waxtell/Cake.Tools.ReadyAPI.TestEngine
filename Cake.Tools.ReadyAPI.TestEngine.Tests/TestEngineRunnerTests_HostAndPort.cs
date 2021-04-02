using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestEngine.Tests
{
    public partial class TestEngineRunnerTests
    {
        [Fact]
        public void GetArguments_HostAndPortProvidedHasArgument()
        {
            var settings = new TestEngineSettings
            {
                HostAndPort = "localhost:8080"
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "hostAndPort=localhost:8080"));
        }

        [Fact]
        public void GetArguments_EmptyHostAndPortNoArgument()
        {
            var settings = new TestEngineSettings
            {
                HostAndPort = string.Empty
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("hostAndPort")));
        }

        [Fact]
        public void GetArguments_NullHostAndPortNoArgument()
        {
            var settings = new TestEngineSettings
            {
                HostAndPort = null
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("hostAndPort")));
        }
    }
}
