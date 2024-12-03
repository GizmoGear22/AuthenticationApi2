using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace AuthenticationLayer
{
    public class ApiAuthMiddleware
    {
        public readonly RequestDelegate _next;
        private readonly IConfiguration _config;
        private const string apiHeaderKey = "X-Api-Key";

        public ApiAuthMiddleware(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            _config = config;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            var apiKey = _config.GetValue<string>("ApiKey");
            if (!context.Request.Headers.TryGetValue(apiHeaderKey, out var value))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Input Api Key");
                return;
            }
            if (!apiKey.Equals(value))
            {
                context.Response.StatusCode = 402;
                await context.Response.WriteAsync("Wrong Api Key");
                return;
            }

            await _next(context);
        }
            
    }
}
