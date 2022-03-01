using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopShopOnline.Model.Entities
{
    public class ENUM
    {
        public enum OrderStatus
        {
            PENDING = 0,
            APPROVED = 1,
            SHIPPING = 2,
            SHIPPED = 3,
            PAID = 4
        }
    }
}
