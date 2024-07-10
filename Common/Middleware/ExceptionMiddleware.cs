using System.Net;
using TestTask.Common.Exception;

namespace VpnBotApi.Common.Middleware
{
    public class ExceptionMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                if (typeof(HandledException) == ex.GetType())
                {
                    await HandleExceptionAsync(httpContext, (HandledException)ex);

                    if (((HandledException)ex).WriteToLog)
                    {
                        //Здесь могло бы быть логирование
                    }
                }
                else
                {
                    //Здесь могло бы быть логирование
                    await HandleExceptionAsync(httpContext, new HandledException("Произошла непредвиденная ошибка, мы уже работаем над ее устранением."));
                }
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, HandledException exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.Conflict;

            await context.Response.WriteAsync(Newtonsoft.Json.JsonConvert.SerializeObject(new { exception.Messages, exception.StackTrace }));
        }
    }
}
