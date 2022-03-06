using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace LaptopShopOnline.Model.Entities
{
    [Table("Order")]
    public partial class Order : IAuditable
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public Guid Id { get; set; }

        [Display(Name = "Mã tài khoản người dùng")]
        public Guid BuyerId { get; set; }

        [Display(Name = "Mã cửa hàng")]
        public Guid ShopId { get; set; }


        [Required]
        [Column(TypeName = "nvarchar(100)")]
        [StringLength(100)]
        [Display(Name = "Tên người nhận")]
        public string ShipName { get; set; }

        [Display(Name = "Số điện thoại người nhận")]
        [Required]
        [Column(TypeName = "varchar(20)")]
        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]
        public string ShipPhone { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required]
        [Column(TypeName = "nvarchar(1000)")]
        [StringLength(1000)]
        public string ShipAddress { get; set; }

        [Display(Name = "Email")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
        ErrorMessage = "Không đúng định dạng email")]
        [Required]
        [StringLength(256)]
        public string ShipEmail { get; set; }

        [Display(Name = "Thành tiền")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal? Total => OrderDetails.Select(x => x.Total).Sum();

        [Display(Name = "Trạng thái đơn hàng")]
        public int OrderStatus { get; set; }

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

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual User User { get; set; }
        public virtual Shop Shop { get; set; }
    }
}
