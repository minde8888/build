﻿using System.Net;
using build.Api.Middleware;

namespace build.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            int statusCode;
            string message;
            switch (exception)
            {
                //case UserExistException _:
                //    statusCode = (int)HttpStatusCode.NotFound;
                //    message = exception.Message;
                //    break;
                default:
                    statusCode = (int)HttpStatusCode.InternalServerError;
                    message = "Internal server error occurred. " + exception;
                    break;
            }

            var error = new ApiExceptionResponse
            {
                Reason = statusCode.ToString(),
                Message = message
            };
            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(error));
        }
    }
}
