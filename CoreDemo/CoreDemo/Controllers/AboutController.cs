﻿using BusinessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EfAboutRepository());
        public IActionResult Index()
        {
            var values = abm.GetList();
            return View(values);
        }


        public PartialViewResult SocialMediaAbout()
        {
    
            return PartialView(); 
        }

        int[] number1 = new int[] { 1, 2, 3, 4, 5 };
       



    }
}
