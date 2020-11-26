using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCookieWeb
{
    public class CookieMiddleware
    {
        private readonly RequestDelegate _next;
        public CookieMiddleware(RequestDelegate next)
        {
            this._next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Cookies.ContainsKey("name"))
            {
                string name = context.Request.Cookies["name"];
                await context.Response.WriteAsync($"Hello {name}!");
            }
            else
            {
                context.Response.Cookies.Append("name", "Vova");
                await context.Response.WriteAsync("Hello Cookies World!");
            }
        }
    }
}
