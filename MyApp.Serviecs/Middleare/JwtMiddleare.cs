using Microsoft.AspNetCore.Http;
using MyApp.Serviecs.Interfaces;

namespace MyApp.Serviecs.Middleare
{
    public class JwtMiddleare
    {
        private RequestDelegate _next;
        public JwtMiddleare(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, IUserService userService, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = jwtUtils.ValidateJwtToken(token);
            if (userId != null)
            {
                context.Items["User"] = userService.GetById(userId.Value);
            }
            await _next(context);
        }
    }
}
