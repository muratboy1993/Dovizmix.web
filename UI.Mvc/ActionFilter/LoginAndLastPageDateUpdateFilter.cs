using Infrastructure.ServiceManager.Abstract;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Mvc.ActionFilter
{
    public class LoginAndLastPageDateUpdateFilter : IActionFilter
    {
        private readonly IUserManager _userManager;
        

        public LoginAndLastPageDateUpdateFilter(IUserManager userManager)
        {
            _userManager = userManager;
        
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var route = context.RouteData.Values["action"];
                _userManager.LoginAndLastPageDateUpdate(Convert.ToInt32(context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId").Value), route.ToString());

            }
           
           
        }
    }
}
