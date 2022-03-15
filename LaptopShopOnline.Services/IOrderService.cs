using LaptopShopOnline.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace LaptopShopOnline.Service
{
    public interface IOrderService
    {
        IPagedList<Order> GetAll(IQueryable<Order> orders, string searchString, string sortOrder, int? pageSize, int? page, dynamic ViewBag);
        void ChangeOrderStatus(Guid? id, int orderStatus);
    }
}
