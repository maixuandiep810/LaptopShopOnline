using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaptopShopOnline.Model.Entities
{


    [Table("NewsCategory")]
    public class NewsCategory : IAuditable
    {
        public NewsCategory()
        {
            News = new HashSet<News>();
        }

        public Guid Id { get; set; }

        [StringLength(256)]
        [DisplayName("Tên")]
        public string Name { get; set; }

        [DisplayName("Link liên kết")]
        [StringLength(256)]
        public string MetaTitle { get; set; }

        [DisplayName("Loại danh mục cha")]
        public int? ParentId { get; set; }

        [DisplayName("Thứ tự")]
        public int? DisplayOrder { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTimeOffset? CreatedOn { get; set; }

        [StringLength(256)]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTimeOffset? ModifiedOn { get; set; }

        [StringLength(256)]
        public string ModifiedBy { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<News> News { get; set; }
    }
}
