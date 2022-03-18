using LaptopShopOnline.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace LaptopShopOnline.Service
{
    public interface IShopService
    {

        IPagedList<Shop> GetAll(IQueryable<Shop> shops, string searchString, string sortOrder, int? pageSize, int? page, dynamic ViewBag);
    }
}