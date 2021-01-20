using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestEngine.Tests
{
    public partial class TestEngineRunnerTests
    {
        [Fact]
        public void GetArguments_ReportFileNameProvidedHasArgument()
        {
            var settings = new TestEngineSettings
            {
                ReportFileName = "ReportFileName1"
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "reportFileName=ReportFileName1"));
        }

        [Fact]
        public void GetArguments_EmptyReportFileNameNoArgument()
        {
            var settings = new TestEngineSettings
            {
                ReportFileName = string.Empty
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("reportFileName")));
        }

        [Fact]
        public void GetArguments_NullReportFileNameNoArgument()
        {
            var settings = new TestEngineSettings
            {
                ReportFileName = null
            };

            var args = TestEngineRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("reportFileName")));
        }
    }
}
