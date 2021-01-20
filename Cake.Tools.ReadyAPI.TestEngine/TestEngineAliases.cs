using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Tools.ReadyAPI.TestEngine
{
    /// <summary>
    /// <para>
    /// <code>#addin Cake.Tools.ReadyAPI.TestEngine</code>
    /// </para>
    /// <para>
    /// If TestEngine.ps1 is not included in the PATH you will have to provide the location of TestEngine.cmd as such
    /// <example>
    /// <code>
    /// Setup(context => {
    ///     context.Tools.RegisterFile("C:/Program Files/SmartBear/ReadyAPI-3.5.1/bin/testengine.cmd");
    /// });
    /// </code>
    /// </example>
    /// </para>
    /// </summary>
    [CakeAliasCategory("ReadyAPITestEngine")]
    public static class TestEngineAliases
    {
        /// <summary>
        /// Run your ReadyAPI functional test(s).
        /// <example>
        /// <code>
        /// var result = RunProject
        /// (
        ///     "your-readyapi-project.xml",
        ///     new TestEngineSettings()
        ///     {
        ///         EndPoint = "http://localhost",
        ///         PrintReport = true
        ///     }
        /// );
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="projectFile">The ReadyAPI project.</param>
        /// <param name="settings">The settings that will be provided to TestEngine.cmd.</param>
        /// <returns></returns>
        [CakeMethodAlias]
        public static int RunProject(this ICakeContext context, string projectFile, TestEngineSettings settings)
        {
            return
                new TestEngineRunner
                (
                    context.FileSystem,
                    context.Environment,
                    context.ProcessRunner,
                    context.Tools
                )
                .RunProject
                (
                    projectFile, 
                    settings
                );
        }
    }
}
