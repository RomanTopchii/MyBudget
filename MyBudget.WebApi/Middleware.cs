using System.Net.Mime;
using FluentValidation;

namespace MyBudget.WebApi;

public class Middleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (ValidationException ex)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = MediaTypeNames.Text.Plain;
            var errorMessage = string.Join(";\n", ex.Errors.Select(e => e.ErrorMessage));
            await context.Response.WriteAsync(errorMessage);
            throw;
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = MediaTypeNames.Text.Plain;
            await context.Response.WriteAsync(ex.Message);
            throw;
        }
    }
}
