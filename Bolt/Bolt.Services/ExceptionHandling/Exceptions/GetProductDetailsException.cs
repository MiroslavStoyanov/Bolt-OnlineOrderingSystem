namespace Bolt.Services.ExceptionHandling.Exceptions
{
    using System;

    using Core.ExceptionHandling;

    internal class GetProductDetailsException : Exception
    {
        internal GetProductDetailsException(ErrorType errorType)
            :this(errorType, null)
        {
        }

        internal GetProductDetailsException(ErrorType errorType, Exception innerException)
            : base(errorType.Message, innerException)
        {
            base.HResult = errorType.Code;
        }
    }
}
