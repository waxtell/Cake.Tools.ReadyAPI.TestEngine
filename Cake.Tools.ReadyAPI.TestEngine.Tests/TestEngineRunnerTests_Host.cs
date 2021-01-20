using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestEngine.Tests
{
    public partial class TestEngineRunnerTests
    {
        [Fact]
        public void GetArguments_HostProvidedHasArgument()
        {
            var settings = new TestEngineSettings
            {
                Host = "localhost"
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "-H localhost"));
        }

        [Fact]
        public void GetArguments_EmptyHostNoArgument()
        {
            var settings = new TestEngineSettings
            {
                Host = string.Empty
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-H")));
        }

        [Fact]
        public void GetArguments_NullHostNoArgument()
        {
            var settings = new TestEngineSettings
            {
                Host = null
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-H")));
        }
    }
}
