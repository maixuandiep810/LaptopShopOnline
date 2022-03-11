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
    public class ProductController : BaseController
    {



        public ProductController(ServiceWrapper serviceWrapper) : base(serviceWrapper)
        {
        }


        // GET: Admin/Products
        public ActionResult Index(string sortOrder, int? page, string searchString)
        {
            if (page == null || sortOrder == null)
            {
                page = page ?? 1;
                sortOrder = sortOrder ?? "Name";
                searchString = searchString ?? "";
            }

            var products = _serviceWrapper.Db.Product.Include(p => p.ProductCategory).Where(x => x.IsDeleted == false);

            int pageSize = 10;
            var productsPaging = _serviceWrapper.ProductService.GetAll(products, searchString, sortOrder, pageSize, page, ViewBag);

            return View(productsPaging);
        }


        //Detail of Product
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var product = _serviceWrapper.Db.Product.Include(x => x.Shop).Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }









        //Load category for menu
        public ActionResult LoadCategory()
        {
            List<ProductCategory> productCategories = new List<ProductCategory>();
            productCategories = _serviceWrapper.Db.ProductCategory.Where(x => x.IsDeleted == false).ToList();
            var product = _serviceWrapper.Db.Product.ToList();
            ViewBag.Count = productCategories.Count();
            ViewBag.CountAllProduct = product.Count();
            return PartialView(productCategories);
        }
        //Load product from price
        public ActionResult CategoryDetail(ProductCategory productCategory)
        {
            List<Product> list = new List<Product>();
            list = _serviceWrapper.Db.Product.Where(x => x.IsDeleted == false && x.ProductCategoryId == productCategory.Id).ToList();
            ViewBag.Count = list.Count();
            return View(list);
        }
    }
}