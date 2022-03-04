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
    public class ProductCategoriesController : BaseController
    {



        public ProductCategoriesController(ServiceWrapper serviceWrapper) : base(serviceWrapper)
        {

        }





        // GET: Admin/ProductCategories
        public ActionResult Index()
        {
            CountMessage();
            CountProduct();
            CountOrder();
            return View(_serviceWrapper.Db.ProductCategory.Where(x => x.IsDeleted == false).ToList());
        }





        // GET: Admin/ProductCategories/Details/5
        public ActionResult Details(Guid? id)
        {
            CountMessage();
            CountProduct();
            CountOrder();
            if (id == null)
            {
                return BadRequest();
            }
            var productCategory = _serviceWrapper.Db.ProductCategory.Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefault();
            if (productCategory == null)
            {
                return NotFound();
            }
            return View(productCategory);
        }





        // GET: Admin/ProductCategories/Create
        public ActionResult Create()
        {
            CountMessage();
            CountOrder();
            CountProduct();
            ViewBag.ProductCategoryId = new SelectList(_serviceWrapper.Db.User.Where(x => x.IsDeleted == false), "Id", "ProductCategoryId");
            return View();
        }
        // POST: Admin/ProductCategories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCategory productCategory)
        {
            CountMessage();
            CountOrder();
            CountProduct();
            if (ModelState.IsValid)
            {
                productCategory.Id = Guid.NewGuid();
                var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
                AuditTable.InsertAuditFields(productCategory, userLoginSession.UserName);
                _serviceWrapper.Db.ProductCategory.Add(productCategory);
                _serviceWrapper.Db.SaveChanges();
                SetAlert("Thêm mới thành công", "success");
                return Redirect("/quan-tri/loai-san-pham");
            }
            ViewBag.ProductCategoryId = new SelectList(_serviceWrapper.Db.User.Where(x => x.IsDeleted == false), "Id", "ProductCategoryId");
            return View(productCategory);
        }





        // GET: Admin/ProductCategories/Edit/5
        public ActionResult Edit(Guid? id)
        {
            CountMessage();
            CountProduct();
            CountOrder();
            if (id == null)
            {
                return BadRequest();
            }
            ProductCategory productCategory = _serviceWrapper.Db.ProductCategory.Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefault();
            if (productCategory == null)
            {
                return NotFound();
            }
            ViewBag.ProductCategoryId = new SelectList(_serviceWrapper.Db.User.Where(x => x.IsDeleted == false), "Id", "ProductCategoryId");
            return View(productCategory);
        }
        // POST: Admin/ProductCategories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductCategory productCategory)
        {
            CountMessage();
            CountOrder();
            CountProduct();
            if (ModelState.IsValid)
            {
                var oldProductCategory = _serviceWrapper.Db.ProductCategory.Where(x => x.IsDeleted == false && x.Id == productCategory.Id).FirstOrDefault();
                if (oldProductCategory == null)
                {
                    return NotFound();
                }
                var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
                AuditTable.UpdateAuditFields(productCategory, userLoginSession.UserName);
                _serviceWrapper.Db.Entry(productCategory).State = EntityState.Modified;
                _serviceWrapper.Db.SaveChanges();
                SetAlert("Cập nhật thành công", "success");
                return Redirect("/quan-tri/loai-san-pham");
            }
            ViewBag.ProductCategoryId = new SelectList(_serviceWrapper.Db.User.Where(x => x.IsDeleted == false), "Id", "ProductCategoryId");
            return View(productCategory);
        }
















        // GET: Admin/ProductCategories/Delete/5
        public ActionResult Delete(Guid? id)
        {
            var existProduct = _serviceWrapper.Db.Product.Where(x => x.ProductCategoryId == id && x.IsDeleted == false);
            if (existProduct != null)
            {
                return PartialView("_Delete");
            }
            if (id == null)
            {
                return BadRequest();
            }
            ProductCategory productCategory = _serviceWrapper.Db.ProductCategory.Find(id);
            if (productCategory == null)
            {
                return NotFound();
            }
            return View(productCategory);
        }
        // POST: Admin/ProductCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ProductCategory productCategory = _serviceWrapper.Db.ProductCategory.Find(id);
            productCategory.IsDeleted = true;
            _serviceWrapper.Db.SaveChanges();
            SetAlert("Xóa thành công", "success");
            return Redirect("/quan-tri/loai-san-pham");
        }
    }
}