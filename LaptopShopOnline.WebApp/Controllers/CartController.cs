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
using System.Net;
using System.Threading.Tasks;
using X.PagedList;


namespace LaptopShopOnline.WebApp.Controllers
{
    public class CartController : BaseController
    {



        public CartController(ServiceWrapper serviceWrapper) : base(serviceWrapper)
        {
        }



        // GET: Cart
        //[HasCredential(RoleId = "BUYER_ROLE")]
        public ActionResult Index()
        {
            var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
            var carts = _serviceWrapper.Db.Cart.Include(x => x.Product).ThenInclude(x => x.Shop).Where(x => x.IsDeleted == false && x.BuyerId == userLoginSession.UserId).ToList();
            return View(carts);
        }

        [HttpPost]
        public JsonResult ApiAdd([FromBody] Cart cart)
        {
            var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
            JsonResultData<int> jsonResultData = null;
            if (userLoginSession == null)
            {
                jsonResultData = new JsonResultData<int>
                {
                    Message = "Bạn phải đăng nhập để có thể mua hàng"
                };
                return new JsonResult(jsonResultData) { StatusCode = (int)HttpStatusCode.Unauthorized };
            }

            var product = _serviceWrapper.Db.Product.Where(p => p.IsDeleted == false).FirstOrDefault();
            if (product == null || cart.Quantity <= 0)
            {
                jsonResultData = new JsonResultData<int>
                {
                    Message = "Thêm mới lỗi"
                };
                return new JsonResult(jsonResultData) { StatusCode = (int)HttpStatusCode.NotFound };
            }
            var cartBuyer = _serviceWrapper.Db.Cart.Where(x => x.IsDeleted == false && x.ProductId == cart.ProductId && x.IsDeleted == false && x.BuyerId == userLoginSession.UserId).FirstOrDefault();

            if (cartBuyer != null)
            {
                jsonResultData = new JsonResultData<int>
                {
                    Message = "Thêm mới lỗi. Sản phẩm đã có trong giỏ hàng."
                };
                return new JsonResult(jsonResultData) { StatusCode = (int)HttpStatusCode.BadRequest };
            }

            var newCartBuyer = new Cart
            {
                BuyerId = userLoginSession.UserId,
                ProductId = cart.ProductId,
                Quantity = cart.Quantity
            };
            _serviceWrapper.Db.Cart.Add(newCartBuyer);

            _serviceWrapper.Db.SaveChanges();
            var cartsCount = _serviceWrapper.Db.Cart.Count();
            jsonResultData = new JsonResultData<int>
            {
                Data = cartsCount,
                Message = "Thêm mới thành công"
            };
            return new JsonResult(jsonResultData) { StatusCode = (int)HttpStatusCode.OK };
        }



        //
        [HttpPost]
        public JsonResult ApiEdit([FromBody] Cart cart)
        {
            var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
            JsonResultData<int> jsonResultData = null;
            if (userLoginSession == null)
            {
                jsonResultData = new JsonResultData<int>
                {
                    Message = "Bạn phải đăng nhập để có thể mua hàng"
                };
                return new JsonResult(jsonResultData) { StatusCode = (int)HttpStatusCode.Unauthorized };
            }

            var existedCart = _serviceWrapper.Db.Cart.Where(p => p.IsDeleted == false && p.Id == cart.Id).FirstOrDefault();
            if (existedCart == null || cart.Quantity <= 0)
            {
                jsonResultData = new JsonResultData<int>
                {
                    Message = "Cập nhật lỗi"
                };
                return new JsonResult(jsonResultData) { StatusCode = (int)HttpStatusCode.BadRequest };
            }

            existedCart.Quantity = cart.Quantity;
            _serviceWrapper.Db.SaveChanges();

            jsonResultData = new JsonResultData<int>
            {
                Message = "Cập nhật thành công"
            };
            return new JsonResult(jsonResultData) { StatusCode = (int)HttpStatusCode.OK };
        }





