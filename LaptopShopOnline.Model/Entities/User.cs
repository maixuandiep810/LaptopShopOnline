using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaptopShopOnline.Model.Entities
{
    [Table("User")]
    public class User : IAuditable
    {
        public Guid Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Nhóm người dùng")]
        public string UserGroupId { get; set; }

        [StringLength(100)]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Tên người dùng chỉ được chưa số và chữ.")]
        [Required(ErrorMessage = "Bạn chưa nhập tên tài khoản")]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Tên đăng nhập")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu")]
        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [StringLength(50)]
        [Compare("Password", ErrorMessage = "Mật khẩu không khớp")]
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Xác nhận mật khẩu")]
        public string ConfirmPassword { get; set; }

        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Họ lót")]
        public string FirstName { get; set; }

        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Tên")]
        public string LastName { get; set; }

        [NotMapped]
        [Display(Name = "Họ và tên")]
        public string FullName => FirstName + ' ' + LastName;

        [StringLength(100)]
        [Required(ErrorMessage = "Bạn chưa nhập email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Định dạng email không đúng.")]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Mã đặt lại mật khẩu")]
        public string ResetPasswordCode { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

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
        [Display(Name = "Người cập nhật")]
        public string ModifiedBy { get; set; }

        [Display(Name = "Trạng thái Soft Delete")]
        public bool IsDeleted { get; set; }

        public virtual UserGroup UserGroup { get; set; }

        public virtual Shop Shop { get; set; }

    }
}
