using LaptopShopOnline.Common;
using LaptopShopOnline.Model.Entities;
using LaptopShopOnline.Service;
using LaptopShopOnline.WebApp.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;


namespace LaptopShopOnline.WebApp.Controllers
{
    public class ShopController : BaseController
    {



        public ShopController(ServiceWrapper serviceWrapper) : base(serviceWrapper)
        {
        }

        public ActionResult Index(string sortOrder, int? page, string searchString)
        {
            if (page == null || sortOrder == null)
            {
                page = page ?? 1;
                sortOrder = sortOrder ?? "Name";
                searchString = searchString ?? "";
            }

            var shops = _serviceWrapper.Db.Shop.Where(x => x.IsDeleted == false);

            int pageSize = 10;
            var shopsPaging = _serviceWrapper.ShopService.GetAll(shops, searchString, sortOrder, pageSize, page, ViewBag);

            return View(shopsPaging);
        }


        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var product = _serviceWrapper.Db.Shop.Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}