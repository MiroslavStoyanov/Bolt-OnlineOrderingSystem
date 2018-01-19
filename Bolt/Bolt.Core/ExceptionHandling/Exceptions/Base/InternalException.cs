namespace Bolt.Core.ExceptionHandling.Exceptions.Base
{
    using System;

    public abstract class InternalException : BaseException
    {
        protected InternalException(ErrorType errorType) 
            : base(errorType)
        {
        }

        protected InternalException(ErrorType errorType, Exception innerException) 
            : base(errorType, innerException)
        {
        }
    }
}
