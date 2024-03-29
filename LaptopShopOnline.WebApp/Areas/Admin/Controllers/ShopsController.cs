﻿using LaptopShopOnline.Common;
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using X.PagedList;

namespace LaptopShopOnline.WebApp.Areas.Admin.Controllers
{
    public class ShopsController : BaseController
    {



        public ShopsController(ServiceWrapper serviceWrapper) : base(serviceWrapper)
        {
        }





        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_BUSINESS_READ_ID)]
        public ActionResult Index(string sortOrder, int? page, string searchString)
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




            var shops = _serviceWrapper.Db.Shop.Include(p => p.Seller).Where(x => x.IsDeleted == false);

            if (!String.IsNullOrEmpty(searchString))
            {
                shops = shops.Where(s => s.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Name":
                    shops = shops.OrderBy(s => s.Name);
                    break;
                case "name_desc":
                    shops = shops.OrderByDescending(s => s.Name);
                    break;
                default:
                    break;
            }

            //Sort order
            ViewBag.UserNameSortParm = sortOrder == "Name" ? "name_desc" : "Name";
            ViewBag.SearchString = searchString;
            ViewBag.SortOrder = sortOrder;
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            // Đếm được số trang vì là IQueryable
            return View(shops.ToPagedList(pageNumber, pageSize));

        }





        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_BUSINESS_READ_ID)]
        public ActionResult Details(Guid? id)
        {
            CountMessage();
            CountProduct();
            CountOrder();

            if (id == null)
            {
                return BadRequest();
            }
            var shop = _serviceWrapper.Db.Shop.Include(p => p.Seller).Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefault();
            if (shop == null)
            {
                return NotFound();
            }
            return View(shop);
        }



        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_BUSINESS_CREATE_ID)]
        public ActionResult Create()
        {
            CountMessage();
            CountOrder();
            CountProduct();
            return View();
        }
        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_BUSINESS_CREATE_ID)]
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
                return Redirect(CommonConstants.ROUTE_QUAN_TRI_CUA_HANG_PARAMS);
            }
            SetAlert("Thêm mới lỗi", "danger");
            return View(shop);
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
            var shop = _serviceWrapper.Db.Shop.Include(p => p.Seller).Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefault();
            if (shop == null)
            {
                return NotFound();
            }
            return View(shop);
        }
        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_BUSINESS_UPDATE_ID)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Shop shop)
        {
            CountOrder();
            CountProduct();

            if (ModelState.IsValid)
            {
                var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
                AuditTable.UpdateAuditFields(shop, userLoginSession.UserName);
                _serviceWrapper.Db.Entry(shop).State = EntityState.Modified;
                _serviceWrapper.Db.SaveChanges();
                SetAlert("Cập nhật thành công", "success");
                return Redirect(CommonConstants.ROUTE_QUAN_TRI_CUA_HANG_PARAMS);
            }
            SetAlert("Cập nhật lỗi", "danger");
            return View(shop);
        }
        [HasCredential(RoleId = CommonConstants.SELLER_ROLE_UPDATE_ID)]
        public ActionResult EditSG()
        {
            var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
            var shop = _serviceWrapper.Db.Shop.Include(p => p.Seller).Where(x => x.IsDeleted == false && x.Id == userLoginSession.ShopId).FirstOrDefault();
            return View(shop);
        }
        [HasCredential(RoleId = CommonConstants.SELLER_ROLE_UPDATE_ID)]
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
                return Redirect(CommonConstants.ROUTE_QUAN_TRI_NGUOI_BAN_CUA_HANG_CAP_NHAT_PARAMS);
            }
            SetAlert("Cập nhật lỗi", "danger");
            return View(shop);
        }








        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_BUSINESS_DELETE_ID)]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return PartialView("_Delete");
            }
            var shop = _serviceWrapper.Db.Shop.Find(id);
            if (shop == null)
            {
                return PartialView("_Delete");
            }
            return View(shop);
        }

        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_BUSINESS_DELETE_ID)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var shop = _serviceWrapper.Db.Shop.Find(id);
            shop.IsDeleted = true;
            _serviceWrapper.Db.SaveChanges();
            SetAlert("Xóa thành công", "success");
            return Redirect(CommonConstants.ROUTE_QUAN_TRI_CUA_HANG_PARAMS);
        }
    }
}
