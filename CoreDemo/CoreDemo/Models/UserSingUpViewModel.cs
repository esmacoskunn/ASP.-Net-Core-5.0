using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Models
{
    public class UserSingUpViewModel
    {
        [Display(Name ="Ad Soyad")] 
        [Required(ErrorMessage = "Lütfen Ad Soyad Giriniz")]
        public string NameSurname { get; set; }


        [Display(Name = "Şİfre ")]
        [Required(ErrorMessage = "Lütfen Şifre  Giriniz")] 
        public string Password { get; set; }


        [Display(Name = "Şifre Tekrar")]
        [Compare("Password",ErrorMessage ="Şifreler Uyuşmuyor!")]  
        public string confirmPassword { get; set; }


        [Display(Name = "Mail Adresi ")]
        [Required(ErrorMessage = "Lütfen Mail Giriniz")]
        public string Mail { get; set; }


        [Display(Name = "KUllanıcı Adı")]
        [Required(ErrorMessage = "Lütfen KUllancı Adını Giriniz")]
        public string UserName { get; set; }

    }
}
