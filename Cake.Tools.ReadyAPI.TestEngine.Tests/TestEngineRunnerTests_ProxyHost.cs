using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestEngine.Tests
{
    public partial class TestEngineRunnerTests
    {
        [Fact]
        public void GetArguments_ProxyHostProvidedHasArgument()
        {
            var settings = new TestEngineSettings
            {
                ProxyHost = "ProxyHost1"
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "proxyHost=ProxyHost1"));
        }

        [Fact]
        public void GetArguments_EmptyProxyHostNoArgument()
        {
            var settings = new TestEngineSettings
            {
                ProxyHost = string.Empty
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("proxyHost")));
        }

        [Fact]
        public void GetArguments_NullProxyHostNoArgument()
        {
            var settings = new TestEngineSettings
            {
                ProxyHost = null
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("proxyHost")));
        }
    }
}
