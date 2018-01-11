namespace Bolt.Services.ExceptionHandling.Exceptions
{
    using System;

    using Core.ExceptionHandling;

    internal class GetOrdersForUsernameException : Exception
    {
        internal GetOrdersForUsernameException(ErrorType errorType)
            :this(errorType, null)
        {
        }

        internal GetOrdersForUsernameException(ErrorType errorType, Exception innerException)
            : base(errorType.Message, innerException)
        {
            base.HResult = errorType.Code;
        }
    }
}
