using CoreDemo.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class RegisterUserController : Controller
    {
        private readonly UserManager<AppUser> _userManager; // burada AppUser UserManagera ait bütün özellikleri aldı.
        //UserManager sınıfı “AppUser” modeli üzerinden tüm kullanıcı yönetimi sağlayacaktır.
       //private _userManager yorumlama tanımlandığı sınıfın içinde erişilebilir ve sadece değiştirilebilir olduğunu belirtir. 
       //readonly ifadesi ise _userManager sadece başlatıldığı yerde değer atanabilir ve daha sonra değiştirilemez olduğunu ifade eder.başka katmana çıkmak istemessen reodonly kullanırsın.
       // UserManager userın bi üstü gibi düşün appuser de yazan colonları silme güncelleme şifre doğrulaması gibi özelliklr sunar.usere ait özellikleri barındırır.
        public RegisterUserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        
        [HttpPost]
        public async Task<IActionResult> Index(UserSingUpViewModel p)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser() 
                {
                    Email = p.Mail,
                    UserName = p.UserName,
                    NameSurname = p.NameSurname
                };
                var result = await _userManager.CreateAsync(user, p.Password);  
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(p);
        }
    }
}
