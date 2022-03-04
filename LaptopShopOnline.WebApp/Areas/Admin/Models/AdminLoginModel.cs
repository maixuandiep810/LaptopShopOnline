using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopShopOnline.WebApp.Areas.Admin.Models
{
    public class AdminLoginModel
    {
        [Required(ErrorMessage = "Bạn chưa nhập User Name")]
        [Display(Name = "Tên đăng nhập")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Password")]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Bạn chưa chọn Nhóm người dùng")]
        [Display(Name = "Nhóm người dùng")]
        public string UserGroupIdPrefix { get; set; }



        public bool RememberMe { get; set; }
    }
}
