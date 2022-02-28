using LaptopShopOnline.Common;
using LaptopShopOnline.Model.Entities;
using LaptopShopOnline.Service;
using LaptopShopOnline.WebApp.Common;
using LaptopShopOnline.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopShopOnline.WebApp.Controllers.Shared.Components
{
    public class HeaderCartViewComponent : ViewComponent
    {
        private readonly ServiceWrapper _serviceWrapper;

        public HeaderCartViewComponent(ServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }

        public IViewComponentResult Invoke()
        {
            var cartItems = HttpContext.Session.Get<List<CartItem>>(CommonConstants.CART_SESSION);
            return View("HeaderCart", cartItems);
        }
    }
}