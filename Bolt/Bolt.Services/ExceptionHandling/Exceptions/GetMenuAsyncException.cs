namespace Bolt.Services.ExceptionHandling.Exceptions
{
    using System;

    using Core.ExceptionHandling;

    internal class GetMenuAsyncException : Exception
    {
        internal GetMenuAsyncException(ErrorType errorType)
            :this(errorType, null)
        {
        }

        internal GetMenuAsyncException(ErrorType errorType, Exception innerException)
            : base(errorType.Message, innerException)
        {
            base.HResult = errorType.Code;
        }
    }
}
