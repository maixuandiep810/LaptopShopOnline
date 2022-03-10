using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LaptopShopOnline.Model.Entities
{

    [Table("Product")]
    public class Product : IAuditable
    {


        public Guid Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [StringLength(100)]
        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Bạn chưa nhập tên sản phẩm")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(100)")]
        [StringLength(100)]
        [Display(Name = "Mã lưu kho")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập mã cửa hàng")]
        [Display(Name = "Mã Shop")]
        public Guid ShopId { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        [Display(Name = "Mô tả")]
        [StringLength(1000)]
        public string Description { get; set; }

        [Display(Name = "Ảnh")]
        [Column(TypeName = "varchar(1000)")]
        [StringLength(1000)]
        public string UrlImage { get; set; }

        [Display(Name = "Ảnh Sub 1")]
        [Column(TypeName = "varchar(1000)")]
        [StringLength(1000)]
        public string Sub1UrlImage { get; set; }

        [Display(Name = "Ảnh Sub 2")]
        [Column(TypeName = "varchar(1000)")]
        [StringLength(1000)]
        public string Sub2UrlImage { get; set; }

        [Display(Name = "Giá")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        [Required(ErrorMessage = "Bạn chưa nhập giá")]
        public decimal Price { get; set; }

        [Display(Name = "Giá khuyến mãi")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal? PromotionPrice { get; set; }

        [Display(Name = "Số lượng")]
        public int? Quantity { get; set; }

        [Display(Name = "Danh mục sản phẩm")]
        [Required(ErrorMessage = "Bạn chưa nhập danh mục sản phẩm")]
        public Guid ProductCategoryId { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Thông tin chi tiết")]
        public string Detail { get; set; }

        [Display(Name = "Sản phẩm Hot")]
        public bool? IsTopHot { get; set; }

        [Display(Name = "Sản phẩm binh thường mức 1")]
        public bool? IsNormalProduct1 { get; set; }

        [Display(Name = "Sản phẩm bình thường mức 2")]
        public bool? IsNormalProduct2 { get; set; }

        [Display(Name = "Sản phẩm mới")]
        public bool? IsNewProduct { get; set; }

        [Display(Name = "Số lượng đã bán")]
        public int? QuantityOfSoldProduct { get; set; }

        [Display(Name = "Lượt xem")]
        public int? ViewCount { get; set; }

        [Display(Name = "Trạng thái cửa hàng")]
        public int ProductStatus { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày tạo")]
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

        public IFormFile Image { get; set; }
        public IFormFile Sub1Image { get; set; }
        public IFormFile Sub2Image { get; set; }


        public virtual ProductCategory ProductCategory { get; set; }

        public virtual Shop Shop { get; set; }

    }
}
