using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaptopShopOnline.Model.Entities
{

    [Table("Feedback")]
    public class Feedback : IAuditable
    {
        public Guid Id { get; set; }

        [StringLength(256)]
        [Required(ErrorMessage = "Bạn chưa nhập Họ và tên")]
        [Display(Name = "Họ và tên")]
        public string Name { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
         ErrorMessage = "Định dạng số Điện thoại không Đúng")]
        [Display(Name = "Số Điện thoại")]
        [StringLength(50)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập email")]
        [Display(Name = "Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Định dạng email không đúng.")]
        [StringLength(256)]
        public string Email { get; set; }

        [Display(Name = "Địa chỉ")]
        [StringLength(256)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập nội dung")]
        [Display(Name = "Nội dung")]
        public string Content { get; set; }

        [Display(Name = "Phản hồi")]
        public string Reply { get; set; }

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
