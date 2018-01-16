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

        internal static ErrorType AddProduct { get; } = new ErrorType(0x0000D011, ExceptionMessages.AddProductMessage);

        internal static ErrorType AddProductModelNull { get; } = new ErrorType(0x0000D012, ExceptionMessages.AddProductModelNullMessage);

        internal static ErrorType UpdateProductNullProductId { get; } = new ErrorType(0x0000D013, ExceptionMessages.UpdateProductNullProductIdMessage);

        internal static ErrorType UpdateProductNullModel { get; } = new ErrorType(0x0000D014, ExceptionMessages.UpdateProductNullModelMessage);

        internal static ErrorType UpdateProduct { get; } = new ErrorType(0x0000D015, ExceptionMessages.UpdateProductMessage);

        internal static ErrorType DeleteProduct { get; } = new ErrorType(0x0000D016, ExceptionMessages.DeleteProductMessage);

        internal static ErrorType DeleteProductNullId { get; } = new ErrorType(0x0000D017, ExceptionMessages.DeleteProductNullIdMessage);

        internal static ErrorType GetUserByUsername { get; } = new ErrorType(0x0000D018, ExceptionMessages.GetUserByUsernameMessage);

        internal static ErrorType GetUserByUsernameNullString { get; } = new ErrorType(0x0000D019, ExceptionMessages.GetUserByUsernameNullStringMessage);

        internal static ErrorType EditUserAsyncUsernameNull { get; } = new ErrorType(0x0000D020, ExceptionMessages.EditUserAsyncUsernameNullMessage);

        internal static ErrorType EditUserAsyncModelNull { get; } = new ErrorType(0x0000D021, ExceptionMessages.EditUserAsyncModelNullMessage);

        internal static ErrorType CommitTransaction { get; } = new ErrorType(0x0000D022, ExceptionMessages.CommitTransactionMessage);

        internal static ErrorType EditUser { get; } = new ErrorType(0x0000D023, ExceptionMessages.EditUserMessage);

        internal static ErrorType GetUserIdByUsernameNullUsername { get; } = new ErrorType(0x0000D024, ExceptionMessages.GetUserIdByUsernameNullUsernameMessage);

        internal static ErrorType GetUserIdByUsername { get; } = new ErrorType(0x0000D025, ExceptionMessages.GetUserIdByUsernameMessage);
    }
}
