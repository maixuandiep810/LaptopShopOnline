using LaptopShopOnline.Model.Entities;
using LaptopShopOnline.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopShopOnline.WebApp.Controllers.Shared.Components
{
    public class SlideViewComponent : ViewComponent
    {
        private readonly ServiceWrapper _serviceWrapper;

        public SlideViewComponent(ServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }

        public IViewComponentResult Invoke()
        {
            List<Slide> slides = new List<Slide>();
            slides = _serviceWrapper.Db.Slide.Where(x => x.IsDeleted == false).ToList();
            ViewBag.Count = slides.Count();
            return View("Slide", slides);
        }
    }
}