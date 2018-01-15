using System;
using Bolt.Core.ExceptionHandling;

namespace Bolt.Services.ExceptionHandling.Exceptions
{
    public class DeleteProductAsyncException : Exception
    {
        internal DeleteProductAsyncException(ErrorType errorType)
            :this(errorType, null)
        {
        }

        internal DeleteProductAsyncException(ErrorType errorType, Exception innerException)
            : base(errorType.Message, innerException)
        {
            base.HResult = errorType.Code;
        }
    }
}
