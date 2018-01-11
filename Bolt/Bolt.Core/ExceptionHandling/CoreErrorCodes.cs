namespace Bolt.Core.ExceptionHandling
{
    internal static class CoreErrorCodes
    {
        internal const int Min = 0x00001000;

        internal const int Max = 0x00001FFF;

        //Error Code Ranges 0x00001000 - 0x00001FFF

        internal static ErrorType ValueNull { get; } = new ErrorType(0x00001000, ExceptionMessages.ValueNullMessage);

        internal static ErrorType PatternNull { get; } = new ErrorType(0x00001001, ExceptionMessages.ValueNullMessage);

        internal static ErrorType RequireNullExceptionType { get; } = new ErrorType(0x00001002, ExceptionMessages.RequireNullExceptionTypeMessage);

        internal static ErrorType RequireNullErrorType { get; } = new ErrorType(0x00001003, ExceptionMessages.RequireNullExceptionTypeMessage);
    }
}
