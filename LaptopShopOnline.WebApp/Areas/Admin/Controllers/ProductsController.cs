using LaptopShopOnline.Common;
using LaptopShopOnline.Model.Entities;
using LaptopShopOnline.Service;
using LaptopShopOnline.WebApp.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace LaptopShopOnline.WebApp.Areas.Admin.Controllers
{
    public class ProductsController : BaseController
    {



        private readonly IWebHostEnvironment _env;
        private readonly string _uploadFolder;
        private readonly string _contentFolder;



        public ProductsController(ServiceWrapper serviceWrapper, IWebHostEnvironment env) : base(serviceWrapper)
        {
            _env = env;
            _uploadFolder = Path.Combine(_env.ContentRootPath, "Content\\Data");
            _contentFolder = "/Content/Data/";
        }





        // GET: Admin/Products
        public ActionResult Index(string sortOrder, int? page, string searchString)
        {
            CountMessage();
            CountProduct();
            CountOrder();
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
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.SearchString = searchString;
            return View(product.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Products
        public ActionResult IndexSG(string sortOrder, int? page, string searchString, string currentFilter)
        {
            CountProduct();
            CountOrder();
            //paged
            ViewBag.CurrentSort = sortOrder;
            //Sort order
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";
            ViewBag.PromotionPriceSortParm = sortOrder == "PromotionPrice" ? "promotion_price_desc" : "PromotionPrice";
            ViewBag.QuantitySortParm = sortOrder == "Quantity" ? "quantity_desc" : "Quantity";
            var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
            var product = _serviceWrapper.Db.Product.Include(p => p.ProductCategory).Where(x => x.IsDeleted == false && x.ShopId == userLoginSession.ShopId);

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
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
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.SearchString = searchString;
            return View(product.ToPagedList(pageNumber, pageSize));
        }





        // GET: Admin/Products/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Product product = _serviceWrapper.Db.Product.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        // GET: Admin/Products/Details/5
        public ActionResult DetailsSG(Guid? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Product product = _serviceWrapper.Db.Product.Find(id);
            var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
            if (product == null && product.ShopId != userLoginSession.ShopId)
            {
                return NotFound();
            }
            return View(product);
        }





        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            CountMessage();
            CountOrder();
            CountProduct();
            ViewBag.ProductCategoryId = new SelectList(_serviceWrapper.Db.ProductCategory, "Id", "Name");
            ViewBag.ShopId = new SelectList(_serviceWrapper.Db.Shop, "Id", "Name");
            return View();
        }
        // POST: Admin/Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
                product.Id = Guid.NewGuid();
                AuditTable.InsertAuditFields(product, userLoginSession.UserName);
                _serviceWrapper.Db.Product.Add(product);
                _serviceWrapper.Db.SaveChanges();
                if (product.Image != null)
                    product.UrlImage = Path.Combine(_contentFolder, _serviceWrapper.ImageService.SaveImage(product.Image, _uploadFolder));
                if (product.Sub1Image != null)
                    product.Sub1UrlImage = Path.Combine(_contentFolder, _serviceWrapper.ImageService.SaveImage(product.Sub1Image, _uploadFolder));
                if (product.Sub2Image != null)
                    product.Sub2UrlImage = Path.Combine(_contentFolder, _serviceWrapper.ImageService.SaveImage(product.Sub2Image, _uploadFolder));
                _serviceWrapper.Db.SaveChanges();
                SetAlert("Thêm mới thành công", "success");
                return Redirect("/quan-tri/danh-muc-san-pham");
            }

            ViewBag.ProductCategoryId = new SelectList(_serviceWrapper.Db.ProductCategory, "Id", "Name", product.ProductCategoryId);
            ViewBag.ShopId = new SelectList(_serviceWrapper.Db.Shop, "Id", "Name", product.ShopId);
            return View(product);
        }
        //
        // GET: Admin/Products/Create
        public ActionResult CreateSG()
        {
            CountOrder();
            CountProduct();
            ViewBag.ProductCategoryId = new SelectList(_serviceWrapper.Db.ProductCategory, "Id", "Name");
            return View();
        }
        // POST: Admin/Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSG(Product product)
        {
            if (ModelState.IsValid)
            {
                var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
                product.Id = Guid.NewGuid();
                product.ShopId = userLoginSession.ShopId;
                AuditTable.InsertAuditFields(product, userLoginSession.UserName);
                _serviceWrapper.Db.Product.Add(product);
                _serviceWrapper.Db.SaveChanges();
                if (product.Image != null)
                    product.UrlImage = Path.Combine(_contentFolder, _serviceWrapper.ImageService.SaveImage(product.Image, _uploadFolder));
                if (product.Sub1Image != null)
                    product.Sub1UrlImage = Path.Combine(_contentFolder, _serviceWrapper.ImageService.SaveImage(product.Sub1Image, _uploadFolder));
                if (product.Sub2Image != null)
                    product.Sub2UrlImage = Path.Combine(_contentFolder, _serviceWrapper.ImageService.SaveImage(product.Sub2Image, _uploadFolder));
                _serviceWrapper.Db.SaveChanges();
                SetAlert("Thêm mới thành công", "success");
                return Redirect("/quan-tri/nguoi-ban/danh-muc-san-pham");
            }

            ViewBag.ProductCategoryId = new SelectList(_serviceWrapper.Db.ProductCategory, "Id", "Name", product.ProductCategoryId);
            return View(product);
        }
        //






        // GET: Admin/Products/Edit/5
        public ActionResult Edit(Guid? id)
        {
            CountMessage();
            CountOrder();
            CountProduct();
            if (id == null)
            {
                return BadRequest();
            }
            Product product = _serviceWrapper.Db.Product.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.ProductCategoryId = new SelectList(_serviceWrapper.Db.ProductCategory, "Id", "Name", product.ProductCategoryId);
            ViewBag.ShopId = new SelectList(_serviceWrapper.Db.Shop, "Id", "Name", product.ShopId);
            return View(product);
        }
        // POST: Admin/Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
                AuditTable.UpdateAuditFields(product, userLoginSession.UserName);
                _serviceWrapper.Db.Entry(product).State = EntityState.Modified;
                _serviceWrapper.Db.SaveChanges();
                SetAlert("Cập nhật thành công", "success");
                return Redirect("/quan-tri/danh-muc-san-pham");
            }
            ViewBag.ProductCategoryId = new SelectList(_serviceWrapper.Db.ProductCategory, "Id", "Name", product.ProductCategoryId);
            ViewBag.ShopId = new SelectList(_serviceWrapper.Db.Shop, "Id", "Name", product.ShopId);
            return View(product);
        }
        //
        // GET: Admin/Products/Edit/5
        public ActionResult EditSG(Guid? id)
        {
            CountOrder();
            CountProduct();
            if (id == null)
            {
                return BadRequest();
            }
            Product product = _serviceWrapper.Db.Product.Find(id);
            var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
            if (product == null && product.ShopId != userLoginSession.ShopId)
            {
                return NotFound();
            }
            ViewBag.ProductCategoryId = new SelectList(_serviceWrapper.Db.ProductCategory, "Id", "Name", product.ProductCategoryId);
            return View(product);
        }
        // POST: Admin/Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSG(Product product)
        {
            if (ModelState.IsValid)
            {
                var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
                if (product.ShopId != userLoginSession.ShopId)
                {
                    return NotFound();
                }
                AuditTable.UpdateAuditFields(product, userLoginSession.UserName);
                _serviceWrapper.Db.Entry(product).State = EntityState.Modified;
                _serviceWrapper.Db.SaveChanges();
                SetAlert("Cập nhật thành công", "success");
                return Redirect("/quan-tri/nguoi-ban/danh-muc-san-pham");
            }
            ViewBag.ProductCategoryId = new SelectList(_serviceWrapper.Db.ProductCategory, "Id", "Name", product.ProductCategoryId);
            return View(product);
        }





        // GET: Admin/Products/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Product product = _serviceWrapper.Db.Product.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Product product = _serviceWrapper.Db.Product.Find(id);
            product.IsDeleted = true;
            _serviceWrapper.Db.SaveChanges();
            SetAlert("Xóa thành công", "success");
            return Redirect("/quan-tri/danh-muc-san-pham");
        }
    }
}
