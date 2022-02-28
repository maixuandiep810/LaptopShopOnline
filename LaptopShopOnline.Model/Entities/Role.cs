using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaptopShopOnline.Model.Entities
{
    [Table("Role")]
    public partial class Role
    {
        public Role()
        {
            Credentials = new HashSet<Credential>();
        }

        [StringLength(50)]
        [Display(Name = "Id")]
        [Required(ErrorMessage = "Bạn chưa nhập Id")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập mô tả")]
        [StringLength(50)]
        [Display(Name = "Mô tả")]
        public string Name { get; set; }

        public virtual ICollection<Credential> Credentials { get; set; }
    }
}
