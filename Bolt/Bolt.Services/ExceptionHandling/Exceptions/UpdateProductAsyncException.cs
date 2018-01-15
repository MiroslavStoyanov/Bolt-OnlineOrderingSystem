namespace Bolt.Services.ExceptionHandling.Exceptions
{
    using System;

    using Core.ExceptionHandling;

    public class UpdateProductAsyncException : Exception
    {
        internal UpdateProductAsyncException(ErrorType errorType)
            :this(errorType, null)
        {
        }

        internal UpdateProductAsyncException(ErrorType errorType, Exception innerException)
            : base(errorType.Message, innerException)
        {
            base.HResult = errorType.Code;
        }
    }
}
