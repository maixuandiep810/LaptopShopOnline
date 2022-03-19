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

        [Column(TypeName = "varchar(100)")]
        [StringLength(100)]
        [Display(Name = "Id")]
        [Required(ErrorMessage = "Bạn chưa nhập Id")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Tên")]
        [Column(TypeName = "nvarchar(100)")]
        [StringLength(100)]
        [Display(Name = "Tên")]
        public string Name { get; set; }

        public virtual ICollection<Credential> Credentials { get; set; }
    }
}
