namespace Bolt.Services.ExceptionHandling.Exceptions
{
    using System;

    using Core.ExceptionHandling;

    internal class GetUserIdByUsernameException : Exception
    {
        internal GetUserIdByUsernameException(ErrorType errorType)
            :this(errorType, null)
        {
        }

        internal GetUserIdByUsernameException(ErrorType errorType, Exception innerException)
            : base(errorType.Message, innerException)
        {
            base.HResult = errorType.Code;
        }
    }
}
