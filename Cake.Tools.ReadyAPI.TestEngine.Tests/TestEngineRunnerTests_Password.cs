using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestEngine.Tests
{
    public partial class TestEngineRunnerTests
    {
        [Fact]
        public void GetArguments_PasswordProvidedHasArgument()
        {
            var settings = new TestEngineSettings
            {
                Password = "HelloWorld"
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "-p HelloWorld"));
        }

        [Fact]
        public void GetArguments_EmptyPasswordNoArgument()
        {
            var settings = new TestEngineSettings
            {
                Password = string.Empty
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-p")));
        }

        [Fact]
        public void GetArguments_NullPasswordNoArgument()
        {
            var settings = new TestEngineSettings
            {
                Password = null
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-p")));
        }
    }
}
