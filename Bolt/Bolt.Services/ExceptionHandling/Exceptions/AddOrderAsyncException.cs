namespace Bolt.Services.ExceptionHandling.Exceptions
{
    using System;

    using Core.ExceptionHandling;

    internal class AddOrderAsyncException : Exception
    {
        internal AddOrderAsyncException(ErrorType errorType)
            :this(errorType, null)
        {
        }

        internal AddOrderAsyncException(ErrorType errorType, Exception innerException)
            : base(errorType.Message, innerException)
        {
            base.HResult = errorType.Code;
        }
    }
}
