
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

        [Column(TypeName = "varchar(100)")]
        [StringLength(100)]
        [Display(Name = "Id")]
        [Required(ErrorMessage = "Bạn chưa nhập Id")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Tên")]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Tên")]
        [StringLength(100)]
        public string Name { get; set; }


        public virtual ICollection<User> Users { get; set; }


        public virtual ICollection<Credential> Credentials { get; set; }
    }
}
