using LaptopShopOnline.Model.Entities;
using LaptopShopOnline.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopShopOnline.WebApp.Controllers.Shared.Components
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly ServiceWrapper _serviceWrapper;

        public FooterViewComponent(ServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }

        public IViewComponentResult Invoke()
        {
            var footer = _serviceWrapper.Db.Footer.SingleOrDefault(x => x.IsDeleted == false);
            return View("Footer", footer);
        }
    }
}