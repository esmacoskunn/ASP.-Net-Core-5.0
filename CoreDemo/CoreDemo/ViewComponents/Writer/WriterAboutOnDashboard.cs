using BusinessLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Writer
{

    public class WriterAboutOnDashboard : ViewComponent
    {
        WriterManager writermanager = new WriterManager(new EfWriterRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            {
                var username = User.Identity.Name; 
                ViewBag.veri = username;
                var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
                var writerıd = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
                var values = writermanager.GetWriterById(writerıd); //login işlemi yaparkenki kayıtlar oraya yazılacak ama benimki login çalışmyor.
                return View(values);

            }


        }
    }
}