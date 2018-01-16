using System;
using Bolt.Core.ExceptionHandling;

namespace Bolt.Services.ExceptionHandling.Exceptions
{
    internal class GetUserByUsernameAsyncException : Exception
    {
        internal GetUserByUsernameAsyncException(ErrorType errorType)
            :this(errorType, null)
        {
        }

        internal GetUserByUsernameAsyncException(ErrorType errorType, Exception innerException)
            : base(errorType.Message, innerException)
        {
            base.HResult = errorType.Code;
        }
    }
}
