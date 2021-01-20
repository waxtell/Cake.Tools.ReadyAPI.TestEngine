using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestEngine.Tests
{
    public partial class TestEngineRunnerTests
    {
        [Fact]
        public void GetArguments_OutputFolderProvidedHasArgument()
        {
            var settings = new TestEngineSettings
            {
                OutputFolder = "HelloWorld"
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "output=HelloWorld"));
        }

        [Fact]
        public void GetArguments_EmptyOutputFolderNoArgument()
        {
            var settings = new TestEngineSettings
            {
                OutputFolder = string.Empty
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("output")));
        }

        [Fact]
        public void GetArguments_NullOutputFolderNoArgument()
        {
            var settings = new TestEngineSettings
            {
                OutputFolder = null
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("output")));
        }
    }
}
