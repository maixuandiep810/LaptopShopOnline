using LaptopShopOnline.Model.Entities;
using LaptopShopOnline.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopShopOnline.WebApp.Controllers.Shared.Components
{
    public class LoadNormalProduct2ViewComponent : ViewComponent
    {
        private readonly ServiceWrapper _serviceWrapper;

        public LoadNormalProduct2ViewComponent(ServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }

        public IViewComponentResult Invoke()
        {
            var products = new List<Product>();
            products = _serviceWrapper.Db.Product.Where(x => x.IsDeleted == false && x.IsNormalProduct2 == true).OrderByDescending(x => x.CreatedOn).Take(2).ToList();
            ViewBag.Count = products.Count();
            return View("LoadNormalProduct2", products);
        }
    }
}