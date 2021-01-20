using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestEngine.Tests
{
    public partial class TestEngineRunnerTests
    {
        [Fact]
        public void GetArguments_ProxyPortProvidedHasArgument()
        {
            var settings = new TestEngineSettings
            {
                ProxyPort = 80
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "proxyPort=80"));
        }

        [Fact]
        public void GetArguments_NullProxyPortNoArgument()
        {
            var settings = new TestEngineSettings
            {
                ProxyPort = null
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("proxyPort")));
        }
    }
}
