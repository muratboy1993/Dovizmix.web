using Infrastructure.ServiceManager.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Mvc.Models
{
    [ViewComponent(Name = "DropdownUserMenu")]
    public class DropdownUserMenu : ViewComponent
    {
        private readonly IUserManager _userManager;
        public DropdownUserMenu(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.AvatarPath = _userManager.GetAvatar(Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId").Value));
            ViewBag.NameSurname = _userManager.GetNameAndSurname(Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId").Value));
            ViewBag.Email = _userManager.GetEmail(Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId").Value));
            return View();
        }
    }
}
