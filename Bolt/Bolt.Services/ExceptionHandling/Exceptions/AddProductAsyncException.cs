namespace Bolt.Services.ExceptionHandling.Exceptions
{
    using System;

    using Core.ExceptionHandling;

    public class AddProductAsyncException : Exception
    {
        internal AddProductAsyncException(ErrorType errorType)
            :this(errorType, null)
        {
        }

        internal AddProductAsyncException(ErrorType errorType, Exception innerException)
            : base(errorType.Message, innerException)
        {
            base.HResult = errorType.Code;
        }
    }
}
