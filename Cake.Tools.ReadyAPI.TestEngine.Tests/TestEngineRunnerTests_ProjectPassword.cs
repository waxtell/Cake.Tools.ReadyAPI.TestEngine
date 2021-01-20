using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestEngine.Tests
{
    public partial class TestEngineRunnerTests
    {
        [Fact]
        public void GetArguments_ProjectPasswordProvidedHasArgument()
        {
            var settings = new TestEngineSettings
            {
                ProjectPassword = "password"
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "projectPassword=password"));
        }

        [Fact]
        public void GetArguments_EmptyProjectPasswordNoArgument()
        {
            var settings = new TestEngineSettings
            {
                ProjectPassword = string.Empty
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("projectPassword")));
        }

        [Fact]
        public void GetArguments_NullProjectPasswordNoArgument()
        {
            var settings = new TestEngineSettings
            {
                ProjectPassword = null
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("projectPassword")));
        }
    }
}
