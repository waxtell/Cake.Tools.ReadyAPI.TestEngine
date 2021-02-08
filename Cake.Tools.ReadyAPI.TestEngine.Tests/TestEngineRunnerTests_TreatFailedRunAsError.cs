using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestEngine.Tests
{
    public partial class TestEngineRunnerTests
    {
        [Fact]
        public void GetArguments_TreatFailedRunAsErrorTrueHasArgument()
        {
            var settings = new TestEngineSettings
            {
                TreatFailedRunAsError = true
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "treatFailedRunAsError"));
        }

        [Fact]
        public void GetArguments_TreatFailedRunAsErrorFalseNoArgument()
        {
            var settings = new TestEngineSettings
            {
                TreatFailedRunAsError = false
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render() == "treatFailedRunAsError"));
        }

        [Fact]
        public void GetArguments_TreatFailedRunAsErrorNullNoArgument()
        {
            var settings = new TestEngineSettings
            {
                TreatFailedRunAsError = null
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render() == "treatFailedRunAsError"));
        }
    }
}
