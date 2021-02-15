using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Tools.ReadyAPI.TestEngine
{
    internal sealed class TestEngineRunner : Tool<TestEngineSettings>
    {
        private readonly IToolLocator _toolLocator;

        public TestEngineRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
            _toolLocator = tools;
        }

        // ReSharper disable once InconsistentNaming
        public int RunProject(string projectFile, TestEngineSettings settings)
        {
            if (string.IsNullOrWhiteSpace(projectFile))
            {
                throw new ArgumentNullException(nameof(projectFile));
            }

            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            var arguments = GetArguments(projectFile, settings);

            var scriptLocation = _toolLocator.Resolve("TestEngine.ps1");

            if (scriptLocation == null)
            {
                throw 
                    new FileNotFoundException
                    (
                    "Please verify that testengine-cli is properly installed!  If TestEngine.ps1 is not available in the global path, you must explicitly register the tool location.", 
                    "TestEngine.ps1"
                    );
            }

            arguments.Prepend($"\"{scriptLocation.FullPath}\"");
            arguments.Prepend("-File");

            using (var p = RunProcess(settings, arguments))
            {
                p.WaitForExit();

                return p.GetExitCode();
            }
        }

        protected override IEnumerable<string> GetToolExecutableNames() => new[] { "powershell", "powershell.exe" };

        protected override string GetToolName() => "powershell";

        internal static ProcessArgumentBuilder GetArguments(string projectFile, TestEngineSettings settings)
        {
            var arguments = new ProcessArgumentBuilder();

            if (!string.IsNullOrEmpty(settings.ConfigurationFile))
            {
                arguments.Append($"-c \"{settings.ConfigurationFile}\"");
            }

            if (!string.IsNullOrWhiteSpace(settings.Password))
            {
                arguments.Append($"-p {settings.Password}");
            }

            if (!string.IsNullOrWhiteSpace(settings.Username))
            {
                arguments.Append($"-u {settings.Username}");
            }

            if (!string.IsNullOrWhiteSpace(settings.Host))
            {
                arguments.Append($"-H {settings.Host}");
            }

            if (settings.Verbose == true)
            {
                arguments.Append("-v");
            }

            if (settings.Quiet == true)
            {
                arguments.Append("-q");
            }

            arguments.Append("run project");

            if (!string.IsNullOrWhiteSpace(settings.EndPoint))
            {
                arguments.Append($"endpoint={settings.EndPoint}");
            }

            if (!string.IsNullOrWhiteSpace(settings.TestCase))
            {
                arguments.Append($"testcase={settings.TestCase}");
            }

            if (!string.IsNullOrWhiteSpace(settings.Environment))
            {
                arguments.Append($"environment={settings.Environment}");
            }

            if (!string.IsNullOrWhiteSpace(settings.OutputFolder))
            {
                arguments.Append($"output={settings.OutputFolder}");
            }

            if (settings.ReportFormat.HasValue)
            {
                arguments.Append($"format={settings.ReportFormat.Value}");
            }

            if (settings.PrintReport == true)
            {
                arguments.Append("printReport");
            }

            if (settings.TreatFailedRunAsError == true)
            {
                arguments.Append("treatFailedRunAsError");
            }

            if (settings.PriorityJob == true)
            {
                arguments.Append("priorityJob");
            }

            if (!string.IsNullOrWhiteSpace(settings.ReportFileName))
            {
                arguments.Append($"reportFileName={settings.ReportFileName}");
            }

            if (settings.RunAsync == true)
            {
                arguments.Append("async");
            }

            if (!string.IsNullOrWhiteSpace(settings.SecurityTest))
            {
                arguments.Append($"securitytest={settings.SecurityTest}");
            }

            if (settings.SkipDependencies == true)
            {
                arguments.Append("skipdeps");
            }

            if (!string.IsNullOrWhiteSpace(settings.TestSuite))
            {
                arguments.Append($"testsuite={settings.TestSuite}");
            }

            if (settings.Tags != null && settings.Tags.Any())
            {
                arguments.Append($"tags={string.Join(",",settings.Tags)}");
            }

            if (settings.TimeoutSeconds.HasValue)
            {
                arguments.Append($"timeout={settings.TimeoutSeconds}");
            }

            if (!string.IsNullOrWhiteSpace(settings.ProjectPassword))
            {
                arguments.Append($"projectPassword={settings.ProjectPassword}");
            }

            if (!string.IsNullOrWhiteSpace(settings.ProxyHost))
            {
                arguments.Append($"proxyHost={settings.ProxyHost}");
            }

            if (settings.ProxyPort.HasValue)
            {
                arguments.Append($"proxyPort={settings.ProxyPort}");
            }

            if (!string.IsNullOrWhiteSpace(settings.ProxyUser))
            {
                arguments.Append($"proxyUser={settings.ProxyUser}");
            }

            if (!string.IsNullOrWhiteSpace(settings.ProxyPassword))
            {
                arguments.Append($"proxyPassword={settings.ProxyPassword}");
            }

            arguments.Append($"\"{projectFile}\"");

            return arguments;
        }
    }
}
