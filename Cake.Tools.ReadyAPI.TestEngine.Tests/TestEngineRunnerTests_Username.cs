using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestEngine.Tests
{
    public partial class TestEngineRunnerTests
    {
        [Fact]
        public void GetArguments_UsernameProvidedHasArgument()
        {
            var settings = new TestEngineSettings
            {
                Username = "Username"
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "-u Username"));
        }

        [Fact]
        public void GetArguments_EmptyUsernameNoArgument()
        {
            var settings = new TestEngineSettings
            {
                Username = string.Empty
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-u")));
        }

        [Fact]
        public void GetArguments_NullUsernameNoArgument()
        {
            var settings = new TestEngineSettings
            {
                Username = null
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-u")));
        }
    }
}
