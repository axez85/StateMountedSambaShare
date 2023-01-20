using System;
using System.Text;
using System.Threading.Tasks;
using CliWrap;
using CliWrap.Buffered;

namespace StateMountedSambaShare
{
    class StateMountedSambaShare
    {
        static async Task Main(string[] args)
        {
            var stdOutBuffer = new StringBuilder();
            var stdErrBuffer = new StringBuilder();

            var result = await Cli.Wrap("findmnt")
                .WithArguments("-t cifs,nfs4")
            //    .WithWorkingDirectory("work/dir/path")
                .WithStandardOutputPipe(PipeTarget.ToStringBuilder(stdOutBuffer))
                .WithStandardErrorPipe(PipeTarget.ToStringBuilder(stdErrBuffer))
                .ExecuteBufferedAsync();

            // Result contains:
            // -- result.ExitCode        (int)
            // -- result.StartTime       (DateTimeOffset)
            // -- result.ExitTime        (DateTimeOffset)
            // -- result.RunTime         (TimeSpan)

            // Contains stdOut/stdErr buffered in-memory as string
            var stdOut = stdOutBuffer.ToString();
            var stdErr = stdErrBuffer.ToString();

            // Replace white url to mouned shares
             if (stdOut.Contains("/mnt/")) {
                Console.WriteLine("We found your mounted samba share!");

            }
            else
            {
                Console.WriteLine("There is no mounted samba share.");

                //Reboot the server
                var reboot = await Cli.Wrap("sudo")
                .WithArguments("reboot")
                .ExecuteBufferedAsync();
            }            

        }

    }
    
}
