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
        [Column(Order = 0)]
        [StringLength(50)]
        [Display(Name = "Nhóm")]
        public string UserGroupId { get; set; }


        [Column(Order = 1)]
        [StringLength(50)]
        [Display(Name = "Quyền")]
        public string RoleId { get; set; }


        public virtual Role Role { get; set; }
        public virtual UserGroup UserGroup { get; set; }

    }
}
