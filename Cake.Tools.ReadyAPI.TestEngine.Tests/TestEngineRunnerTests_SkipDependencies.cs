using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestEngine.Tests
{
    public partial class TestEngineRunnerTests
    {
        [Fact]
        public void GetArguments_SkipDependenciesTrueHasArgument()
        {
            var settings = new TestEngineSettings
            {
                SkipDependencies = true
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "skipdeps" ));
        }

        [Fact]
        public void GetArguments_SkipDependenciesFalseNoArgument()
        {
            var settings = new TestEngineSettings
            {
                SkipDependencies = false
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render() == "skipdeps"));
        }

        [Fact]
        public void GetArguments_SkipDependenciesNullNoArgument()
        {
            var settings = new TestEngineSettings
            {
                SkipDependencies = null
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render() == "skipdeps"));
        }
    }
}
