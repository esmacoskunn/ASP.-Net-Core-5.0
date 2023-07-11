using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Models
{
    public class UserSingInViewModel
    {
        [Required(ErrorMessage = "Lütfen KUllancı Adını Giriniz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen şifre Adını Giriniz")]
        public string passoword { get; set; }
    }
}
