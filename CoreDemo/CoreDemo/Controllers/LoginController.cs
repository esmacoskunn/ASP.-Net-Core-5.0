using CoreDemo.Models;
using DataAccsessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
   
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>  Index(UserSingInViewModel p)
        {

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.UserName, p.passoword, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return RedirectToAction("Index", "Dashboard");
                }
            }
            return View();
        }


        //[HttpPost]

        //public async Task<IActionResult> Index(Writer p)  //dışarıdan writer sınıfına ait paremetreler gelicek demek burası...
        //{
        //    Context c = new Context();
        //    var datavalue = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
        //    //sqldeki writermail colonu ile view tarafındaki inputtaki writermail yazılan değerin yerine yazılacak değer eşitlenir.
        //    // FirstOrDefault tek değer tek colon la çalışır. 
        //    // hangi mailin değerini girersen sadece artık o clonla işlem yapar....


        //    if (datavalue != null)  // detavalue boş değil ise içine girer.
        //    {
        //        var claims = new List<Claim>  //talep oluşturdum talebim liste şeklinde oluyor.
        //        {
        //            new Claim(ClaimTypes.Name,p.WriterMail) //yeni bir talep oluştur,bu talep 2 paremetreli çalışıyor
        //        };
        //        var useridentity = new ClaimsIdentity(claims, "a");
        //        ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
        //        await HttpContext.SignInAsync(principal);
        //        return RedirectToAction("Index", "Dashboard");  //login işleminde giriş yaptığmda buraya kayıt olan kişinin bilgileri gitsin buraya peki nasıl olucak......
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}
    }


    //FirstOrDefault metodu koleksiyonda, tek değer getirmek için kullanılır. Eğer bir veri yok ise de default olarak bir değer döner.
}
