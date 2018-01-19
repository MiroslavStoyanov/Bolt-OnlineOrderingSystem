namespace Bolt.Core.ExceptionHandling.Exceptions.Base
{
    using System;

    public abstract class AuthenticationException : ExternalException
    {
        protected AuthenticationException(ErrorType errorType)
            : base(errorType)
        {
        }

        protected AuthenticationException(ErrorType errorType, Exception innerException)
            : base(errorType, innerException)
        {
        }
    }
}
