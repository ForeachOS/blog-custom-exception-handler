using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CustomMiddlewareExample.Exceptions
{
  public interface IExceptionHandler
  {
    Task HandleAsync(HttpContext context, Exception ex);
  }
}