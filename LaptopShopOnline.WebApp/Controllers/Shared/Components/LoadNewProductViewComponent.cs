using LaptopShopOnline.Model.Entities;
using LaptopShopOnline.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopShopOnline.WebApp.Controllers.Shared.Components
{
    public class LoadNewProductViewComponent : ViewComponent
    {
        private readonly ServiceWrapper _serviceWrapper;

        public LoadNewProductViewComponent(ServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }

        public IViewComponentResult Invoke()
        {
            var products = new List<Product>();
            products = _serviceWrapper.Db.Product.Where(x => x.IsDeleted == false).OrderByDescending(x => x.CreatedOn).Take(6).ToList();
            ViewBag.Count = products.Count();
            return View("LoadNewProduct", products);
        }
    }
}