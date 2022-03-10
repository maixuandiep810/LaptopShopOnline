
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaptopShopOnline.Model.Entities
{

    [Table("UserGroup")]
    public class UserGroup
    {
        public UserGroup()
        {
            Users = new HashSet<User>();
            Credentials = new HashSet<Credential>();
        }

        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Id nhóm người dùng chỉ được chưa số và chữ.")]
        [StringLength(100)]
        [Required(ErrorMessage = "Bạn chưa nhập Id")]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Id")]
        public string Id { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Bạn chưa nhập Tên")]
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Tên")]
        public string Name { get; set; }


        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Credential> Credentials { get; set; }
    }
}
