namespace Bolt.Services.ExceptionHandling.Exceptions
{
    using System;

    using Core.ExceptionHandling;

    internal class GetOrdersForUserException : Exception
    {
        internal GetOrdersForUserException(ErrorType errorType)
            :this(errorType, null)
        {
        }

        internal GetOrdersForUserException(ErrorType errorType, Exception innerException)
            : base(errorType.Message, innerException)
        {
            base.HResult = errorType.Code;
        }
    }
}
