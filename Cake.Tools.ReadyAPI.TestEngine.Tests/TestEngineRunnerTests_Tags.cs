using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestEngine.Tests
{
    public partial class TestEngineRunnerTests
    {
        [Fact]
        public void GetArguments_TagsProvidedHasArgument()
        {
            var settings = new TestEngineSettings
            {
                Tags = new [] { "Tag3","Tag4" }
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "tags=Tag3,Tag4"));
        }

        [Fact]
        public void GetArguments_EmptyTagsNoArgument()
        {
            var settings = new TestEngineSettings
            {
                Tags = new List<string>()
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("tags")));
        }

        [Fact]
        public void GetArguments_NullTagsNoArgument()
        {
            var settings = new TestEngineSettings
            {
                Tags = null
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("tags")));
        }
    }
}
