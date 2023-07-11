using DataAccsessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4 : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Admins.Where(x => x.AdminID == 1).Select(y => y.Name).FirstOrDefault();
            ViewBag.v2 = c.Admins.Where(x => x.AdminID == 1).Select(y => y.ImageURL).FirstOrDefault();
            ViewBag.v2 = c.Admins.Where(x => x.AdminID == 1).Select(y => y.ShortDescription).FirstOrDefault();

            return View();
        }
    }
    // sqldeki admins tablosundaki AdminID 1 olanı bul . sonra seç buradan Name yi ve bulduğun bu ilk değeri getir.
}



//SOR BUNU aDMİNıd ZATEN PİRİMARY KEY ZTEN FİRSORDEFAULTLA NEDEN TEKRAR İLK DEĞERİ GETİR DİYORUZ.