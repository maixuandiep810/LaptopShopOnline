using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaptopShopOnline.Model.Entities
{

    [Table("Credential")]
    [Serializable]
    public class Credential
    {
        [Required(ErrorMessage = "Bạn chưa nhập mã nhóm người dùng")]
        [Column(TypeName = "varchar(100)")]
        [StringLength(100)]
        [Display(Name = "Nhóm người dùng")]
        public string UserGroupId { get; set; }


        [Required(ErrorMessage = "Bạn chưa nhập mã quyền")]
        [Column(TypeName = "varchar(100)")]
        [StringLength(100)]
        [Display(Name = "Quyền")]
        public string RoleId { get; set; }


        public virtual Role Role { get; set; }
        public virtual UserGroup UserGroup { get; set; }

    }
}
