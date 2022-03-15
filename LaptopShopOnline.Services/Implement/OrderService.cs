using LaptopShopOnline.Common;
using LaptopShopOnline.Model;
using LaptopShopOnline.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace LaptopShopOnline.Service.Implement
{
    public class OrderService : IOrderService
    {
        private readonly LaptopShopOnlineDbContext _db;

        public OrderService(LaptopShopOnlineDbContext dbContext)
        {
            _db = dbContext;
        }



        public IPagedList<Order> GetAll(IQueryable<Order> orders, string searchString, string sortOrder, int? pageSize, int? page, dynamic ViewBag)
        {

            if (!String.IsNullOrEmpty(searchString))
            {
                orders = orders.Where(s => s.Shop.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "ShopName":
                    orders = orders.OrderBy(s => s.Shop.Name);
                    break;
                case "shop_name_desc":
                    orders = orders.OrderByDescending(s => s.Shop.Name);
                    break;
                case "CreatedOn":
                    orders = orders.OrderBy(s => s.CreatedOn);
                    break;
                case "created_on_desc":
                    orders = orders.OrderByDescending(s => s.CreatedOn);
                    break;
                case "OrderStatus":
                    orders = orders.OrderBy(s => s.OrderStatus);
                    break;
                case "order_status_desc":
                    orders = orders.OrderByDescending(s => s.OrderStatus);
                    break;
                default:
                    orders = orders.OrderByDescending(s => s.CreatedOn);
                    break;
            }

            //Sort order
            ViewBag.ShopNameSortParm = sortOrder == "ShopName" ? "shop_name_desc" : "ShopName";
            ViewBag.CreatedOnSortParm = sortOrder == "CreatedOn" ? "createdOn_desc" : "CreatedOn";
            ViewBag.OrderStatusSortParm = sortOrder == "OrderStatus" ? "order_status_desc" : "OrderStatus";
            //
            ViewBag.SearchString = searchString;
            ViewBag.SortOrder = sortOrder;

            // paging
            int pageNumber = (page ?? 1);
            int pageSizeNumber = pageSize ?? 10;
            var ordersPaging = orders.ToPagedList(pageNumber, pageSizeNumber);

            return ordersPaging;
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