        //[HasCredential(RoleId = "BUYER_ROLE")]
        public ActionResult Delete(Guid? cartId, Guid? shopId, bool shouldDeleteAll)
        {
            var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
            var cartsCount = 0;
            if (shouldDeleteAll)
            {
                cartsCount = _serviceWrapper.Db.Cart.Where(x => x.BuyerId == userLoginSession.UserId).Count();
            }
            else if (shopId != null)
            {
                cartsCount = _serviceWrapper.Db.Cart.Include(x => x.Product).ThenInclude(x => x.Shop).Where(x => x.BuyerId == userLoginSession.UserId && x.Product.ShopId == shopId).Count();
            }
            else
            {
                cartsCount = _serviceWrapper.Db.Cart.Include(x => x.Product).ThenInclude(x => x.Shop).Where(x => x.BuyerId == userLoginSession.UserId && x.Id == cartId).Count();
            }
            if (cartsCount <= 0)
            {
                return PartialView("_Delete");
            }
            return PartialView();
        }

        //[HasCredential(RoleId = "BUYER_ROLE")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid? cartId, Guid? shopId, bool shouldDeleteAll)
        {
            var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
            IQueryable<Cart> carts = null;
            if (shouldDeleteAll)
            {
                carts = _serviceWrapper.Db.Cart.Where(x => x.BuyerId == userLoginSession.UserId);
            }
            else
            if (shopId != null)
            {
                carts = _serviceWrapper.Db.Cart.Include(x => x.Product).ThenInclude(x => x.Shop).Where(x => x.BuyerId == userLoginSession.UserId && x.Product.ShopId == shopId);
            }
            else
            {
                carts = _serviceWrapper.Db.Cart.Include(x => x.Product).ThenInclude(x => x.Shop).Where(x => x.BuyerId == userLoginSession.UserId && x.Id == cartId);
            }


            if (carts.Count() <= 0)
            {
                SetAlert("Xóa lỗi", "danger");
                return Redirect(CommonConstants.ROUTE_GIO_HANG_PARAMS);
            }
            _serviceWrapper.Db.Cart.RemoveRange(carts);
            _serviceWrapper.Db.SaveChanges();
            SetAlert("Xóa thành công", "success");
            return Redirect(CommonConstants.ROUTE_GIO_HANG_PARAMS);
        }


        //// //[HasCredential(RoleId = "BUYER_ROLE")]
        //// public ActionResult Add(Guid? productId, int quantity)
        //// {
        ////     if (quantity <= 0)
        ////     {
        ////         SetAlert("Thêm vào giỏ thất bại", "warning");
        ////         return Redirect(Request.Headers["Referer"].ToString());
        ////     }
        ////     var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
        ////     if (userLoginSession != null)
        ////     {
        ////         var product = _serviceWrapper.Db.Product.Find(productId);
        ////         var carts = _serviceWrapper.Db.Cart.Where(x => x.IsDeleted == false &&  x.BuyerId == userLoginSession.UserId && x.ProductId == product.Id).FirstOrDefault();
        ////         if (carts != null)
        ////         {
        ////             carts.Quantity += quantity;
        ////             _serviceWrapper.Db.SaveChanges();
        ////         }
        ////         else
        ////         {
        ////             var newCart = new Cart
        ////             {
        ////                 BuyerId = userLoginSession.UserId,
        ////                 ProductId = product.Id,
        ////                 Quantity = quantity
        ////             };
        ////             _serviceWrapper.Db.Cart.Add(newCart);
        ////             _serviceWrapper.Db.SaveChanges();
        ////         }

        ////         SetAlert("Thêm vào giỏ thành công", "success");
        ////         return Redirect(Request.Headers["Referer"].ToString());
        ////     }
        ////     else
        ////     {
        ////         SetAlert("Bạn phải đăng nhập để có thể mua hàng", "warning");
        ////         return Redirect("/dang-nhap");
        ////     }
        //// }

