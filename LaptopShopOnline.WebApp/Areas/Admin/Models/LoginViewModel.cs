using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopShopOnline.WebApp.Areas.Admin.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Bạn chưa nhập User Name")]
        [Display(Name = "Tên đăng nhập")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Password")]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Bạn chưa chọn Nhóm người dùng")]
        [Display(Name = "UserGroup")]
        public string UserGroupId { get; set; }



        public bool RememberMe { get; set; }
    }
}
