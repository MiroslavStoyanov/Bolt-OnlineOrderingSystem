namespace Bolt.Services.ExceptionHandling
{
    internal static class ExceptionMessages
    {
        internal const string GetMenuAsyncMessage = "Failed to get the menu, please try again.";

        internal const string ReOrderMessage = "Failed to re-order, please try again.";

        internal const string AddOrderAsyncMessage = "Failed to add the order to the cart, please try again.";

        internal const string GetOrderStatusAsyncMessage = "Failed to get the order status, please try again.";

        internal const string GetOrdersForUserMessage = "Failed to get the orders fpr the current user, please try again.";

        internal const string GetOrdersForUsernameMessage = "Failed to get the orders fpr the current username, please try again.";

        internal const string GetProductDetailsMessage = "Failed to get the product details, please try again.";

        internal const string GetProductDetailsProductIdNullMessage = "The product Id cannot be null or empty.";

        internal const string GetAllProductsMessage = "Failed to get all products. Please try again.";

        internal const string GetProductsByIDsMessage = "Failed to get the product Ids. Please try again.";
    }
}
