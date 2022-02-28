using LaptopShopOnline.Model.Entities;
using LaptopShopOnline.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopShopOnline.WebApp.Controllers.Shared.Components
{
    public class MainMenuViewComponent : ViewComponent
    {
        private readonly ServiceWrapper _serviceWrapper;

        public MainMenuViewComponent(ServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }

        public IViewComponentResult Invoke()
        {
            List<Menu> menus = new List<Menu>();
            menus = _serviceWrapper.Db.Menu.Where(x => x.ParentId == null && x.IsDeleted == false).OrderBy(x => x.DisplayOrder).ToList();
            return View("MainMenu", menus);
        }
    }
}