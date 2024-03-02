using EduPulse.Api.Dtos;
using EduPulse.Domain.Common.Errors;
using EduPulse.Domain.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace EduPulse.Api.Rest.Middlewares;

public class ExceptionalMiddleware
{
    private readonly ILogger< ExceptionalMiddleware> _logger;
    private readonly RequestDelegate _next;

    public ExceptionalMiddleware(
        RequestDelegate next,
        ILogger< ExceptionalMiddleware> logger
        )
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (BusinessException exception)
        {
            _logger.LogWarning("Exception in middleware message | exception - {Exception}", exception);
            
            var errorDto = new ErrorDto
            {
                Kind = exception.ErrorKind,
                Code = exception.ErrorCode,
                Messages = new List<string>
                {
                    exception.ToString()
                }
            };

            context.Response.StatusCode = errorDto.Kind switch
            {
                ErrorKind.InvalidData => StatusCodes.Status400BadRequest,
                ErrorKind.InvalidOperation => StatusCodes.Status409Conflict,
                ErrorKind.NotFound => StatusCodes.Status404NotFound,
                ErrorKind.PermissionDenied => StatusCodes.Status403Forbidden,
                _ => StatusCodes.Status500InternalServerError
            };
            
            await context.Response.WriteAsJsonAsync(errorDto);
        }
        catch (Exception exception)
        {
            _logger.LogError("Exception in middleware message | exception - {Exception}", exception);
            
            var errorDto = new ErrorDto
            {
                Kind = ErrorKind.Unknown,
                Code = ErrorCode.Unknown,
                Messages = new List<string>
                {
                    exception.ToString()
                }
            };

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsJsonAsync(errorDto);
        }
    }
}