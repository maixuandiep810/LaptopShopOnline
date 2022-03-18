using LaptopShopOnline.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace LaptopShopOnline.Service.Implement
{
    public class ShopService : IShopService
    {
        public IPagedList<Shop> GetAll(IQueryable<Shop> shops, string searchString, string sortOrder, int? pageSize, int? page, dynamic ViewBag)
        {

            if (!String.IsNullOrEmpty(searchString))
            {
                shops = shops.Where(s => s.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Name":
                    shops = shops.OrderBy(s => s.Name);
                    break;
                case "name_desc":
                    shops = shops.OrderByDescending(s => s.Name);
                    break;
                default:
                    break;
            }

            //Sort order
            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";
            //
            ViewBag.SearchString = searchString;
            ViewBag.SortOrder = sortOrder;

            // paging
            int pageNumber = (page ?? 1);
            int pageSizeNumber = pageSize ?? 10;
            var shopsPaging = shops.ToPagedList(pageNumber, pageSizeNumber);

            return shopsPaging;
        }
    }
}
