namespace Bolt.Services.ExceptionHandling.Exceptions
{
    using System;

    using Core.ExceptionHandling;

    internal class GetAllProductsAsyncException : Exception
    {
        internal GetAllProductsAsyncException(ErrorType errorType)
            :this(errorType, null)
        {
        }

        internal GetAllProductsAsyncException(ErrorType errorType, Exception innerException)
            : base(errorType.Message, innerException)
        {
            base.HResult = errorType.Code;
        }
    }
}