        ////[HasCredential(RoleId = "BUYER_ROLE")]
        //[HttpPost]
        //public ActionResult Edit(Cart cart)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (cart.Quantity <= 0)
        //        {
        //            SetAlert("Thêm vào giỏ thất bại", "warning");
        //            return Redirect(CommonConstants.ROUTE_GIO_HANG_PARAMS);
        //        }
        //        var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
        //        _serviceWrapper.Db.Entry(cart).State = EntityState.Modified;
        //        _serviceWrapper.Db.SaveChanges();
        //        SetAlert("Cập nhật thành công", "success");
        //        return Redirect(CommonConstants.ROUTE_GIO_HANG_PARAMS);
        //    }
        //    SetAlert("Thêm vào giỏ thất bại", "warning");
        //    return Redirect(CommonConstants.ROUTE_GIO_HANG_PARAMS);
        //}


        // Payment for item
        //[HttpGet]
        // public ActionResult Payment()
        // {
        //     var cart = Session[CartSession];
        //     var list = new List<CartItem>();
        //     if (cart != null)
        //     {
        //         list = (List<CartItem>)cart;
        //     }
        //     return View(list);
        // }



        // [HttpPost]
        // public ActionResult Payment(string mobile)
        // {
        //     var session = (UserLogin)Session[CommonConstants.USER_LOGIN_SESSION];

        //     var order = new Order();
        //     order.UserId = session.UserId;
        //     order.CreatedOn = DateTime.Now;
        //     order.ShipAddress = session.Address;
        //     order.ShipPhone = mobile;
        //     order.ShipName = session.FullName;
        //     order.ShipEmail = session.Email;
        //     order.Status = false;
        //     order.CreatedOn = DateTime.Now;
        //     order.CreatedBy = session.UserName;
        //     order.IsDeleted = false;

        //     try
        //     {
        //         var id = new OrderDao().Insert(order);
        //         var cart = (List<CartItem>)Session[CartSession];
        //         var detailDao = new OrderDetailsDao();
        //         decimal total = 0;
        //         foreach (var item in cart)
        //         {
        //             var orderDetail = new OrderDetail();
        //             orderDetail.ProductId = item.Product.Id;
        //             orderDetail.OrderId = id;
        //             if (item.Product.PromotionPrice != null)
        //             {
        //                 orderDetail.Price = item.Product.PromotionPrice;
        //                 total += (item.Product.PromotionPrice.GetValueOrDefault(0) * item.Quantity);
        //             }
        //             else
        //             {
        //                 orderDetail.Price = item.Product.Price;
        //                 total += (item.Product.Price.GetValueOrDefault(0) * item.Quantity);
        //             }
        //             orderDetail.Quantity = item.Quantity;
        //             orderDetail.CreatedOn = DateTime.Now;
        //             orderDetail.CreatedBy = session.UserName;
        //             orderDetail.IsDeleted = false;
        //             detailDao.Insert(orderDetail);

        //             //Sub quantiy in Product table
        //             var product = new ProductDao();
        //             product.setQuantity(orderDetail.ProductId, orderDetail.Quantity);
        //         }
        //         string content = System.IO.File.ReadAllText(Server.MapPath("~/Content/Client/neworder.html"));

        //         content = content.Replace("{{CustomerName}}", session.FullName);
        //         content = content.Replace("{{Phone}}", mobile);
        //         content = content.Replace("{{Email}}", session.Email);
        //         content = content.Replace("{{Address}}", session.Address);
        //         content = content.Replace("{{Total}}", total.ToString(CommonConstants.CurrencyFormat, CommonConstants.VietNamCultureInfo));
        //         var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

        //         new MailHelper().SendMail(session.Email, "Đơn hàng mới từ Free Style Shoe", content);
        //         new MailHelper().SendMail(toEmail, "Đơn hàng mới từ Free Style Shoe", content);
        //     }
        //     catch (Exception)
        //     {
        //         //ghi log
        //         SetAlert("Lỗi!", "error");
        //     }
        //     Session.Remove(CartSession);
        //     SetAlert("Bạn vừa mua hàng thành công. Nhân viên của chúng tối sẽ liên hệ với bạn trong vài phút để xác nhận đơn hàng.", "success");
        //     return Redirect("/gio-hang");
        // }

    }
}