namespace Bolt.Core.ExceptionHandling.Exceptions.Base
{
    using System;

    public abstract class ExternalException : BaseException
    {
        protected ExternalException(ErrorType errorType)
            : base(errorType)
        {
        }

        protected ExternalException(ErrorType errorType, Exception innerException)
            : base(errorType, innerException)
        {
        }
    }
}
