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

            // Contains stdOut/stdErr buffered in-memory as string
            var stdOut = stdOutBuffer.ToString();
            var stdErr = stdErrBuffer.ToString();

             if (stdOut.Contains("")) {
                Console.WriteLine("We found your mounted samba share!");
            }
            else
            {
                Console.WriteLine("There is no mounted samba share.");

            }            

        }

    }
    
}
