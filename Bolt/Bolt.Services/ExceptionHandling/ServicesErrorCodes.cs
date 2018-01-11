namespace Bolt.Services.ExceptionHandling
{
    using Core.ExceptionHandling;

    internal static class ServicesErrorCodes
    {
        internal const int Min = 0x0000D000;

        internal const int Max = 0x0000DFFF;

        //Error Code Ranges 0x0000D000 - 0x0000DFFF

        internal static ErrorType GetMenuAsync = new ErrorType(0x0000D001, ExceptionMessages.GetMenuAsyncMessage);

        internal static ErrorType ReOrder = new ErrorType(0x0000D002, ExceptionMessages.GetMenuAsyncMessage);

        internal static ErrorType AddOrderAsync = new ErrorType(0x0000D003, ExceptionMessages.GetMenuAsyncMessage);

        internal static ErrorType GetOrderStatusAsync = new ErrorType(0x0000D004, ExceptionMessages.GetMenuAsyncMessage);

        internal static ErrorType GetOrdersForUser = new ErrorType(0x0000D005, ExceptionMessages.GetOrdersForUserMessage);

        internal static ErrorType GetOrdersForUsername = new ErrorType(0x0000D006, ExceptionMessages.GetOrdersForUsernameMessage);
    }
}
