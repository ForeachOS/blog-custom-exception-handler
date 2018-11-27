using System;

namespace CustomMiddlewareExample.Exceptions
{
  public interface IExceptionMapper
  {
    Error Resolve(Exception exception);
  }
}