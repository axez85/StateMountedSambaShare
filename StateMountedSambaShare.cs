using System.Threading.Tasks;
using CliWrap;
using CliWrap.Buffered;

namespace StateMountedSambaShare
{
    class StateMountedSambaShare
    {
        static async Task Main(string[] args)
        {
            var result = await Cli.Wrap("findmnt")
                .WithArguments("-t cifs,nfs4")
            //    .WithWorkingDirectory("work/dir/path")
                .WithStandardOutputPipe(PipeTarget.ToStringBuilder(stdOutBuffer))
                .WithStandardErrorPipe(PipeTarget.ToStringBuilder(stdErrBuffer))

                .ExecuteBufferedAsync();
        }

    }
    
}
