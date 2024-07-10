using VpnBotApi.Common.Middleware;

namespace TestTask.Common.Extension;

public static class ExceptionMiddlewareExtension
{
    public static IApplicationBuilder AddExceptionMiddlewareExtension(this IApplicationBuilder app)
    {

        app.UseMiddleware<ExceptionMiddleware>();

        return app;
    }
}
