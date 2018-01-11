namespace Bolt.Core.Validation
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;

    using ExceptionHandling;
    using ExceptionHandling.Exceptions;
    using System.Text.RegularExpressions;

    public static class Require
    {
          public static void ThatArgument(bool isValid, Type exceptionType, ErrorType errorType)
        {
            if (isValid)
            {
                return;
            }

            ThrowException(exceptionType, errorType);
        }

        public static void ThatObjectIsNotNull(object argument, Type exceptionType, ErrorType errorType)
        {
            if (argument != null)
            {
                return;
            }

            ThrowException(exceptionType, errorType);
        }

        public static void ThatStringIsNotNullOrEmpty(string argument, Type exceptionType, ErrorType errorType)
        {
            if (!string.IsNullOrEmpty(argument))
            {
                return;
            }

            ThrowException(exceptionType, errorType);
        }

        public static void ThatGuidIsNotNullOrEmpty(Guid? guid, Type exceptionType, ErrorType errorType)
        {
            if (guid != null && guid != new Guid())
            {
                return;
            }

            ThrowException(exceptionType, errorType);
        }

        public static void ThatIntIsNotNull(int? number, Type exceptionType, ErrorType errorType)
        {
            if (number != null)
            {
                return;
            }

            ThrowException(exceptionType, errorType);
        }

        public static void ThatCollectionIsNotNullAndEmpty<TCollectionType>(ICollection<TCollectionType> elements, Type exceptionType, ErrorType errorType)
        {
            if (elements != null && elements.Count != 0)
            {
                return;
            }

            ThrowException(exceptionType, errorType);
        }

        public static void ThatStringFollowsRegexPattern(string value, string pattern, Type exceptionType, ErrorType errorType)
        {
            ThatStringIsNotNullOrEmpty(value, typeof(ThatStringFollowsRegexPatternValidationException), CoreErrorCodes.ValueNull);
            ThatStringIsNotNullOrEmpty(pattern, typeof(ThatStringFollowsRegexPatternValidationException), CoreErrorCodes.ValueNull);

            var regex = new Regex(pattern);

            if (regex.IsMatch(value))
            {
                return;
            }

            ThrowException(exceptionType, errorType);
        }

        private static void ThrowException(Type exceptionType, ErrorType errorType)
        {
            if (exceptionType == null)
            {
                throw new RequireNullExceptionException(CoreErrorCodes.RequireNullExceptionType);
            }

            if (errorType == null)
            {
                throw new RequireNullErrorTypeException(CoreErrorCodes.RequireNullErrorType);
            }

            // TODO: Improve this code, add type verification for constructors
            ConstructorInfo ctrs = exceptionType
                .GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                .First(n => n.GetParameters().Length == 1);
            var ex = (Exception)ctrs.Invoke(new object[] { errorType });

            throw ex;
        }
    }
}
