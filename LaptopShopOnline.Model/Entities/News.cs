using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaptopShopOnline.Model.Entities
{

    [Table("News")]
    public class News : IAuditable
    {
        public Guid Id { get; set; }

        [StringLength(256)]
        [Required(ErrorMessage = "Bạn chưa nhập Tên")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        [StringLength(1000)]
        [DisplayName("Tóm tắt")]
        public string Summary { get; set; }

        [Column(TypeName = "nvarchar(2000)")]
        [StringLength(2000)]
        [DisplayName("Nội dung")]
        public string Content { get; set; }

        [Display(Name = "Ảnh")]
        [Column(TypeName = "varchar(1000)")]
        [StringLength(1000)]
        public string UrlImage { get; set; }

        public Guid NewsCategoryId { get; set; }

        public bool  IsTopHot { get; set; }

        public int? ViewCount { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày tạo")]
        public DateTimeOffset? CreatedOn { get; set; }

        [Column(TypeName = "varchar(100)")]
        [StringLength(100)]
        [Display(Name = "Người tạo")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày cập nhật")]
        public DateTimeOffset? ModifiedOn { get; set; }

        [Column(TypeName = "varchar(100)")]
        [StringLength(100)]
        [Display(Name = "Người cập nhật")]
        public string ModifiedBy { get; set; }

        [Display(Name = "Trạng thái Soft Delete")]
        public bool IsDeleted { get; set; }

        public virtual NewsCategory NewsCategory { get; set; }
    }
}
