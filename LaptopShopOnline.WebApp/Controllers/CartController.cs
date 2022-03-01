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
    public class CartController : BaseController
    {



        public CartController(ServiceWrapper serviceWrapper) : base(serviceWrapper)
        {
        }



        // GET: Cart
        public ActionResult Index()
        {
            var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
            var carts = _serviceWrapper.Db.Cart.Include(x => x.Product).ThenInclude(x => x.Shop).Where(x => x.BuyerId == userLoginSession.UserId).ToList();
            return View(carts); 
        }



        public ActionResult Create(Guid? productId, int quantity)
        {
            var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
            if (userLoginSession != null)
            {
                var product = _serviceWrapper.Db.Product.Find(productId);
                var carts = _serviceWrapper.Db.Cart.Where(x => x.BuyerId == userLoginSession.UserId && x.ProductId == product.Id).FirstOrDefault();
                if (carts != null)
                {
                    carts.Quantity += quantity;
                    _serviceWrapper.Db.SaveChanges();
                }
                else
                {
                    var newCart = new Cart
                    {
                        BuyerId = userLoginSession.UserId,
                        ProductId = product.Id,
                        Quantity = quantity
                    };
                    _serviceWrapper.Db.Cart.Add(newCart);
                    _serviceWrapper.Db.SaveChanges();
                }

                SetAlert("Thêm vào giỏ thành công", "success");
                return Redirect(Request.Headers["Referer"].ToString());
            }
            else
            {
                SetAlert("Bạn phải đăng nhập để có thể mua hàng", "warning");
                return Redirect("/dang-nhap");
            }
        }

        [HttpPost]
        public ActionResult Edit(Cart cart)
        {
            if (ModelState.IsValid)
            {
                var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
                _serviceWrapper.Db.Entry(cart).State = EntityState.Modified;
                _serviceWrapper.Db.SaveChanges();
                SetAlert("Cập nhật thành công", "success");
                return Redirect("/gio-hang");
            }
            return Redirect("/gio-hang");
        }



        public ActionResult Delete(Guid? id) {
            var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
            if (id == null)
            {
                _serviceWrapper.Db.Cart.RemoveRange(_serviceWrapper.Db.Cart.Where(x => x.BuyerId == userLoginSession.UserId));
                _serviceWrapper.Db.SaveChanges();
                return Redirect("/gio-hang");
            }
            _serviceWrapper.Db.Cart.Remove(_serviceWrapper.Db.Cart.Find(id));
            return Redirect("/gio-hang");
        }





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
        //         content = content.Replace("{{Total}}", total.ToString("N0"));
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