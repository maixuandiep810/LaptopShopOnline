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
            //paged
            ViewBag.CurrentSort = sortOrder;
            //Sort order
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "Name";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";
            ViewBag.PromotionPriceSortParm = sortOrder == "PromotionPrice" ? "promotion_price_desc" : "PromotionPrice";
            ViewBag.QuantitySortParm = sortOrder == "Quantity" ? "quantity_desc" : "Quantity";
            var product = _serviceWrapper.Db.Product.Include(p => p.ProductCategory).Where(x => x.IsDeleted == false);

            if (searchString == null)
            {
                page = 1;
            }

            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                product = product.Where(s => s.Name.Contains(searchString)
                    || s.Price.ToString().Contains(searchString)
                    || s.PromotionPrice.ToString().Contains(searchString)
                    || s.ProductCategory.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Name":
                    product = product.OrderBy(s => s.Name);
                    break;
                case "name_desc":
                    product = product.OrderByDescending(s => s.Name);
                    break;
                case "Price":
                    product = product.OrderBy(s => s.Price);
                    break;
                case "price_desc":
                    product = product.OrderByDescending(s => s.Price);
                    break;
                case "PromotionPrice":
                    product = product.OrderBy(s => s.PromotionPrice);
                    break;
                case "promotion_price_desc":
                    product = product.OrderByDescending(s => s.PromotionPrice);
                    break;
                case "Quantity":
                    product = product.OrderBy(s => s.Quantity);
                    break;
                case "quantity_desc":
                    product = product.OrderByDescending(s => s.Quantity);
                    break;
                default:
                    product = product.OrderBy(s => s.Name);
                    break;
            }
            int pageSize = 16;
            int pageNumber = (page ?? 1);
            ViewBag.SearchString = searchString;
            return View(product.ToPagedList(pageNumber, pageSize));
        }


        //Detail of Product
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var product = _serviceWrapper.Db.Product.Include(x => x.Shop).Where(x => x.Id == id).FirstOrDefault();
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