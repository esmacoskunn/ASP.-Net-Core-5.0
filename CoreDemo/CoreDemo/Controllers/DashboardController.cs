using BusinessLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{



    //[Authorize]
    public class DashboardController : Controller
    {
        BlogManager cm = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            Context c = new Context();
            var username = User.Identity.Name;
             var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerid = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();

            ViewBag.v1 = c.Blogs.Count().ToString();
            ViewBag.v2 = c.Blogs.Where(x => x.WriterID ==writerid).Count();
            ViewBag.v3 = c.Categorys.Count();
            return View();

        }
    }
}
