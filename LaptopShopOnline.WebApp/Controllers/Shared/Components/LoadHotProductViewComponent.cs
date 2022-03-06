using LaptopShopOnline.Model.Entities;
using LaptopShopOnline.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopShopOnline.WebApp.Controllers.Shared.Components
{
    public class LoadHotProductViewComponent : ViewComponent
    {
        private readonly ServiceWrapper _serviceWrapper;

        public LoadHotProductViewComponent(ServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }

        public IViewComponentResult Invoke()
        {
            var products = new List<Product>();
            products = _serviceWrapper.Db.Product.Where(x => x.IsDeleted == false && x.IsTopHot == true).OrderByDescending(x => x.CreatedOn).Take(10).ToList();
            ViewBag.Count = products.Count();
            return View("LoadHotProduct", products);
        }
    }
}