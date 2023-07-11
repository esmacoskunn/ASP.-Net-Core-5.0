
using ClosedXML.Excel;
using CoreDemo.Areas.Admin.Models;
using DataAccsessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult ExportStaticExelBlogList()
        {
          

            using (var workbook = new XLWorkbook()) //çalışma kitabını tanımladım. new XLWorkbook())  buradaki herşey sola atandı.
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi"); //çalışma kitabı + çalışma sayfası + ekle içine Blog Listesini.workbook.Worksheets.Add("Blog Listesi"); buradaki her şey sola atandı.
                worksheet.Cell(1, 1).Value = "Blog ID"; //oluşan çlışma kitabı ve çalışma sayfasının 1.satırı ve 1. sütünuna şunları ata Blog ID.Value metot olmadığından eşittir ile atama işlemini yaparız.
                worksheet.Cell(1, 2).Value = "Blog Adı"; //1.satırın 2. sütününn adı.

                int BlogRowCount = 2; //herhangi değişken tanımladım...
                foreach (var item in GetBlogList()) //kendimce metot tanımladım. madem metot tanımlıyorsun bir yerde bunu kullanmış olmam gerekiyordu.norelde orada foreachın ismi olurdu ama ben orada metot olarak tanımladım.
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;  //2 satırın 1 sütünunun değeri 
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName; //2.satırda 2. sütunun değeri
                    BlogRowCount++; //satırlar herseferinde 1 er 1 er artar şağıya doğru kayar.
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream); //workbook değerini kaydet ama streamdan gelen değeri kaydet.
                    var content = stream.ToArray();
                    return File(content, "application / vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }
            }
          
        }

        public List<BlogModel> GetBlogList()  
        {
            List<BlogModel> bm = new List<BlogModel> 
            {
                new BlogModel{ID=1,BlogName="C# Programlaya hoş geldiniz."},
                new BlogModel{ID=2,BlogName="Tesla firmasınnı araçları."},
                new BlogModel{ID=3,BlogName="2023 olimpiyatları."}
            };
            return bm; 
        }

       
        public IActionResult BlogListExel() 
        {
            return View();
        }

        

        public IActionResult ExportDymanicExelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;
                foreach (var item in BlogTitleList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application / vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }
            }
        }

        public List<BlogModel2> BlogTitleList()  
        {
            List<BlogModel2> bm = new List<BlogModel2>();  
            using (var c = new Context()) 
            {
                bm = c.Blogs.Select(x => new BlogModel2
                {
                    ID=x.BlogID,
                    BlogName=x.BlogTitle

                }).ToList();  
            }
            return bm;
        }

        public IActionResult BlogTitleListExel()
        {
            return View();
        }



        
    }
}
