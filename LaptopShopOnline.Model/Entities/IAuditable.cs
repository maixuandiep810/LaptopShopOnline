using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopShopOnline.Model.Entities
{
    public interface IAuditable
    {
        public DateTimeOffset? CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTimeOffset? ModifiedOn { get; set; }

        public string ModifiedBy { get; set; }

        public bool IsDeleted { get; set; }

        //public void InsertAuditFields(string createdBy) {
        //    IsDeleted = false;            
        //    CreatedOn = DateTime.Now;
        //    CreatedBy = createdBy;
        //}

        //public void UpdateAuditFields(string modifiedBy)
        //{
        //    ModifiedOn = DateTime.Now;
        //    ModifiedBy = modifiedBy;
        //}
    }

    public class AuditTable
    {
        public static void InsertAuditFields(IAuditable item, string createdBy)
        {
            item.IsDeleted = false;
            item.CreatedOn = DateTime.Now;
            item.CreatedBy = createdBy;
        }
        public static void UpdateAuditFields(IAuditable item, string modifiedBy)
        {
            item.ModifiedOn = DateTime.Now;
            item.ModifiedBy = modifiedBy;
        }
    }
}
