using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestEngine.Tests
{
    public partial class TestEngineRunnerTests
    {
        [Fact]
        public void GetArguments_ReportFormatsProvidedHasArgument()
        {
            var settings = new TestEngineSettings
            {
                ReportFormat = ReportFormat.excel
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "format=excel"));
        }

        [Fact]
        public void GetArguments_NullReportFormatsNoArgument()
        {
            var settings = new TestEngineSettings
            {
                ReportFormat = null
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("format")));
        }
    }
}
