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
}
