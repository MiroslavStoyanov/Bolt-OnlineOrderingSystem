namespace Bolt.Core.ExceptionHandling.Exceptions.Base
{
    using System;

    public abstract class BaseException : Exception
    {
        protected BaseException(ErrorType errorType)
            : this(errorType, (Exception) null)
        {
        }

        protected BaseException(ErrorType errorType, Exception innerException)
            : base(errorType.Message, (Exception) innerException)
        {
            base.HResult = errorType.Code;
        }
    }
}
