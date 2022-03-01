using LaptopShopOnline.Common;
using LaptopShopOnline.Model.Entities;
using LaptopShopOnline.Service;
using LaptopShopOnline.WebApp.Common;
using LaptopShopOnline.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;


namespace LaptopShopOnline.WebApp.Controllers
{
    public class OrderController : BaseController
    {



        public OrderController(ServiceWrapper serviceWrapper) : base(serviceWrapper)
        {
        }



        // GET: Admin/Products
        public ActionResult Index(string sortOrder, int? page, string searchString, string currentFilter)
        {
            //paged
            ViewBag.CurrentSort = sortOrder;
            //Sort order
            ViewBag.PriceSortParm = sortOrder == "Total" ? "total_desc" : "Total";
            ViewBag.CreateOnSortParm = sortOrder == "CreateOn" ? "createOn_desc" : "CreateOn";
            ViewBag.OrderStatusSortParm = sortOrder == "OrderStatus" ? "orderStatus_desc" : "OrderStatus";
            var orders = _serviceWrapper.Db.Order.Where(x => x.IsDeleted == false);

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
                orders = orders.Where(s => s.Shop.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Total":
                    orders = orders.OrderBy(s => s.Total);
                    break;
                case "total_desc":
                    orders = orders.OrderByDescending(s => s.Total);
                    break;
                case "CreatOn":
                    orders = orders.OrderBy(s => s.CreatedOn);
                    break;
                case "createOn_desc":
                    orders = orders.OrderByDescending(s => s.CreatedOn);
                    break;
                case "OrderStatus":
                    orders = orders.OrderBy(s => s.OrderStatus);
                    break;
                case "orderStatus_desc":
                    orders = orders.OrderByDescending(s => s.OrderStatus);
                    break;
                default:
                    orders = orders.OrderByDescending(s => s.CreatedOn);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.SearchString = searchString;
            return View(orders.ToPagedList(pageNumber, pageSize));
        }




        public ActionResult Create(Guid? cartId, Guid? shopId, bool shouldOrderAll)
        {
            var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
            if (userLoginSession != null)
            {
                var carts = new List<Cart>();
                if (shouldOrderAll)
                {
                     carts = _serviceWrapper.Db.Cart.Include(x => x.Product).Where(x => x.BuyerId == userLoginSession.UserId).ToList();
                    return View(carts);
                }
                if (shopId != null)
                {
                     carts = _serviceWrapper.Db.Cart.Include(x => x.Product).Where(x => x.BuyerId == userLoginSession.UserId && x.Product.ShopId == shopId).ToList();
                    return View(carts);
                }
                 carts = _serviceWrapper.Db.Cart.Include(x => x.Product).Where(x => x.BuyerId == userLoginSession.UserId && x.Id == cartId).ToList();
                return View(carts);
            }
            else
            {
                SetAlert("Bạn phải đăng nhập để có thể mua hàng", "warning");
                return Redirect("/dang-nhap");
            }
        }
        //
        [HttpPost]
        public ActionResult Create([FromForm] Order order, Guid? cartId, Guid? shopId, bool shouldOrderAll)
        {
            var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
            if (userLoginSession != null)
            {
                var carts = new List<Cart>();
                if (shouldOrderAll)
                {
                    carts = _serviceWrapper.Db.Cart.Include(x => x.Product).Where(x => x.BuyerId == userLoginSession.UserId).ToList();
                }
                if (shopId != null)
                {
                    carts = _serviceWrapper.Db.Cart.Include(x => x.Product).Where(x => x.BuyerId == userLoginSession.UserId && x.Product.ShopId == shopId).ToList();
                }
                carts = _serviceWrapper.Db.Cart.Include(x => x.Product).Where(x => x.BuyerId == userLoginSession.UserId && x.Id == cartId).ToList();
                var groupedCarts = carts.ToLookup(x => x.Product.Shop);
                foreach (var groupedCart in groupedCarts)
                {
                    var newOrder = new Order
                    {
                        ShipName = order.ShipName,
                        ShipPhone = order.ShipPhone,
                        ShipAddress = order.ShipPhone,
                        ShipEmail = order.ShipEmail
                    };
                    newOrder.ShopId = groupedCart.Key.Id;
                    newOrder.BuyerId = userLoginSession.UserId;
                    AuditTable.InsertAuditFields(newOrder, userLoginSession.UserName);
                    foreach (var cart in groupedCart)
                    {
                        var newOrderDetail = new OrderDetail
                        {
                            ProductId = cart.ProductId,
                            Quantity = cart.Quantity,
                            Price = cart.Product.PromotionPrice > 0 ? cart.Product.PromotionPrice : cart.Product.Price
                        };
                        AuditTable.InsertAuditFields(newOrderDetail, userLoginSession.UserName);
                        newOrder.OrderDetails.Add(newOrderDetail);
                    }
                    SetAlert("Bạn đã đặt hàng thành công", "success");
                    _serviceWrapper.Db.SaveChanges();
                }
                return Redirect("/don-hang");
            }
            else
            {
                SetAlert("Bạn phải đăng nhập để có thể mua hàng", "warning");
                return Redirect("/dang-nhap");
            }
        }

    }
}