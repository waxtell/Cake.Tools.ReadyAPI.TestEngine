using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestEngine.Tests
{
    public partial class TestEngineRunnerTests
    {
        [Fact]
        public void GetArguments_SecurityTestProvidedHasArgument()
        {
            var settings = new TestEngineSettings
            {
                SecurityTest = "SecurityTest1"
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "securitytest=SecurityTest1"));
        }

        [Fact]
        public void GetArguments_EmptySecurityTestNoArgument()
        {
            var settings = new TestEngineSettings
            {
                SecurityTest = string.Empty
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("securitytest")));
        }

        [Fact]
        public void GetArguments_NullSecurityTestNoArgument()
        {
            var settings = new TestEngineSettings
            {
                SecurityTest = null
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("securitytest")));
        }
    }
}
