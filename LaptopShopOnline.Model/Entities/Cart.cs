using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaptopShopOnline.Model.Entities
{
    [Table("Cart")]
    public class Cart
    {
        public Cart()
        {
        }

        public Guid Id { get; set; }

        [Display(Name = "Mã tài khoản người dùng")]
        public Guid BuyerId { get; set; }

        [Display(Name = "Mã sản phẩm")]
        public Guid ProductId { get; set; }

        [Display(Name = "Số lượng")]
        public int Quantity { get; set; } = 0;


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

        public virtual Product Product { get; set; }

        public virtual User Buyer { get; set; }
    }
}
