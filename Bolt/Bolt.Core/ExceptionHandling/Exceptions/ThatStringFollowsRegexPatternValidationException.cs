namespace Bolt.Core.ExceptionHandling.Exceptions
{
    using System;

    internal class ThatStringFollowsRegexPatternValidationException : Exception
    {
        internal ThatStringFollowsRegexPatternValidationException(ErrorType errorType)
            :this(errorType, null)
        {
        }

        internal ThatStringFollowsRegexPatternValidationException(ErrorType errorType, Exception innerException)
            : base(errorType.Message, innerException)
        {
            base.HResult = errorType.Code;
        }
    }
}
