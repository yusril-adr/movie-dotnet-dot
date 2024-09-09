using dot_dotnet_test_api.Helpers;
using dot_dotnet_test_api.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NuGet.Protocol;
using System;
using System.Threading.Tasks;

namespace dot_dotnet_test_api.Middlewares
{
    public class ErrorHandlingMiddleware : IMiddleware
    {

        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogInformation(ex.Message);
                var unAuthorizedresponse = new Response<object>(
                    data: null,
                    errors: ex.Message.Split(";"),
                    message: "Unauthorized"
                );

                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsJsonAsync(
                    unAuthorizedresponse
                );
            }
            catch (Exception error)
            {
                _logger.LogInformation(error.ToString());
                var response = new Response<object>(
                    errors: [error.Message],
                    message: "Internal Server Error"
                );

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
