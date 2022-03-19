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
namespace LaptopShopOnline.WebApp.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {



        public HomeController(ServiceWrapper serviceWrapper) : base(serviceWrapper)
        {

        }





        // GET: Admin/Home
        public ActionResult Index()
        {
            CountMessage();
            CountOrder();
            CountProduct();
            ViewBag.CountUserGroup = _serviceWrapper.Db.UserGroup.Count();
            ViewBag.CountUser = _serviceWrapper.Db.User.Where(x => x.IsDeleted == false).Count();
            ViewBag.CountRole = _serviceWrapper.Db.Role.Count();
            ViewBag.CountCredential = _serviceWrapper.Db.Credentials.Count();
            ViewBag.CountProduct = _serviceWrapper.Db.Product.Where(x => x.IsDeleted == false).Count();
            ViewBag.CountProductCategory = _serviceWrapper.Db.ProductCategory.Where(x => x.IsDeleted == false).Count();
            ViewBag.CountNews = _serviceWrapper.Db.News.Where(x => x.IsDeleted == false).Count();
            ViewBag.CountNewsCategory = _serviceWrapper.Db.NewsCategory.Where(x => x.IsDeleted == false).Count();
            ViewBag.CountShop = _serviceWrapper.Db.Shop.Where(x => x.IsDeleted == false).Count();
            ViewBag.CountOrder = _serviceWrapper.Db.Order.Where(x => x.IsDeleted == false).Count();
            return View();
        }
    }

}