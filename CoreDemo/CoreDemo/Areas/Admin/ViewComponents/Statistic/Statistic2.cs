using DataAccsessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2 : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke() //ilk 4 olan için yapıldı. 
        {
            //ViewBag.v1 = bm.GetList().Count();
            ViewBag.v1 = c.Blogs.OrderByDescending(x => x.BlogID).Select(x => x.BlogID).Take(1).FirstOrDefault();

            ViewBag.v3 = c.Comments.Count();
            return View();
        }

        //sqlde ki blogs tablosundaki BlogID yi büyükten küçüğe sırala. BlogID yi seç (tabi bu büyükten küçüğe sıralanmış öncesinde tanıttım çümkü) 1 tane değer AL ,  ilk değeri al . 
    }
    //SELECT DEĞERİ TUTAR. ALIR 
}
