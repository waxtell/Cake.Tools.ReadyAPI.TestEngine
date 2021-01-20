using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestEngine.Tests
{
    public partial class TestEngineRunnerTests
    {
        [Fact]
        public void GetArguments_ProxyUserProvidedHasArgument()
        {
            var settings = new TestEngineSettings
            {
                ProxyUser = "ProxyUser1"
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "proxyUser=ProxyUser1"));
        }

        [Fact]
        public void GetArguments_EmptyProxyUserNoArgument()
        {
            var settings = new TestEngineSettings
            {
                ProxyUser = string.Empty
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("proxyUser")));
        }

        [Fact]
        public void GetArguments_NullProxyUserNoArgument()
        {
            var settings = new TestEngineSettings
            {
                ProxyUser = null
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("proxyUser")));
        }
    }
}
