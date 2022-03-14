// using LaptopShopOnline.Common;
// using LaptopShopOnline.Model.Entities;
// using LaptopShopOnline.Service;
// using LaptopShopOnline.WebApp.Common;
// using LaptopShopOnline.WebApp.Models;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.Rendering;
// using Microsoft.EntityFrameworkCore;
// using Newtonsoft.Json;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using X.PagedList;


// namespace LaptopShopOnline.WebApp.Controllers
// {
//     public class OrderController : BaseController
//     {



//         public OrderController(ServiceWrapper serviceWrapper) : base(serviceWrapper)
//         {
//         }



//         // GET: Admin/Products
//         //[HasCredential(RoleId = "BUYER_ROLE")]
//         public ActionResult Index(string sortOrder, int? page, string searchString)
//         {
//             //paged
//             ViewBag.CurrentSort = sortOrder;
//             //Sort order
//             ViewBag.PriceSortParm = sortOrder == "Total" ? "total_desc" : "Total";
//             ViewBag.CreateOnSortParm = sortOrder == "CreateOn" ? "createOn_desc" : "CreateOn";
//             ViewBag.OrderStatusSortParm = sortOrder == "OrderStatus" ? "orderStatus_desc" : "OrderStatus";
//             var orders = _serviceWrapper.Db.Order.Where(x => x.IsDeleted == false);

//             if (searchString == null)
//             {
//                 page = 1;
//             }

//             ViewBag.CurrentFilter = searchString;

//             if (!String.IsNullOrEmpty(searchString))
//             {
//                 orders = orders.Where(s => s.Shop.Name.Contains(searchString));
//             }
//             switch (sortOrder)
//             {
//                 case "Total":
//                     orders = orders.OrderBy(s => s.Total);
//                     break;
//                 case "total_desc":
//                     orders = orders.OrderByDescending(s => s.Total);
//                     break;
//                 case "CreatOn":
//                     orders = orders.OrderBy(s => s.CreatedOn);
//                     break;
//                 case "createOn_desc":
//                     orders = orders.OrderByDescending(s => s.CreatedOn);
//                     break;
//                 case "OrderStatus":
//                     orders = orders.OrderBy(s => s.OrderStatus);
//                     break;
//                 case "orderStatus_desc":
//                     orders = orders.OrderByDescending(s => s.OrderStatus);
//                     break;
//                 default:
//                     orders = orders.OrderByDescending(s => s.CreatedOn);
//                     break;
//             }
//             int pageSize = 10;
//             int pageNumber = (page ?? 1);
//             ViewBag.SearchString = searchString;
//             return View(orders.ToPagedList(pageNumber, pageSize));
//         }



//         //[HasCredential(RoleId = "BUYER_ROLE")]
//         public ActionResult Create(Guid? cartId, Guid? shopId, bool shouldOrderAll)
//         {
//             var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
//             var createOrderVM = new CreateOrderModel();
//             if (shouldOrderAll)
//             {
//                 createOrderVM.Carts = _serviceWrapper.Db.Cart.Include(x => x.Product).ThenInclude(x => x.Shop).Where(x => x.BuyerId == userLoginSession.UserId).ToList();
//                 return View(createOrderVM);
//             }
//             else
//             if (shopId != null)
//             {
//                 createOrderVM.Carts = _serviceWrapper.Db.Cart.Include(x => x.Product).ThenInclude(x => x.Shop).Where(x => x.BuyerId == userLoginSession.UserId && x.Product.ShopId == shopId).ToList();
//                 return View(createOrderVM);
//             }
//             else
//             {
//                 createOrderVM.Carts = _serviceWrapper.Db.Cart.Include(x => x.Product).ThenInclude(x => x.Shop).Where(x => x.BuyerId == userLoginSession.UserId && x.Id == cartId).ToList();
//             }
//             return View(createOrderVM);
//         }
//         //
//         //[HasCredential(RoleId = "BUYER_ROLE")]
//         [HttpPost]
//         public ActionResult Create([FromForm] Order order, Guid? cartId, Guid? shopId, bool shouldOrderAll)
//         {

//             var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
//             if (userLoginSession != null)
//             {
//                 var carts = new List<Cart>();
//                 if (shouldOrderAll)
//                 {
//                     carts = _serviceWrapper.Db.Cart.Include(x => x.Product).ThenInclude(x => x.Shop).Where(x => x.BuyerId == userLoginSession.UserId).ToList();
//                 }
//                 else if (shopId != null)
//                 {
//                     carts = _serviceWrapper.Db.Cart.Include(x => x.Product).ThenInclude(x => x.Shop).Where(x => x.BuyerId == userLoginSession.UserId && x.Product.ShopId == shopId).ToList();
//                 }
//                 else
//                 {
//                     carts = _serviceWrapper.Db.Cart.Include(x => x.Product).ThenInclude(x => x.Shop).Where(x => x.BuyerId == userLoginSession.UserId && x.Id == cartId).ToList();
//                 }
//                 if (ModelState.IsValid)
//                 {
//                     var groupedCarts = carts.ToLookup(x => x.Product.Shop);
//                     foreach (var groupedCart in groupedCarts)
//                     {
//                         var newOrder = new Order
//                         {
//                             ShipName = order.ShipName,
//                             ShipPhone = order.ShipPhone,
//                             ShipAddress = order.ShipPhone,
//                             ShipEmail = order.ShipEmail
//                         };
//                         newOrder.ShopId = groupedCart.Key.Id;
//                         newOrder.BuyerId = userLoginSession.UserId;
//                         newOrder.OrderStatus = (int)ENUM.OrderStatus.PENDING;
//                         AuditTable.InsertAuditFields(newOrder, userLoginSession.UserName);
//                         foreach (var cart in groupedCart)
//                         {
//                             var newOrderDetail = new OrderDetail
//                             {
//                                 ProductId = cart.ProductId,
//                                 Quantity = cart.Quantity,
//                                 Price = cart.Product.PromotionPrice > 0 ? cart.Product.PromotionPrice : cart.Product.Price
//                             };
//                             AuditTable.InsertAuditFields(newOrderDetail, userLoginSession.UserName);
//                             newOrder.OrderDetails.Add(newOrderDetail);
//                             _serviceWrapper.Db.Cart.Remove(cart);
//                             _serviceWrapper.Db.Order.Add(newOrder);
//                         }
//                         _serviceWrapper.Db.SaveChanges();
//                     }
//                     SetAlert("Bạn đã đặt hàng thành công", "success");
//                     return Redirect("/don-hang");bbb
//                 }
//                 var createOrderVM = new CreateOrderModel();
//                 createOrderVM.Carts = carts;
//                 createOrderVM.Order = order;
//                 return View(createOrderVM);
//             }
//             else
//             {
//                 SetAlert("Bạn phải đăng nhập để có thể mua hàng", "warning");
//                 return Redirect("/dang-nhap");
//             }

//         }

//     }
// }