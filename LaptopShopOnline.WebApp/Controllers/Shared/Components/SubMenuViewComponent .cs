using LaptopShopOnline.Model.Entities;
using LaptopShopOnline.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopShopOnline.WebApp.Controllers.Shared.Components
{
    public class SubMenuViewComponent : ViewComponent
    {
        private readonly ServiceWrapper _serviceWrapper;

        public SubMenuViewComponent(ServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }

        public IViewComponentResult Invoke(int parentId)
        {
            List<Menu> menus = new List<Menu>();
            menus = _serviceWrapper.Db.Menu.Where(x => x.ParentId == parentId && x.IsDeleted == false).OrderBy(x => x.DisplayOrder).ToList();
            var parentMenu = _serviceWrapper.Db.Menu.Where(x => x.Id == parentId).FirstOrDefault();
            var isVerticalSubMenu = (parentMenu != null && parentMenu.ParentId == null) ? true : false;
            ViewBag.IsVerticalSubMenu = isVerticalSubMenu;
            ViewBag.Count = menus.Count();
            return View("SubMenu", menus);
        }
    }
}