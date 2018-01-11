namespace Bolt.Services.ExceptionHandling.Exceptions
{
    using System;

    using Core.ExceptionHandling;

    internal class GetOrderStatusAsyncException : Exception
    {
        internal GetOrderStatusAsyncException(ErrorType errorType)
            :this(errorType, null)
        {
        }

        internal GetOrderStatusAsyncException(ErrorType errorType, Exception innerException)
            : base(errorType.Message, innerException)
        {
            base.HResult = errorType.Code;
        }
    }
}
