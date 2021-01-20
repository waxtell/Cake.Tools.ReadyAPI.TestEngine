using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestEngine.Tests
{
    public partial class TestEngineRunnerTests
    {
        [Fact]
        public void GetArguments_QuietTrueHasArgument()
        {
            var settings = new TestEngineSettings
            {
                Quiet = true
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "-q" ));
        }

        [Fact]
        public void GetArguments_QuietFalseNoArgument()
        {
            var settings = new TestEngineSettings
            {
                Quiet = false
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render() == "-q"));
        }

        [Fact]
        public void GetArguments_QuietNullNoArgument()
        {
            var settings = new TestEngineSettings
            {
                Quiet = null
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render() == "-q"));
        }
    }
}
