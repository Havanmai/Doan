using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web; 
namespace Doan1.Areas.Admin.Data
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Moi nhap user")]
        public string Username { set; get; }

        [Required(ErrorMessage = "Moi nhap password")]
        public string Password { set; get; }
        public bool RememberMe { set; get; }

    }
}