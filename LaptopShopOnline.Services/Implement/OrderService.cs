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
        public void ChangeOrderStatus(Guid? id, int orderStatus)
        {
            var order = _db.Order.Find(id);
            order.OrderStatus = orderStatus;
            _db.SaveChanges();
        }
    }
}
