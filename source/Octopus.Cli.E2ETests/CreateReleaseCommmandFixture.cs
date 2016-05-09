using System;
using System.IO;
using System.Reflection;
using System.Text;
using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;
using Octopus.Cli.E2ETests.Util;
using Octopus.Cli.Util;

namespace Octopus.Cli.E2ETests
{
    [UseReporter(typeof(DiffReporter))]
    public class CreateReleaseCommmandFixture
    {
        [Test]
        public void PreventAutoChannelAndChannelArguments()
        {
            var octoexe = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().FullLocalPath()), "octo.exe");
            var args = new StringBuilder("create-release --server=https://localhost:8085 --apiKey=API-123 --project OctoFX ");
            var output = new StringBuilder();
            var result = SilentProcessRunner.ExecuteCommand(octoexe, args.Append("--autochannel --channel=Default").ToString(), Environment.CurrentDirectory, info => output.AppendLine(info), error => output.AppendLine(error));
            Approvals.Verify(output);
        }
    }
}
