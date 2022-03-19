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



        [HasCredential(RoleId = CommonConstants.BUYER_ROLE_READ_ID)]
        public ActionResult Index()
        {
            var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
            var carts = _serviceWrapper.Db.Cart.Include(x => x.Product).ThenInclude(x => x.Shop).Where(x => x.IsDeleted == false && x.BuyerId == userLoginSession.UserId).ToList();
            return View(carts);
        }



        [HasCredential(RoleId = CommonConstants.BUYER_ROLE_CREATE_ID)]
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




        [HasCredential(RoleId = CommonConstants.BUYER_ROLE_UPDATE_ID)]
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





        [HasCredential(RoleId = CommonConstants.BUYER_ROLE_DELETE_ID)]
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
                cartsCount = _serviceWrapper.Db.Cart.Where(x => x.BuyerId == userLoginSession.UserId && x.Product.ShopId == shopId).Count();
            }
            else
            {
                cartsCount = _serviceWrapper.Db.Cart.Where(x => x.BuyerId == userLoginSession.UserId && x.Id == cartId).Count();
            }
            if (cartsCount <= 0)
            {
                return PartialView("_Delete");
            }
            return PartialView();
        }
        //
        [HasCredential(RoleId = CommonConstants.BUYER_ROLE_DELETE_ID)]
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
    }
}