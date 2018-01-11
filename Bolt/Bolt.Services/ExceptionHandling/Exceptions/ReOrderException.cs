namespace Bolt.Services.ExceptionHandling.Exceptions
{
    using System;

    using Core.ExceptionHandling;

    internal class ReOrderException : Exception
    { 
        internal ReOrderException(ErrorType errorType)
            :this(errorType, null)
        {
        }

        internal ReOrderException(ErrorType errorType, Exception innerException)
            : base(errorType.Message, innerException)
        {
            base.HResult = errorType.Code;
        }
    }
}
