using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CustomMiddlewareExample.Exceptions
{
  public class ExceptionHandler : IExceptionHandler
  {
    private readonly IExceptionMapper _exceptionMapper;

    public ExceptionHandler(
      IExceptionMapper exceptionMapper
    ){
      _exceptionMapper = exceptionMapper;
    }
    public async Task HandleAsync(HttpContext context, Exception ex)
    {
      var error = _exceptionMapper.Resolve(ex);

      context.Response.StatusCode = error.Status;
      await context.Response.WriteAsync(JsonConvert.SerializeObject((object) new { error }));
    }
  }
}