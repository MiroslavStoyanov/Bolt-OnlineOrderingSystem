namespace Bolt.Services.ExceptionHandling.Exceptions
{
    using System;

    using Core.ExceptionHandling;

    internal class GetUserByUsernameException : Exception
    {
        internal GetUserByUsernameException(ErrorType errorType)
            :this(errorType, null)
        {
        }

        internal GetUserByUsernameException(ErrorType errorType, Exception innerException)
            : base(errorType.Message, innerException)
        {
            base.HResult = errorType.Code;
        }
    }
}
