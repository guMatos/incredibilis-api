using System;
using System.Threading.Tasks;
using Incredibilis.Domain.Error;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Incredibilis.Presentation.Middleware
{
    public class ExceptionHelper : IExceptionHelper
    {
        public async Task Handle(HttpContext context, Func<Task> next)
        {
            try
            {
                await next.Invoke();
            }
            catch (Exception ex)
            {
                await WriteResponse(500, (int)ErrorCode.ServerError, ex.Message, context);
            }
        }

        private async Task WriteResponse(int httpStatus, int errorCode, string messageContent, HttpContext context)
        {
            context.Response.StatusCode = httpStatus;
            var messageJson = JsonConvert.SerializeObject(new { code = errorCode, message = messageContent });

            await context.Response.WriteAsync(messageJson);
        }
    }
}
