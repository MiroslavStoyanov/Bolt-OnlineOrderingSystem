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

        internal const string GetAllProductsMessage = "Failed to get all products. Please try again.";

        internal const string GetProductsByIDsMessage = "Failed to get the product Ids. Please try again.";

        internal const string AddProductMessage = "Failed to add the product to the basket. Please try again.";

        internal const string AddProductModelNullMessage = "The model cannot be null or empty.";

        internal const string UpdateProductNullProductIdMessage = "The product Id cannot be null or empty.";

        internal const string UpdateProductNullModelMessage = "The model cannot be null or empty.";

        internal const string UpdateProductMessage = "Failed to update the product. Please try again.";

        internal const string DeleteProductMessage = "Failed to delete the product. Please try again.";

        internal const string DeleteProductNullIdMessage = "The product Id cannot be null or empty.";

        internal const string GetUserByUsernameMessage = "Failed to get the user by username. Please try again.";

        internal const string GetUserByUsernameNullStringMessage = "The ussername cannot be null or empty.";

        internal const string EditUserAsyncUsernameNullMessage = "The username cannot be null or empty.";

        internal const string EditUserAsyncModelNullMessage = "The User DTO model cannot be null or empty.";

        internal const string CommitTransactionMessage = "Failed to commit the transaction.";

        internal const string EditUserMessage = "Failed to edit the user. Please try again.";

        internal const string GetUserIdByUsernameNullUsernameMessage = "The username cannot be null or empty.";

        internal const string GetUserIdByUsernameMessage = "Failed to get the username given the current user Id. Please try again.";

        internal const string AddOrderAsyncProductsNullMessage = "The products in the Order DTO are null.";
    }
}
