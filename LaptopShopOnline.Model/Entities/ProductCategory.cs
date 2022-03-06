using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaptopShopOnline.Model.Entities
{


    [Table("ProductCategory")]
    public class ProductCategory : IAuditable
    {


        public ProductCategory()
        {
            Product = new HashSet<Product>();
        }


        public Guid Id { get; set; }


        [Required(ErrorMessage = "Bạn chưa nhập Tên")]
        [Column(TypeName = "nvarchar(100)")]
        [StringLength(100)]
        [Display(Name = "Tên")]
        public string Name { get; set; }

        public Guid? ParentId { get; set; }


        [Display(Name = "Thứ tự")]
        public int? DisplayOrder { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        [Display(Name = "Mô tả")]
        [StringLength(1000)]
        public string Descriptions { get; set; }


        [Display(Name = "Ngày tạo")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTimeOffset? CreatedOn { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [StringLength(100)]
        [Display(Name = "Người tạo")]
        public string CreatedBy { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày cập nhật")]
        public DateTimeOffset? ModifiedOn { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [StringLength(100)]
        [Display(Name = "Người cập nhật")]
        public string ModifiedBy { get; set; }


        [Display(Name = "Trạng thái Soft Delete")]
        public bool IsDeleted { get; set; }


        public virtual ICollection<Product> Product { get; set; }
    }
}