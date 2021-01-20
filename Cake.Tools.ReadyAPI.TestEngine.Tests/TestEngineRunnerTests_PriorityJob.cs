using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestEngine.Tests
{
    public partial class TestEngineRunnerTests
    {
        [Fact]
        public void GetArguments_PriorityJobTrueHasArgument()
        {
            var settings = new TestEngineSettings
            {
                PriorityJob = true
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "priorityJob" ));
        }

        [Fact]
        public void GetArguments_PriorityJobFalseNoArgument()
        {
            var settings = new TestEngineSettings
            {
                PriorityJob = false
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render() == "priorityJob"));
        }

        [Fact]
        public void GetArguments_PriorityJobNullNoArgument()
        {
            var settings = new TestEngineSettings
            {
                PriorityJob = null
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render() == "priorityJob"));
        }
    }
}
