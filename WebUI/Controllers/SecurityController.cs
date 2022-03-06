using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class SecurityController : Controller
    {
        private IAdminService _adminService;
        public SecurityController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Admin admin)
        {
            if (!ModelState.IsValid)
            {
                //Model doğrulama yapılmadıysa.
                return View();
            }
            
            var result = _adminService.Login(admin);
            if (result.Success)
            {
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, result.Data.id.ToString()));
                claims.Add(new Claim(ClaimTypes.UserData, result.Data.kullanici_kodu));

                var useridentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);

                HttpContext.SignInAsync(principal);

                return Redirect("/Home/PersonelListesi");
            }
                

            ViewBag.mesaj = result.Message;
            return View();
        }
    }
}
