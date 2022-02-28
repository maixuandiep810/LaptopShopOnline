using LaptopShopOnline.Common;
using LaptopShopOnline.Model;
using LaptopShopOnline.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopShopOnline.Service.Implement
{
    public class OrderService : IOrderService
    {
        private readonly LaptopShopOnlineDbContext _db;

        public OrderService(LaptopShopOnlineDbContext dbContext)
        {
            _db = dbContext;
        }



        //Change order status
        public bool ChangeOrderStatus(Guid? id)
        {
            var order = _db.Order.Find(id);
            order.OrderStatus = !order.OrderStatus;
            _db.SaveChanges();
            return order.OrderStatus;
        }
    }
}
