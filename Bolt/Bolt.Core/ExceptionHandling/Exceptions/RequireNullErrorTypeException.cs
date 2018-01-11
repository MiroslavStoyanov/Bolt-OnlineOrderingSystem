namespace Bolt.Core.ExceptionHandling.Exceptions
{
    using System;

    internal class RequireNullErrorTypeException : Exception
    {
        internal RequireNullErrorTypeException(ErrorType errorType)
            :this(errorType, null)
        {
        }

        internal RequireNullErrorTypeException(ErrorType errorType, Exception innerException)
            : base(errorType.Message, innerException)
        {
            base.HResult = errorType.Code;
        }
    }
}
