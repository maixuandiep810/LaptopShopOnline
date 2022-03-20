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
    public class OrdersController : BaseController
    {



        public OrdersController(ServiceWrapper serviceWrapper) : base(serviceWrapper)
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
                sortOrder = sortOrder ?? "ShopName";
                searchString = searchString ?? "";
            }

            var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);

            var orders = _serviceWrapper.Db.Order.Include(x => x.Shop).Include(x => x.OrderDetails).Where(x => x.IsDeleted == false && x.BuyerId == userLoginSession.UserId);

            int pageSize = 1;
            var ordersPaging = _serviceWrapper.OrderService.GetAll(orders, searchString, sortOrder, pageSize, page, ViewBag);

            return View(ordersPaging);
        }


        [HasCredential(RoleId = CommonConstants.SELLER_ROLE_READ_ID)]
        public ActionResult IndexSG(string sortOrder, int? page, string searchString)
        {
            CountProduct();
            CountOrder();

            if (page == null || sortOrder == null)
            {
                page = page ?? 1;
                sortOrder = sortOrder ?? "ShopName";
                searchString = searchString ?? "";
            }

            var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);

            var orders = _serviceWrapper.Db.Order.Include(x => x.Shop).Include(x => x.OrderDetails).Include(x => x.Buyer).Where(x => x.IsDeleted == false && x.ShopId == userLoginSession.ShopId);

            int pageSize = 1;
            var ordersPaging = _serviceWrapper.OrderService.GetAll(orders, searchString, sortOrder, pageSize, page, ViewBag);

            return View(ordersPaging);
        }


        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_BUSINESS_CREATE_ID)]
        public ActionResult Create()
        {
            CountMessage();
            CountOrder();
            CountProduct();
            return View();
        }
        // POST: Admin/Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
                order.Id = Guid.NewGuid();
                AuditTable.InsertAuditFields(order, userLoginSession.UserName);
                order.OrderStatus = (int)ENUM.OrderStatus.SHOP_PENDING;
                _serviceWrapper.Db.Order.Add(order);
                _serviceWrapper.Db.SaveChanges();
                SetAlert("Thêm mới thành công", "success");
                return Redirect(CommonConstants.ROUTE_QUAN_TRI_DON_HANG_PARAMS);
            }
            SetAlert("Thêm mới lỗi", "danger");
            return View(order);
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
            var order = _serviceWrapper.Db.Order.Include(x => x.OrderDetails).Where(p => p.IsDeleted == false).FirstOrDefault();
            if (order == null)
            {
                return NotFound();
            }
            ViewBag.OrderStatus = new SelectList(ENUM.GetSelectList_OrderStatus(), "Id", "Name");
            return View(order);
        }
        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_BUSINESS_UPDATE_ID)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
                AuditTable.UpdateAuditFields(order, userLoginSession.UserName);
                _serviceWrapper.Db.Entry(order).State = EntityState.Modified;
                _serviceWrapper.Db.SaveChanges();
                SetAlert("Cập nhật thành công", "success");
                return Redirect(CommonConstants.ROUTE_QUAN_TRI_SAN_PHAM_PARAMS);
            }
            SetAlert("Cập nhật lỗi", "danger");
            ViewBag.OrderStatus = new SelectList(ENUM.GetSelectList_OrderStatus(), "Id", "Name");
            return View(order);
        }

        [HasCredential(RoleId = CommonConstants.SELLER_ROLE_UPDATE_ID)]
        public ActionResult EditSG(Guid? id)
        {
            CountMessage();
            CountOrder();
            CountProduct();

            if (id == null)
            {
                return BadRequest();
            }
            var order = _serviceWrapper.Db.Order.Include(x => x.OrderDetails).ThenInclude(x => x.Product).Where(p => p.IsDeleted == false).FirstOrDefault();
            if (order == null)
            {
                return NotFound();
            }
            ViewBag.OrderStatus = new SelectList(ENUM.GetSelectList_OrderStatus(), "Id", "Name");
            return View(order);
        }
        [HasCredential(RoleId = CommonConstants.SELLER_ROLE_UPDATE_ID)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSG(Order order)
        {
            if (ModelState.IsValid)
            {
                var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
                AuditTable.UpdateAuditFields(order, userLoginSession.UserName);
                _serviceWrapper.Db.Entry(order).State = EntityState.Modified;
                _serviceWrapper.Db.SaveChanges();
                SetAlert("Cập nhật thành công", "success");
                return Redirect(CommonConstants.ROUTE_QUAN_TRI_NGUOI_BAN_DON_HANG_PARAMS);
            }
            SetAlert("Cập nhật lỗi", "danger");
            ViewBag.OrderStatus = new SelectList(ENUM.GetSelectList_OrderStatus(), "Id", "Name");
            return View(order);
        }
    }
}
