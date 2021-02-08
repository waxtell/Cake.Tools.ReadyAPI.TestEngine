using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestEngine.Tests
{
    public partial class TestEngineRunnerTests
    {
        [Fact]
        public void GetArguments_EndPointProvidedHasArgument()
        {
            var settings = new TestEngineSettings
            {
                EndPoint = "localhost:8080"
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "endpoint=localhost:8080"));
        }

        [Fact]
        public void GetArguments_EmptyEndPointNoArgument()
        {
            var settings = new TestEngineSettings
            {
                EndPoint = string.Empty
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("endpoint")));
        }

        [Fact]
        public void GetArguments_NullEndPointNoArgument()
        {
            var settings = new TestEngineSettings
            {
                EndPoint = null
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("endpoint")));
        }
    }
}
