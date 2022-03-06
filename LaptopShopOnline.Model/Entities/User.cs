using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaptopShopOnline.Model.Entities
{
    [Table("User")]
    public class User : IAuditable
    {
        public Guid Id { get; set; }

        [StringLength(100)]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Nhóm người dùng")]
        public string UserGroupId { get; set; }

        //[RegularExpression("[^A-Za-z0-9]+", ErrorMessage = "Tên người dùng chỉ được chưa số và chữ.")]
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Bạn chưa nhập tên tài khoản")]
        [StringLength(100)]
        public string UserName { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu")]
        [Column(TypeName = "varchar(50)")]
        [StringLength(50)]
        public string Password { get; set; }

        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage = "Mật khẩu không khớp")]
        [NotMapped]
        [Column(TypeName = "varchar(50)")]
        [StringLength(50)]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Họ lót")]
        [Column(TypeName = "nvarchar(100)")]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Display(Name = "Tên")]
        [Column(TypeName = "nvarchar(100)")]
        [StringLength(100)]
        public string LastName { get; set; }

        [NotMapped]
        [Display(Name = "Họ và tên")]
        public string FullName => FirstName + ' ' + LastName;

        [Required(ErrorMessage = "Bạn chưa nhập email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Định dạng email không đúng.")]
        [Display(Name = "Email")]
        [Column(TypeName = "varchar(100)")]
        [StringLength(100)]
        public string Email { get; set; }

        [Display(Name = "Mã đặt lại mật khẩu")]
        [Column(TypeName = "varchar(100)")]
        [StringLength(100)]
        public string ResetPasswordCode { get; set; }

        [Display(Name = "Địa chỉ")]
        [Column(TypeName = "nvarchar(1000)")]
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
        [StringLength(100)]
        [Display(Name = "Người cập nhật")]
        public string ModifiedBy { get; set; }

        [Display(Name = "Trạng thái Soft Delete")]
        public bool IsDeleted { get; set; }

        public virtual UserGroup UserGroup { get; set; }

        public virtual Shop Shop { get; set; }

    }
}
