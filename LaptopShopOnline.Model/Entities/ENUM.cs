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
            BUYER_PENDING = 0,
            SHOP_PENDING = 1,
            SHOP_APPROVED = 2,
            SHOP_SHIPPING = 3,
            BUYER_PAID = 4,
            BUYER_CANCELLED = 5
        }

        public enum ShopStatus
        {
            PENDING = 0,
            APPROVED = 1,
            OPENING = 2,
            CLOSING = 3,
            BANNED = 4
        }

        public enum ProductStatus
        {
            PENDING = 0,
            APPROVED = 1,
            OPENING = 2,
            CLOSING = 3,
            BANNED = 4
        }

        public static IEnumerable<EnumOption> GetSelectList_OrderStatus()
        {
            var orderStatuses = Enum.GetValues(typeof(ENUM.OrderStatus))
                    .Cast<ENUM.OrderStatus>()
                    .ToList().Select(x => new EnumOption
                    {
                        Id = (int)x,
                        Name = x.ToString()
                    }
                    );
            return orderStatuses;
        }

        public static IEnumerable<EnumOption> GetSelectList_ProductStatus()
        {
            var productStatuses = Enum.GetValues(typeof(ENUM.ProductStatus))
                    .Cast<ENUM.ProductStatus>()
                    .ToList().Select(x => new EnumOption
                    {
                        Id = (int)x,
                        Name = x.ToString()
                    }
                    );
            return productStatuses;
        }

        public static IEnumerable<EnumOption> GetSelectList_ShopStatus()
        {
            var productStatuses = Enum.GetValues(typeof(ENUM.ShopStatus))
                    .Cast<ENUM.ShopStatus>()
                    .ToList().Select(x => new EnumOption
                    {
                        Id = (int)x,
                        Name = x.ToString()
                    }
                    );
            return productStatuses;
        }

        public class EnumOption
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

    }
}
