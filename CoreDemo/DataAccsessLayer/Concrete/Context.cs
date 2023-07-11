using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser,AppRole,int> //IdentityDbContext diyerek içindeki hazır tabloları sql yansıt diyoruz.hazır tablonunn içinde kolanları  bile var. bunlarda değişiklik yapabiliriz.nasılmı???? entitiylayer katmanına paket yükleriz. key paremetresinni türünü istiyor.2 tane yazarsan keyin türünüde ister.
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=CoreBlogDb;integrated security=true;"); //CoreBlogDb sqlde database adı.
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message2>()   //messege2 sınıfının içinde writer sınıfı var.Message2 sınıfını burada tanımladım.
                .HasOne(x => x.SenderUser)      //messege2 sınıfındaki  SenderUser ....
                .WithMany(y => y.WriterSender)  // writer sınıfındaki  WriterSender  eşitlenir...
                .HasForeignKey(z => z.SenderID)
                .OnDelete(DeleteBehavior.ClientSetNull);


            modelBuilder.Entity<Message2>() 
              .HasOne(x => x.ReceiverUser)    
              .WithMany(y => y.WriterReceiver) 
              .HasForeignKey(z => z.ReceiverID)
              .OnDelete(DeleteBehavior.ClientSetNull);

            base.OnModelCreating(modelBuilder);


        }


        public DbSet<About> Abouts { get; set; } 
        public DbSet<Blog> Blogs { get; set; }  
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<BlogRayting> BlogRaytings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Message2> Message2s { get; set; }
        public DbSet<Admin> Admins { get; set; }






    }
}
