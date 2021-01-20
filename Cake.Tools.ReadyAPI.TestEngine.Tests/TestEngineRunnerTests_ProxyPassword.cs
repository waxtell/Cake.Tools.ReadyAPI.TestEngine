using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestEngine.Tests
{
    public partial class TestEngineRunnerTests
    {
        [Fact]
        public void GetArguments_ProxyPasswordProvidedHasArgument()
        {
            var settings = new TestEngineSettings
            {
                ProxyPassword = "ProxyPassword1"
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "proxyPassword=ProxyPassword1"));
        }

        [Fact]
        public void GetArguments_EmptyProxyPasswordNoArgument()
        {
            var settings = new TestEngineSettings
            {
                ProxyPassword = string.Empty
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("proxyPassword")));
        }

        [Fact]
        public void GetArguments_NullProxyPasswordNoArgument()
        {
            var settings = new TestEngineSettings
            {
                ProxyPassword = null
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("proxyPassword")));
        }
    }
}
