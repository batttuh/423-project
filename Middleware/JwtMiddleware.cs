using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace YourNamespace.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public JwtMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token != null)
            {
                AttachUserToContext(context, token);
            }

            await _next(context);
        }

        private void AttachUserToContext(HttpContext context, string token)
        {
            try
            {
                  string authorizationHeader = context.Request.Headers["Authorization"];
                    string email = null;
                    // Check if the header is present and starts with "Bearer "
                    if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                    {
                        // Extract the token without the "Bearer " prefix
                         token = authorizationHeader.Substring(7);

                        // Decode the token
                        var tokenHandler = new JwtSecurityTokenHandler();
                        var jwtToken = tokenHandler.ReadJwtToken(token);

                        // Extract the email claim from the token
                        email = jwtToken.Claims.FirstOrDefault(c =>  c.Type == "email")?.Value;
                        // Use the email as needed
                        if(email==null){
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;

                        }else{
                            context.Items["email"] = email;
                        }
                    }
            }
            catch
            {
                // Handle any token validation errors
                // You can customize the error handling as per your requirements
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            }
        }
    }

    public static class JwtMiddlewareExtensions
    {
        public static IApplicationBuilder UseJwtMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<JwtMiddleware>();
            return app;
        }
    }
}
