using BusinessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Comment
{
    public class CommentListByBlog:ViewComponent  //buraya blogreadall dan geldik...
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());
        public IViewComponentResult Invoke(int id)  //peki bu dışarıdan ıd nasıl alıcak???????????
        {
            var values = cm.GetList(id); //bir yerde paremetre varsa viewinden değer gelicek buraya demek.. viewinde id olarak 2 verirsen buraya id ye2 gelir ona göre şartlar...
            return View(values);
        }

    }
}

