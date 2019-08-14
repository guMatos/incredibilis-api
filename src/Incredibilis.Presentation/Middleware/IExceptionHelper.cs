using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Incredibilis.Presentation.Middleware
{
    public interface IExceptionHelper
    {
        Task Handle(HttpContext context, Func<Task> next);
    }
}
