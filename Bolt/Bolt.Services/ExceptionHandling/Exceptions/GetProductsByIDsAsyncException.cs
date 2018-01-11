namespace Bolt.Services.ExceptionHandling.Exceptions
{
    using System;

    using Core.ExceptionHandling;

    internal class GetProductsByIDsAsyncException : Exception
    {
        internal GetProductsByIDsAsyncException(ErrorType errorType)
            :this(errorType, null)
        {
        }

        internal GetProductsByIDsAsyncException(ErrorType errorType, Exception innerException)
            : base(errorType.Message, innerException)
        {
            base.HResult = errorType.Code;
        }
    }
}
