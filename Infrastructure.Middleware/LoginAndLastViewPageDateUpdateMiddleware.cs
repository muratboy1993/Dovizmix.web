using Infrastructure.ServiceManager.Abstract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace Infrastructure.Middleware
{
    public class LoginAndLastViewPageDateUpdateMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IUserManager _userManager;

        public LoginAndLastViewPageDateUpdateMiddleware(RequestDelegate next,IUserManager userManager)
        {
            _userManager = userManager;
            _next = next;
            
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                //todo: serkan burası düşünülecek sadece bu sayfada kullanıcı loign date update yapılıyor
                if (httpContext.User.Identity.IsAuthenticated&&!httpContext.Request.Path.Value.Contains("assets"))
                {
                    int userId = Convert.ToInt32(httpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId").Value);

                    //todo: Burada sayfa adına ulaşmak gerekiyor.
                    await _userManager.LoginAndLastPageDateUpdate(userId, httpContext.Request.Path);
                   
                }
                

            }
            catch (Exception ex)
            {
                
                //throw new Exception(ex.Message);
            }
            finally
            {
                await _next.Invoke(httpContext);
            }

          
        }
    }

    public static class LoginAndLastViewPageDateUpdateMiddlewareExtension
    {
        public static IApplicationBuilder LoginAndLastViewPageDateUpdateMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoginAndLastViewPageDateUpdateMiddleware>();
        }
    }
}
