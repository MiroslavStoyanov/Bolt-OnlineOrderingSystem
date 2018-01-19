namespace Bolt.Core.ExceptionHandling.Exceptions.Base
{
    using System;

    public abstract class AuthorizationException : ExternalException
    {
        protected AuthorizationException(ErrorType errorType)
            : base(errorType)
        {
        }

        protected AuthorizationException(ErrorType errorType, Exception innerException)
            : base(errorType, innerException)
        {
        }
    }
}
