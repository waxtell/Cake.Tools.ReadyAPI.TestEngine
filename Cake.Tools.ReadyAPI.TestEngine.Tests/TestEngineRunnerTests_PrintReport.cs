using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestEngine.Tests
{
    public partial class TestEngineRunnerTests
    {
        [Fact]
        public void GetArguments_PrintSummaryReportTrueHasArgument()
        {
            var settings = new TestEngineSettings
            {
                PrintReport = true
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "printReport" ));
        }

        [Fact]
        public void GetArguments_PrintSummaryReportFalseNoArgument()
        {
            var settings = new TestEngineSettings
            {
                PrintReport = false
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render() == "printReport"));
        }
    }
}
