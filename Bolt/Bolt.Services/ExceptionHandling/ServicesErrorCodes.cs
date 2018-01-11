namespace Bolt.Services.ExceptionHandling
{
    using Core.ExceptionHandling;

    internal static class ServicesErrorCodes
    {
        internal const int Min = 0x0000D000;

        internal const int Max = 0x0000DFFF;

        //Error Code Ranges 0x0000D000 - 0x0000DFFF

        internal static ErrorType GetMenuAsync { get; }= new ErrorType(0x0000D001, ExceptionMessages.GetMenuAsyncMessage);

        internal static ErrorType ReOrder { get; } = new ErrorType(0x0000D002, ExceptionMessages.GetMenuAsyncMessage);

        internal static ErrorType AddOrderAsync { get; }= new ErrorType(0x0000D003, ExceptionMessages.GetMenuAsyncMessage);

        internal static ErrorType GetOrderStatusAsync { get; } = new ErrorType(0x0000D004, ExceptionMessages.GetMenuAsyncMessage);

        internal static ErrorType GetOrdersForUser { get; } = new ErrorType(0x0000D005, ExceptionMessages.GetOrdersForUserMessage);

        internal static ErrorType GetOrdersForUsername { get; } = new ErrorType(0x0000D006, ExceptionMessages.GetOrdersForUsernameMessage);

        internal static ErrorType GetProductDetails { get; } = new ErrorType(0x0000D007, ExceptionMessages.GetProductDetailsMessage);

        internal static ErrorType GetProductDetailsProductIdNull { get; } = new ErrorType(0x0000D008, ExceptionMessages.GetProductDetailsProductIdNullMessage);

        internal static ErrorType GetAllProducts { get; } = new ErrorType(0x0000D009, ExceptionMessages.GetAllProductsMessage);

        internal static ErrorType GetProductsByIDs { get; } = new ErrorType(0x0000D010, ExceptionMessages.GetProductsByIDsMessage);
    }
}
