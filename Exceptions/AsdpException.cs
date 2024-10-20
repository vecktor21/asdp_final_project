using ASDP.FinalProject.Dtos.Sigex;
using CSharpFunctionalExtensions;

namespace ASDP.FinalProject.Exceptions
{
    public class AsdpException : Exception
    {
        public Result Result { get; }

        public AsdpException(Result result) : base(result.Error)
        {
            Result = result;
        }
        public AsdpException(Result result, Exception exception) : base(result.Error, exception)
        {
            Result = result;
        }
    }

    public class SigexException : AsdpException
    {

        public SigexException(SigexResponse response) : base(Result.Failure("Sigex: " + response.Message))
        {
        }
        public SigexException(SigexResponse response, Exception exception) : base(Result.Failure("Sigex: " + response.Message), exception)
        {
        }
    }
}
