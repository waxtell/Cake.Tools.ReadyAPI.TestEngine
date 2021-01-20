using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestEngine.Tests
{
    public partial class TestEngineRunnerTests
    {
        [Fact]
        public void GetArguments_VerboseTrueHasArgument()
        {
            var settings = new TestEngineSettings
            {
                Verbose = true
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "-v" ));
        }

        [Fact]
        public void GetArguments_VerboseFalseNoArgument()
        {
            var settings = new TestEngineSettings
            {
                Verbose = false
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render() == "-v"));
        }

        [Fact]
        public void GetArguments_VerboseNullNoArgument()
        {
            var settings = new TestEngineSettings
            {
                Verbose = null
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render() == "-v"));
        }
    }
}
