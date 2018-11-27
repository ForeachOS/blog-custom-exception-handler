using System;
using System.Collections.Generic;
using System.Net;

namespace CustomMiddlewareExample.Exceptions
{
  public class ExceptionMapper : IExceptionMapper
  {
    private readonly Dictionary<Type, Error> _errorMappings = new Dictionary<Type, Error>
    {
      {
        typeof(UnauthorizedAccessException),
        new Error
        {
          Title = "Unauthorized access",
          Code = "UNAUTH",
          Status = (int)HttpStatusCode.Unauthorized
          }
      },
      {
        typeof(NullReferenceException),
        new Error
        {
          Title = "Not found",
          Code = "NOTFOUND",
          Status = (int)HttpStatusCode.NotFound
          }
      },
      {
        typeof(Exception),
        new Error
        {
          Title = "General error",
          Code = "GENERAL",
          Status = (int)HttpStatusCode.InternalServerError
          }
      }
    };
    public Error Resolve(Exception ex)
    {
      Type exceptionType = ex.GetType() ?? typeof(Exception);
      if(!_errorMappings.TryGetValue(exceptionType, out var error))
      {
        error = _errorMappings[typeof(Exception)];
      }
      return error;
    }
  }
}