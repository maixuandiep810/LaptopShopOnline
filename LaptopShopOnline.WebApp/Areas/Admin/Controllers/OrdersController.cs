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





        // GET: Admin/Orders
        public ActionResult Index(string sortOrder, int? page, string searchString, string currentFilter, int? orderStatus)
        {
            CountMessage();
            CountProduct();
            CountOrder();

            if (page == null || sortOrder == null)
            {
                page = page ?? 1;
                sortOrder = sortOrder ?? "ShopName";
                searchString = searchString ?? "";
                orderStatus = orderStatus ?? -1;
                return Redirect(Flurl.Url.EncodeIllegalCharacters(SmartFormat.Smart.Format(CommonConstants.ROUTE_QUAN_TRI_DON_HANG_SEARCH_PARAMS,
                    new { sortOrder = sortOrder, page = page, searchString = searchString, orderStatus = orderStatus })));
            }

            //Sort order
            ViewBag.BuyerNameSortParm = sortOrder == "ShopName" ? "shop_name_desc" : "ShopName";

            //ViewBag.OrderStatusSortParm = sortOrder == "Price" ? "price_desc" : "Price";
            //ViewBag.CreatedOnSortParm = sortOrder == "PromotionPrice" ? "promotion_price_desc" : "PromotionPrice";

            ViewBag.SearchString = searchString;
            ViewBag.SortOrder = sortOrder;

            var orders = _serviceWrapper.Db.Order.Include(x => x.Buyer).Include(x => x.Shop).Where(x => x.IsDeleted == false);

            if (!String.IsNullOrEmpty(searchString))
            {
                orders = orders.Where(s => s.Buyer.UserName.Contains(searchString) || s.ShipPhone.Contains(searchString) || s.ShipEmail.Contains(searchString) || s.ShipAddress.Contains(searchString));
            }

            if (orderStatus >= (int)ENUM.OrderStatus.BUYER_PENDING || orderStatus >= (int)ENUM.OrderStatus.BUYER_PENDING)
            {
                orders = orders.Where(x => x.OrderStatus == orderStatus);
            }

            //Sort
            switch (sortOrder)
            {
                case "ShopName":
                    orders = orders.OrderBy(s => s.Shop.Name);
                    break;
                case "shop_name_desc":
                    orders = orders.OrderByDescending(s => s.Shop.Name);
                    break;
                //case "CreatedOn":
                //    orders = orders.OrderBy(s => s.CreatedOn);
                //    break;
                //case "createdOn_desc":
                //    orders = orders.OrderByDescending(s => s.CreatedOn);
                //    break;
                default:
                    orders = orders.OrderBy(s => s.Shop.Name);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(orders.ToPagedList(pageNumber, pageSize));
        }


        // GET: Admin/Orders
        public ActionResult IndexSG(string sortOrder, int? page, string searchString, string currentFilter, int? orderStatus)
        {
            CountMessage();
            CountProduct();
            CountOrder();

            if (page == null || sortOrder == null)
            {
                page = page ?? 1;
                sortOrder = sortOrder ?? "ShopName";
                searchString = searchString ?? "";
                orderStatus = orderStatus ?? -1;
                return Redirect(Flurl.Url.EncodeIllegalCharacters(SmartFormat.Smart.Format(CommonConstants.ROUTE_QUAN_TRI_DON_HANG_SEARCH_PARAMS,
                    new { sortOrder = sortOrder, page = page, searchString = searchString, orderStatus = orderStatus })));
            }

            //Sort order
            ViewBag.BuyerNameSortParm = sortOrder == "ShopName" ? "shop_name_desc" : "ShopName";

            //ViewBag.OrderStatusSortParm = sortOrder == "Price" ? "price_desc" : "Price";
            //ViewBag.CreatedOnSortParm = sortOrder == "PromotionPrice" ? "promotion_price_desc" : "PromotionPrice";

            ViewBag.SearchString = searchString;
            ViewBag.SortOrder = sortOrder;

            var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
            var orders = _serviceWrapper.Db.Order.Include(x => x.Buyer).Include(x => x.Shop).Where(x => x.IsDeleted == false && x.ShopId == userLoginSession.ShopId);

            if (!String.IsNullOrEmpty(searchString))
            {
                orders = orders.Where(s => s.Buyer.UserName.Contains(searchString) || s.ShipPhone.Contains(searchString) || s.ShipEmail.Contains(searchString) || s.ShipAddress.Contains(searchString));
            }

            if (orderStatus >= (int)ENUM.OrderStatus.BUYER_PENDING || orderStatus >= (int)ENUM.OrderStatus.BUYER_PENDING)
            {
                orders = orders.Where(x => x.OrderStatus == orderStatus);
            }

            //Sort
            switch (sortOrder)
            {
                case "ShopName":
                    orders = orders.OrderBy(s => s.Shop.Name);
                    break;
                case "shop_name_desc":
                    orders = orders.OrderByDescending(s => s.Shop.Name);
                    break;
                //case "CreatedOn":
                //    orders = orders.OrderBy(s => s.CreatedOn);
                //    break;
                //case "createdOn_desc":
                //    orders = orders.OrderByDescending(s => s.CreatedOn);
                //    break;
                default:
                    orders = orders.OrderBy(s => s.Shop.Name);
                    break;
            }
            int pageSize = 2;
            int pageNumber = (page ?? 1);
            return View(orders.ToPagedList(pageNumber, pageSize));
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
                order.OrderStatus = (int)ENUM.OrderStatus.BUYER_PENDING;
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
