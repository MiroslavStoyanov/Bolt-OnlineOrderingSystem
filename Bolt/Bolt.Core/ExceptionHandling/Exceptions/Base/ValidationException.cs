namespace Bolt.Core.ExceptionHandling.Exceptions.Base
{
    using System;

    public abstract class ValidationException : ExternalException
    {
        protected ValidationException(ErrorType errorType)
            : base(errorType)
        {
        }

        protected ValidationException(ErrorType errorType, Exception innerException)
            : base(errorType, innerException)
        {
        }
    }
}
