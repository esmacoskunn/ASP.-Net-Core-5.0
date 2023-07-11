using DataAccsessLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>();
            services.AddIdentity<EntityLayer.Concrete.AppUser, EntityLayer.Concrete.AppRole>(x=>
            {
                x.Password.RequireUppercase = false;
                x.Password.RequireNonAlphanumeric = false;

            })
                .AddEntityFrameworkStores<Context>();

            services.AddControllersWithViews();

            ////services.AddSession();


            //services.AddMvc(config =>    //Bu yazılan sayesinde artık proje  seviyesinde şifreli içine giremiyorum.her hangi bir yere kayıt olucan ondan sonra sisteme girebilirsin...
            //{
            //    var policy = new AuthorizationPolicyBuilder()
            //              .RequireAuthenticatedUser()
            //              .Build();
            //    config.Filters.Add(new AuthorizeFilter(policy));
            //});


            //services.AddMvc();  //yeni eklendi


            //services.AddAuthentication(
            //    CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie(x =>
            //    {
            //        x.LoginPath = "/Login/Index";  //nereye basarsan bas login sayfası önüne çıkıyor bunun sayesinde.
            //    }
            //    );

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            // app.UseStatusCodePages();  //hata kodu verir..404 kodunu verir.ama gerek yok...ben bir sayfaya gitmeini istiyorum.
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}");  // hata sayfasına yönlendirir...
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            /*   app.UseAuthentication(); *///yeni ekledii. Bunun amacı loginde kayıt yapınca sisteme otontike oluyor.diğer yerlere erişim açılır.
                                            //app.UseSession();







            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => 
            {

                endpoints.MapControllerRoute(  
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                 );


                endpoints.MapControllerRoute(  
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            });





        }
    }
}
