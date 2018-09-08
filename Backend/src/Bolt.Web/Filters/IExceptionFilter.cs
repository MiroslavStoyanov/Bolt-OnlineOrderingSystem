namespace Bolt.Web.Filters
{
    using Microsoft.AspNetCore.Mvc.Filters;

    public interface IExceptionFilter : IFilterMetadata
    {
        void OnException(ExceptionContext context);
    }
}
