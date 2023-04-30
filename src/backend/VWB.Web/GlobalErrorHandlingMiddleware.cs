using Newtonsoft.Json;
using System.Net;
using VWB.App.Exceptions;

namespace RWA.Web
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Dictionary<Type, Func<HttpContext, Exception, Result>> _handlers = new();

        public GlobalErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;

            _handlers = new()
            {
                {
                    typeof(BusinessException),
                    (c, e) => new Result(HttpStatusCode.BadRequest, ((BusinessException)e).Code, e.Message, e.InnerException?.ToString())
                }
            };
        }

        public class Result
        {
            public Result(HttpStatusCode status, int code, string message, string? innerException)
            {
                Status = status;
                Code = code;
                Message = message;
                InnerException = innerException;
            }

            [JsonIgnore]
            public HttpStatusCode Status { get; }
            public int Code { get; }
            public string Message { get; }
            public string? InnerException { get; }
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                Result res;

                if (_handlers.TryGetValue(ex.GetType(), out var handler))
                    res = handler.Invoke(context, ex);
                else
                    res = new Result(HttpStatusCode.InternalServerError, 0, ex.Message, ex.InnerException?.ToString());

                var exResult = JsonConvert.SerializeObject(res);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)res.Status;

                await context.Response.WriteAsync(exResult);
            }
        }
    }
}
