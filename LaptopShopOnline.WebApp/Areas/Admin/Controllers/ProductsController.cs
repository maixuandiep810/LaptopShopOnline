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
using System.Net;
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





        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_BUSINESS_READ_ID)]
        public ActionResult Index(string sortOrder, int? page, string searchString, Guid? productCategoryId, Guid? shopId)
        {
            CountMessage();
            CountProduct();
            CountOrder();

            if (page == null || sortOrder == null)
            {
                page = page ?? 1;
                sortOrder = sortOrder ?? "Name";
                searchString = searchString ?? "";
            }

            var products = _serviceWrapper.Db.Product.Include(p => p.ProductCategory).Where(x => x.IsDeleted == false);

            int pageSize = 10;
            var productsPaging = _serviceWrapper.ProductService.GetAll(products, productCategoryId, shopId, searchString, sortOrder, pageSize, page, ViewBag);

            return View(productsPaging);
        }

        //GET: Admin/Products
         public ActionResult IndexSG(string sortOrder, int? page, string searchString, Guid? productCategoryId)
        {
            CountProduct();
            CountOrder();

            if (page == null || sortOrder == null)
            {
                page = page ?? 1;
                sortOrder = sortOrder ?? "Name";
                searchString = searchString ?? "";
            }

            var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
            var products = _serviceWrapper.Db.Product.Include(p => p.ProductCategory).Where(x => x.IsDeleted == false);

            int pageSize = 10;
            var productsPaging = _serviceWrapper.ProductService.GetAll(products, productCategoryId, userLoginSession.ShopId, searchString, sortOrder, pageSize, page, ViewBag);

            //
            return View(productsPaging);
        }




        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_BUSINESS_READ_ID)]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Product product = _serviceWrapper.Db.Product.Where(p => p.IsDeleted == false).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HasCredential(RoleId = CommonConstants.SELLER_ROLE_CREATE_ID)]
        public ActionResult DetailsSG(Guid? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Product product = _serviceWrapper.Db.Product.Where(p => p.IsDeleted == false).FirstOrDefault();
            var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
            if (product == null && product.ShopId != userLoginSession.ShopId)
            {
                return NotFound();
            }
            return View(product);
        }





        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_BUSINESS_CREATE_ID)]
        public ActionResult Create()
        {
            CountMessage();
            CountOrder();
            CountProduct();
            ViewBag.ProductCategoryId = new SelectList(_serviceWrapper.Db.ProductCategory, "Id", "Name");
            return View();
        }
        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_BUSINESS_CREATE_ID)]
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
                return Redirect(CommonConstants.ROUTE_QUAN_TRI_SAN_PHAM_PARAMS);
            } 
                SetAlert("Thêm mới lỗi", "danger");
            ViewBag.ProductCategoryId = new SelectList(_serviceWrapper.Db.ProductCategory, "Id", "Name", product.ProductCategoryId);
            return View(product);
        }



        [HasCredential(RoleId = CommonConstants.SELLER_ROLE_CREATE_ID)]
        public ActionResult CreateSG()
        {
            CountOrder();
            CountProduct();
            ViewBag.ProductCategoryId = new SelectList(_serviceWrapper.Db.ProductCategory, "Id", "Name");
            return View();
        }
        [HasCredential(RoleId = CommonConstants.SELLER_ROLE_CREATE_ID)]
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
                return Redirect(CommonConstants.ROUTE_QUAN_TRI_NGUOI_BAN_SAN_PHAM_PARAMS);
            }
            SetAlert("Thêm mới lỗi", "danger");
            ViewBag.ProductCategoryId = new SelectList(_serviceWrapper.Db.ProductCategory, "Id", "Name", product.ProductCategoryId);
            return View(product);
        }







        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_BUSINESS_UPDATE_ID)]
        public ActionResult Edit(Guid? id)
        {
            CountMessage();
            CountOrder();
            CountProduct();

            if (id == null)
            {   
                return BadRequest();
            }
            Product product = _serviceWrapper.Db.Product.Where(p => p.IsDeleted == false && p.Id == id).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.ProductCategoryId = new SelectList(_serviceWrapper.Db.ProductCategory, "Id", "Name", product.ProductCategoryId);
            return View(product);
        }
        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_BUSINESS_UPDATE_ID)]
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
                return Redirect(CommonConstants.ROUTE_QUAN_TRI_SAN_PHAM_PARAMS);
            }
                SetAlert("Cập nhật lỗi", "danger");
            ViewBag.ProductCategoryId = new SelectList(_serviceWrapper.Db.ProductCategory, "Id", "Name", product.ProductCategoryId);
            //ViewBag.ProductStatus = new SelectList(ENUM.GetSelectList_ProductStatus(), "Id", "Name");
            return View(product);
        }



        [HasCredential(RoleId = CommonConstants.SELLER_ROLE_UPDATE_ID)]
        public ActionResult EditSG(Guid? id)
        {
            CountOrder();
            CountProduct();
            if (id == null)
            {
                return BadRequest();
            }
            Product product = _serviceWrapper.Db.Product.Where(p => p.IsDeleted == false && p.Id == id).FirstOrDefault();
            var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
            if (product == null && product.ShopId != userLoginSession.ShopId)
            {
                return NotFound();
            }
            ViewBag.ProductCategoryId = new SelectList(_serviceWrapper.Db.ProductCategory, "Id", "Name", product.ProductCategoryId);
            return View(product);
        }
        [HasCredential(RoleId = CommonConstants.SELLER_ROLE_UPDATE_ID)]
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
                return Redirect(CommonConstants.ROUTE_QUAN_TRI_SAN_PHAM_PARAMS);
            }
            SetAlert("Cập nhật lỗi", "danger");
            ViewBag.ProductCategoryId = new SelectList(_serviceWrapper.Db.ProductCategory, "Id", "Name", product.ProductCategoryId);
            return View(product);
        }





        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_BUSINESS_DELETE_ID)]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return PartialView("_Delete");
            }
            Product product = _serviceWrapper.Db.Product.Where(p => p.IsDeleted == false).FirstOrDefault();
            if (product == null)
            {
                return PartialView("_Delete");
            }
            return View(product);
        }
        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_BUSINESS_DELETE_ID)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Product product = _serviceWrapper.Db.Product.Where(p => p.IsDeleted == false).FirstOrDefault();
            product.IsDeleted = true;
            _serviceWrapper.Db.SaveChanges();
            SetAlert("Xóa thành công", "success");
            return Redirect(CommonConstants.ROUTE_QUAN_TRI_SAN_PHAM_PARAMS);
        }
    }
}
