using CookiesAuth.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CookiesAuth.Extensions;
using CookiesAuth.Models.ViewModels;

namespace CookiesAuth.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                HandleExceptionAsync(context, ex);
            }
        }

        private static void HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected

            //if (ex is MyNotFoundException) code = HttpStatusCode.NotFound;
            //else if (ex is MyUnauthorizedException) code = HttpStatusCode.Unauthorized;
            //else if (ex is MyException) code = HttpStatusCode.BadRequest;

            var error = new ErrorViewModel()
            {
                StatusCode = (int)code,
                Message = ex.Message,
                Exception = ex.GetType().Name
            };

            context.Session.Set<ErrorViewModel>("CurrentError", error);

            context.Response.Redirect("/Home/Error");
        }
    }
}
