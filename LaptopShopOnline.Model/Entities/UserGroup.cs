
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



        [StringLength(50)]
        [Display(Name = "Id")]
        public string Id { get; set; }


        [Display(Name = "Tên")]
        [StringLength(256)]
        public string Name { get; set; }


        public virtual ICollection<User> Users { get; set; }


        public virtual ICollection<Credential> Credentials { get; set; }
    }
}
