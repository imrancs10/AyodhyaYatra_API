using AyodhyaYatra.API.DTO.Response;
using AyodhyaYatra.API.Middleware;
using Microsoft.AspNetCore.Builder;
using System;

namespace AyodhyaYatra.API.Middleware
{

    public static class CustomExceptionHandler
    {
        private static ExceptionResponse? GetExceptionResponse(Exception exception)
        {
            return null;
        }

        public static void UseCustomExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
        }
    }
}