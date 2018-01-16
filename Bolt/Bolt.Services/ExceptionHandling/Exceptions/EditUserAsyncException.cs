namespace Bolt.Services.ExceptionHandling.Exceptions
{
    using System;

    using Core.ExceptionHandling;

    internal class EditUserAsyncException : Exception
    {
        internal EditUserAsyncException(ErrorType errorType)
            :this(errorType, null)
        {
        }

        internal EditUserAsyncException(ErrorType errorType, Exception innerException)
            : base(errorType.Message, innerException)
        {
            base.HResult = errorType.Code;
        }
    }
}
