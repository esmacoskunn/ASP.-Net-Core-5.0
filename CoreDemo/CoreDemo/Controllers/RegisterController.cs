using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        [HttpGet]  //sayfa yüklenince çalışır.
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]  //sayfada buton tetiklenince.
        public IActionResult Index(Writer p)  //kaydetme işlemi writer sınıfına ait bir proplardan birine ait olucak.writein proplarını p ile çağırırsın.buraki paremetrenin amacı buranın writer sınınıfını kullanıcağını belirtir.writer sıınıfını ise p le kullanıcak.
        {
            WriterValidator wv = new WriterValidator();  //business katmanındaki validasyon şartlarını çağırıyor.
            ValidationResult results = wv.Validate(p); // ValidationResult paketin içinden gelen kod.Yani burada söylenmek istenen şey validasyon şartlarını kontrol eder...
            if (results.IsValid) //kontrol sonucunda eyer sonuçalr geçerli ise if in içindeki işlemleri yap.
            { 
                p.WriterStatus = true;
                p.WriterAbout = "Deneme test";
                wm.TAdd(p); //wm writeradd p den gelen değeri alır kendi içine.

                return RedirectToAction("Index", "Blog");

            }
            else  //bu şartlardan biri olmassa buraya düşer..
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }
           return View();




        }
    }
}
