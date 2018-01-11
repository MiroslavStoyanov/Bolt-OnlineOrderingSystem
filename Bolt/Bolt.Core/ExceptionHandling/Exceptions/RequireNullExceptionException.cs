namespace Bolt.Core.ExceptionHandling.Exceptions
{
    using System;

    internal class RequireNullExceptionException : Exception
    {
        internal RequireNullExceptionException(ErrorType errorType)
            :this(errorType, null)
        {
        }

        internal RequireNullExceptionException(ErrorType errorType, Exception innerException)
            : base(errorType.Message, innerException)
        {
            base.HResult = errorType.Code;
        }
    }
}
