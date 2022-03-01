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
    public class ShopsController : BaseController
    {



        public ShopsController(ServiceWrapper serviceWrapper) : base(serviceWrapper)
        {
        }





        // GET: Admin/Products
        public ActionResult Index(string sortOrder, int? page, string searchString, string currentFilter)
        {
            CountMessage();
            CountProduct();
            CountOrder();
            //paged
            ViewBag.CurrentSort = sortOrder;
            //Sort order
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            var shops = _serviceWrapper.Db.Shop.Include(p => p.Seller).Where(x => x.IsDeleted == false);

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
                shops = shops.Where(s => s.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    shops = shops.OrderByDescending(s => s.Name);
                    break;
                default:
                    shops = shops.OrderBy(s => s.Name);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.SearchString = searchString;
            return View(shops.ToPagedList(pageNumber, pageSize));
        }





        // GET: Admin/Shops/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var shop = _serviceWrapper.Db.Shop.Find(id);
            if (shop == null)
            {
                return NotFound();
            }
            return View(shop);
        }



        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            CountMessage();
            CountOrder();
            CountProduct();
            ViewBag.SellerId = new SelectList(_serviceWrapper.Db.User, "Id", "UserName");
            return View();
        }
        // POST: Admin/Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Shop shop)
        {
            if (ModelState.IsValid)
            {
                var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
                shop.Id = Guid.NewGuid();
                AuditTable.InsertAuditFields(shop, userLoginSession.UserName);
                _serviceWrapper.Db.Shop.Add(shop);
                _serviceWrapper.Db.SaveChanges();
                SetAlert("Thêm mới thành công", "success");
                return Redirect("/quan-tri/quan-ly-cua-hang");
            }
            ViewBag.SellerId = new SelectList(_serviceWrapper.Db.User, "Id", "UserName", shop.SellerId);
            return View(shop);
        }





        // GET: Admin/Shops/Edit/5
        public ActionResult Edit(Guid? id)
        {
            CountMessage();
            CountOrder();
            CountProduct();
            if (id == null)
            {
                return BadRequest();
            }
            var shop = _serviceWrapper.Db.Shop.Find(id);
            if (shop == null)
            {
                return NotFound();
            }
            ViewBag.SellerId = new SelectList(_serviceWrapper.Db.User, "Id", "UserName", shop.SellerId);
            return View(shop);
        }
        // POST: Admin/Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Shop shop)
        {
            if (ModelState.IsValid)
            {
                var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
                AuditTable.UpdateAuditFields(shop, userLoginSession.UserName);
                _serviceWrapper.Db.Entry(shop).State = EntityState.Modified;
                _serviceWrapper.Db.SaveChanges();
                SetAlert("Cập nhật thành công", "success");
                return Redirect("/quan-tri/quan-ly-cua-hang");
            }
            ViewBag.SellerId = new SelectList(_serviceWrapper.Db.User, "Id", "UserName", shop.SellerId);
            return View(shop);
        }
        // GET: Admin/Seller/Shops
        public ActionResult EditSG()
        {
            //CountOrder();
            //CountProduct();
            var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
            var shop = _serviceWrapper.Db.Shop.Find(userLoginSession.ShopId);
            return View(shop);
        }
        // POST: Admin/Seller/Shops/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSG(Shop shop)
        {
            if (ModelState.IsValid)
            {
                var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
                if (userLoginSession.ShopId != shop.Id)
                {
                    return NotFound();
                }
                AuditTable.UpdateAuditFields(shop, userLoginSession.UserName);
                _serviceWrapper.Db.Entry(shop).State = EntityState.Modified;
                _serviceWrapper.Db.SaveChanges();
                SetAlert("Cập nhật thành công", "success");
                return Redirect("/quan-tri/nguoi-ban/quan-ly-cua-hang");
            }
            return View(shop);
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
            return Redirect("/quan-tri/cua-hang");
        }
    }
}
