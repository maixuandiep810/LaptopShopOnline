using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LaptopShopOnline.Model.Entities
{

    [Table("Shop")]
    public class Shop : IAuditable
    {

        public Shop()
        {
            Products = new HashSet<Product>();
        }


        public Guid Id { get; set; }

        [StringLength(256)]
        [Display(Name = "Tên shop")]
        [Required(ErrorMessage = "Bạn chưa nhập tên Shop")]
        public string Name { get; set; }

        [Display(Name = "Người bán")]
        public Guid? SellerId { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]

        [Display(Name = "Ngày tạo")]
        public DateTimeOffset? CreatedOn { get; set; }

        [StringLength(256)]
        [Display(Name = "Người tạo")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày cập nhật")]
        public DateTimeOffset? ModifiedOn { get; set; }

        [StringLength(256)]
        [Display(Name = "Người cập nhật")]
        public string ModifiedBy { get; set; }

        [Display(Name = "Trạng thái Soft Delete")]
        public bool IsDeleted { get; set; }



        public virtual ICollection<Product> Products { get; set; }

        public virtual User Seller { get; set; }
    }
}
