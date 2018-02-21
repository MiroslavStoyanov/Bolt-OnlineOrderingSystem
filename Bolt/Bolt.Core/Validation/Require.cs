namespace Bolt.Core.Validation
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;

    using ExceptionHandling;
    using System.Text.RegularExpressions;

    public static class Require
    {
          public static void ThatArgument(bool isValid, Type exceptionType, string exceptionMessage)
        {
            if (isValid)
            {
                return;
            }

            ThrowException(exceptionType, exceptionMessage);
        }

        public static void ThatObjectIsNotNull(object argument, Type exceptionType, string exceptionMessage)
        {
            if (argument != null)
            {
                return;
            }

            ThrowException(exceptionType, exceptionMessage);
        }

        public static void ThatStringIsNotNullOrEmpty(string argument, Type exceptionType, string exceptionMessage)
        {
            if (!string.IsNullOrEmpty(argument))
            {
                return;
            }

            ThrowException(exceptionType, exceptionMessage);
        }

        public static void ThatGuidIsNotNullOrEmpty(Guid? guid, Type exceptionType, string exceptionMessage)
        {
            if (guid != null && guid != new Guid())
            {
                return;
            }

            ThrowException(exceptionType, exceptionMessage);
        }

        public static void ThatIntIsNotNull(int? number, Type exceptionType, string exceptionMessage)
        {
            if (number != null)
            {
                return;
            }

            ThrowException(exceptionType, exceptionMessage);
        }

        public static void ThatCollectionIsNotNullAndEmpty<TCollectionType>(ICollection<TCollectionType> elements, Type exceptionType, string exceptionMessage)
        {
            if (elements != null && elements.Count != 0)
            {
                return;
            }

            ThrowException(exceptionType, exceptionMessage);
        }

        public static void ThatStringFollowsRegexPattern(string value, string pattern, Type exceptionType, string exceptionMessage)
        {
            ThatStringIsNotNullOrEmpty(value, typeof(ArgumentException), ExceptionMessages.ValueNullMessage);
            ThatStringIsNotNullOrEmpty(pattern, typeof(ArgumentException), ExceptionMessages.ValueNullMessage);

            var regex = new Regex(pattern);

            if (regex.IsMatch(value))
            {
                return;
            }

            ThrowException(exceptionType, exceptionMessage);
        }

        private static void ThrowException(Type exceptionType, string exceptionMessage)
        {
            if (exceptionType == null)
            {
                throw new ArgumentNullException(ExceptionMessages.RequireNullExceptionTypeMessage);
            }

            if (exceptionMessage == null)
            {
                throw new ArgumentException(ExceptionMessages.RequireNullExceptionMessage);
            }

            ConstructorInfo ctrs = exceptionType
                .GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                .First(n => n.GetParameters().Length == 1);
            var ex = (Exception)ctrs.Invoke(new object[] { exceptionMessage });

            throw ex;
        }
    }
}
