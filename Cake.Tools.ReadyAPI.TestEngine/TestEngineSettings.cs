using System.Collections.Generic;
using Cake.Core.Tooling;

namespace Cake.Tools.ReadyAPI.TestEngine
{
    /// <summary>
    /// Contains the settings used by the TestEngine CLI
    /// Please see <a href="https://support.smartbear.com/readyapi/docs/testengine/admin/cli.html">TestEngine Command-Line Tool</a> for additional information
    /// </summary>
    public class TestEngineSettings : ToolSettings
    {
        /// <summary>
        /// Specifies the configuration file to use in the command.
        /// </summary>
        public string ConfigurationFile { get; set; }

        /// <summary>
        /// Specifies the environment to use during the test run.
        /// </summary>
        public string Environment { get; set; }

        /// <summary>
        /// Specifies the address of TestEngine you want to connect to.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Exports a test report to the specified folder.
        /// </summary>
        public string OutputFolder { get; set; }

        /// <summary>
        /// Specifies the user password used to connect to TestEngine.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Command the command-line tool to print test job report to the console.
        /// </summary>
        public bool? PrintReport { get; set; }

        /// <summary>
        /// Specify this option to skip all non-priority jobs in the queue (requires administrator rights).
        /// </summary>
        public bool? PriorityJob { get; set; }

        /// <summary>
        /// Specifies the project password.
        /// </summary>
        public string ProjectPassword { get; set; }

        /// <summary>
        /// Specifies the proxy host.
        /// </summary>
        public string ProxyHost { get; set; }

        /// <summary>
        /// Specifies the port of the proxy.
        /// </summary>
        public int? ProxyPort { get; set; }

        /// <summary>
        /// Specifies the username to access the proxy.
        /// </summary>
        public string ProxyUser { get; set; }

        /// <summary>
        /// Specifies the password to access the proxy.
        /// </summary>
        public string ProxyPassword { get; set; }

        /// <summary>
        /// Runs the command in silent mode. The command-line tool will not print the output.
        /// </summary>
        public bool? Quiet { get; set; }

        /// <summary>
        /// Specifies the name of the report file.
        /// </summary>
        public string ReportFileName { get; set; }

        /// <summary>
        /// Specifies the report type. Possible values:
        /// <list type="table">
        /// <item><term>junit</term><description>Saves a report to the JUnit XML format (an XML file).</description></item>
        /// <item><term>excel</term><description>Saves a report in a Microsoft Excel sheet (a XSLX file).</description></item>
        /// <item><term>json></term><description>Saves a report in the JSON format (a JSON file).</description></item>
        /// </list>
        /// </summary>
        public ReportFormat? ReportFormat { get; set; }

        /// <summary>
        /// If this option is specified, the command-line tool will not wait for the test job to finish.
        /// </summary>
        public bool? RunAsync { get; set; }

        /// <summary>
        /// Specifies the security test to run.
        /// <para>If you specify a security test to be run, do not specify the testsuite and testcase options because TestEngine cannot run both functional tests and security tests within the same test job.</para>
        /// </summary>
        public string SecurityTest { get; set; }

        /// <summary>
        /// If this option is specified, the command-line tool will not scan the project for external dependencies. It helps you improve the performance of running large projects.
        /// </summary>
        public bool? SkipDependencies { get; set; }

        /// <summary>
        /// Specifies a list of tags to run.
        /// </summary>
        public IEnumerable<string> Tags { get; set; }

        /// <summary>
        /// Specifies the test case to run.
        /// </summary>
        public string TestCase { get; set; }

        /// <summary>
        /// Specifies the test suite to run.
        /// </summary>
        public string TestSuite { get; set; }

        /// <summary>
        /// Specifies a timeout for a test job run in seconds. If a test job runs for the specified amount of time, TestEngine stops it with the FAILED status.
        /// </summary>
        public int? TimeoutSeconds { get; set; }

        /// <summary>
        /// Return an error when the project returns a "FAILED" result.
        /// </summary>
        public bool? TreatFailedRunAsError { get; set; }

        /// <summary>
        /// Specifies the username used to connect to TestEngine.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Enables more detailed output.
        /// </summary>
        public bool? Verbose { get; set; }

        /// <summary>
        /// The endpoint to be used for HTTP requests sent by this test, in the format host:[port].
        /// </summary>
        public string EndPoint { get; set; }
    }
}
