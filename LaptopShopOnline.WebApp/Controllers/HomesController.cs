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


namespace LaptopShopOnline.WebApp.Controllers
{
    public class HomesController : BaseController
    {



        public HomesController(ServiceWrapper serviceWrapper) : base(serviceWrapper)
        {
        }



        // GET: Homes
        public ActionResult Index()
        {
            return View();
        }




        //Cancel payment - order for customer
        public ActionResult CancelOrder(Guid? id)
        {
            Order order = _serviceWrapper.Db.Order.Find(id);
            if (order.OrderStatus == true)
            {
                SetAlert("Đơn hàng đã được vận chuyển, bạn không thể hủy!", "warning");
            }
            else
            {
                order.IsDeleted = true;
                OrderDetail orderDetail = _serviceWrapper.Db.OrderDetail.FirstOrDefault(x => x.OrderId == order.Id);
                Product product = _serviceWrapper.Db.Product.FirstOrDefault(x => x.Id == orderDetail.ProductId);
                if (orderDetail != null)
                {
                    orderDetail.IsDeleted = true;
                }
                if (product != null)
                {
                    product.Quantity += orderDetail.Quantity;
                }
                _serviceWrapper.Db.SaveChanges();
                SetAlert("Bạn vừa hủy một đơn hàng", "warning");
            }
            return Redirect("/lich-su-mua-hang");
        }



        //Payment history
        public ActionResult HistoryPayment()
        {
            var session = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
            if (session != null)
            {
                return View(_serviceWrapper.Db.Order.Where(x => x.UserId == session.UserId && x.IsDeleted == false).ToList());
            }
            else
            {
                SetAlert("Bạn cần đăng nhập để thực hiện", "warning");
                return Redirect("/dang-nhap");
            }
        }
        public ActionResult HistoryPaymentDetail(Guid? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            OrderDetail orderDetail = new OrderDetail();
            Order order = _serviceWrapper.Db.Order.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(_serviceWrapper.Db.OrderDetail.Where(x => x.OrderId == order.Id).OrderByDescending(x => x.CreatedOn).ToList());
        }
        //Cancel order
        public ActionResult CancelOrderView()
        {
            var session = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
            if (session != null)
            {
                return View(_serviceWrapper.Db.Order.Where(x => x.UserId == session.UserId && x.IsDeleted == true).ToList());
            }
            else
            {
                SetAlert("Bạn cần đăng nhập để thực hiện", "warning");
                return Redirect("/dang-nhap");
            }
        }
        //Undo order
        public ActionResult UndoOrder(Guid? id)
        {
            Order order = _serviceWrapper.Db.Order.Find(id);
            order.IsDeleted = false;
            //Undo in order detail and Add turn quantity of product
            OrderDetail orderDetail = _serviceWrapper.Db.OrderDetail.FirstOrDefault(x => x.OrderId == order.Id);
            Product product = _serviceWrapper.Db.Product.FirstOrDefault(x => x.Id == orderDetail.ProductId);
            if (orderDetail != null)
            {
                orderDetail.IsDeleted = false;
            }
            if (product != null)
            {
                product.Quantity -= orderDetail.Quantity;
            }
            _serviceWrapper.Db.SaveChanges();
            SetAlert("Phục hồi đơn hàng thành công", "success");
            return Redirect("/lich-su-mua-hang");
        }
    }
}