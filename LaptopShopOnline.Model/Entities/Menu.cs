using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaptopShopOnline.Model.Entities
{

    [Table("Menu")]
    public class Menu : IAuditable
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập tên menu")]
        [Column(TypeName = "nvarchar(100)")]
        [StringLength(100)]
        [Display(Name = "Tên")]
        public string MenuName { get; set; }

        [Display(Name = "Liên kết")]
        [Column(TypeName = "varchar(1000)")]
        [StringLength(1000)]
        [Required(ErrorMessage = "Bạn chưa nhập liên kết")]
        public string Link { get; set; }

        [Display(Name = "Thứ tự")]
        public int DisplayOrder { get; set; }

        [Display(Name = "Menu cha")]
        public int? ParentId { get; set; }

        [Display(Name = "Kiểu sang trang")]
        [Required(ErrorMessage = "Bạn chưa nhập kiểu sang trang")]
        [Column(TypeName = "varchar(100)")]
        [StringLength(100)] 
        public string Target { get; set; }

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
    }
}
