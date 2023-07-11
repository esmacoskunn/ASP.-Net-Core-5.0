using BusinessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult PartialAddCommend()  
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult PartialAddCommend(Comment p) 
        {
           
            p.CommentStatus = true;
            p.BlogID = 2;
            cm.CommentAdd(p);

            return PartialView();
        }
        public PartialViewResult CommendListByBlog(int id) 
        {
            var values = cm.GetList(id);
            return PartialView();
        }


    }
}
