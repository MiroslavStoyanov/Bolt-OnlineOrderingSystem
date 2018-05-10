namespace Bolt.Web.Infrastructure.Configurations
{
    using System.Net;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Http;
    using Statics;

    internal static class ExceptionHandlerConfiguration
    {
        internal static void AddExceptionHandler(IApplicationBuilder app)
            => app.UseExceptionHandler(options =>
            {
                options.Run(
                    async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        context.Response.ContentType = GlobalConstants.ExceptionHandlerContentType;
                        IExceptionHandlerFeature ex = context.Features.Get<IExceptionHandlerFeature>();
                        if (ex != null)
                        {
                            string err = $"<h1>Error: {ex.Error.Message}</h1>{ex.Error.StackTrace}";
                            await context.Response.WriteAsync(err).ConfigureAwait(false);
                        }
                    });
            });
    }
}
