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
    public class OrderDetailsController : BaseController
    {



        public OrderDetailsController(ServiceWrapper serviceWrapper) : base(serviceWrapper)
        {

        }





        // GET: Admin/Orders
        public ActionResult Index(Guid? orderId)
        {
            CountMessage();
            CountProduct();
            CountOrder();

            var orderDetails = _serviceWrapper.Db.OrderDetail.Include(x => x.Product).Include(x => x.Order).Where(x => x.IsDeleted == false);
            return View(orderDetails);
        }


        // GET: Admin/Orders
        public ActionResult IndexSG()
        {
            CountMessage();
            CountProduct();
            CountOrder();

            var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
            var orderDetails = _serviceWrapper.Db.OrderDetail.Include(x => x.Product).Include(x => x.Order).Where(x => x.IsDeleted == false && x.Order.BuyerId == userLoginSession.UserId);
            return View(orderDetails);
        }


        // GET: Admin/Products/Create
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




        // GET: Admin/Products/Create
        public ActionResult Edit(Guid? id)
        {
            CountMessage();
            CountOrder();
            CountProduct();
            if (id == null)
            {
                return BadRequest();
            }
            var order = _serviceWrapper.Db.Order.Where(p => p.IsDeleted == false).FirstOrDefault();
            if (order == null)
            {
                return NotFound();
            }
            ViewBag.OrderStatus = new SelectList(ENUM.GetSelectList_OrderStatus(), "Id", "Name");
            return View(order);
        }
        // POST: Admin/Products/Create
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

    }
}
