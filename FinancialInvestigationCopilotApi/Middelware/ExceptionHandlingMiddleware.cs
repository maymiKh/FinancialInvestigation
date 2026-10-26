using FinancialInvetigationApp.Common.Exceptions;
using FluentValidation;
using System.Net;

namespace FinancialInvestigationCopilotApi.Middelware
{
    public class ExceptionHandlingMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(
        HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException exception)
            {
                await HandleValidationException(
                    context,
                    exception);
            }
            catch (NotFoundExceptions exception)
            {
                await HandleNotFoundException(
                    context,
                    exception);
            }
            catch (Exception exception)
            {
                _logger.LogError(
                    exception,
                    "Unhandled exception.");

                await HandleUnexpectedException(context);
            }
        }

        private static async Task HandleNotFoundException(HttpContext context, NotFoundExceptions exception)
        {
            context.Response.StatusCode =
                (int)HttpStatusCode.NotFound;

            await context.Response.WriteAsJsonAsync(new
            {
                status = 404,
                error = "Not Found",
                message = exception.Message
            });
        }

        private static async Task HandleValidationException(HttpContext context, ValidationException exception)
        {
            context.Response.StatusCode =
                (int)HttpStatusCode.BadRequest;

            var errors = exception.Errors
                .GroupBy(x => x.PropertyName)
                .ToDictionary(
                    x => x.Key,
                    x => x
                        .Select(error => error.ErrorMessage)
                        .ToArray());

            await context.Response.WriteAsJsonAsync(new
            {
                status = 400,
                error = "Validation failed",
                errors
            });
        }

        private static async Task HandleUnexpectedException(
        HttpContext context)
        {
            context.Response.StatusCode =
                (int)HttpStatusCode.InternalServerError;

            await context.Response.WriteAsJsonAsync(new
            {
                status = 500,
                error = "An unexpected error occurred."
            });
        }

    }
}
