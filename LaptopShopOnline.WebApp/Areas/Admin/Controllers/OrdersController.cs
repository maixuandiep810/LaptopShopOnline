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
        public ActionResult Index(string sortOrder, int? page, string searchString, string currentFilter)
        {
            CountMessage();
            CountProduct();
            CountOrder();
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CreatedOnSortParm = sortOrder == "CreatedOn" ? "createdOn_desc" : "CreatedOn";
            var orders = _serviceWrapper.Db.Order.Where(x => x.IsDeleted == false);

            //Filter
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
                orders = orders.Where(s => s.ShipName.Contains(searchString) || s.ShipPhone.Contains(searchString) || s.ShipEmail.Contains(searchString) || s.ShipAddress.Contains(searchString));
            }
            //Sort
            switch (sortOrder)
            {
                case "name_desc":
                    orders = orders.OrderByDescending(s => s.ShipName);
                    break;
                case "CreatedOn":
                    orders = orders.OrderBy(s => s.CreatedOn);
                    break;
                case "createdOn_desc":
                    orders = orders.OrderByDescending(s => s.CreatedOn);
                    break;
                default:
                    orders = orders.OrderBy(s => s.ShipName);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.SearchString = searchString;
            return View(orders.ToPagedList(pageNumber, pageSize));
        }



        //Cancelled order
        public ActionResult CancelOrder(string sortOrder, int? page, string searchString, string currentFilter)
        {
            CountMessage();
            CountProduct();
            CountOrder();
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CreatedOnSortParm = sortOrder == "CreatedOn" ? "createdOn_desc" : "CreatedOn";
            var orders = _serviceWrapper.Db.Order.Where(x => x.IsDeleted == true);

            //Filter
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
                orders = orders.Where(s => s.ShipName.Contains(searchString) || s.ShipPhone.Contains(searchString) || s.ShipEmail.Contains(searchString) || s.ShipAddress.Contains(searchString));
            }
            //Sort
            switch (sortOrder)
            {
                case "name_desc":
                    orders = orders.OrderByDescending(s => s.ShipName);
                    break;
                case "CreatedOn":
                    orders = orders.OrderBy(s => s.CreatedOn);
                    break;
                case "createdOn_desc":
                    orders = orders.OrderByDescending(s => s.CreatedOn);
                    break;
                default:
                    orders = orders.OrderBy(s => s.ShipName);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.SearchString = searchString;
            return View(orders.OrderByDescending(x => x.CreatedOn).ToPagedList(pageNumber, pageSize));
        }





        // GET: Admin/Orders/Details/5
        public ActionResult Details(Guid? id)
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
            return View(_serviceWrapper.Db.OrderDetail.Where(x => x.OrderId == order.Id).ToList());
        }





        // GET: Admin/Orders/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Order order = _serviceWrapper.Db.Order.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }





        // POST: Admin/Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Order order = _serviceWrapper.Db.Order.Find(id);
            order.IsDeleted = true;
            //Delete in order detail and Add turn quantity of product
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
            SetAlert("Xóa thành công", "success");
            return Redirect("/quan-tri/don-dat-hang");
        }



        //Undo order
        public ActionResult UndoOrder(Guid? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Order order = _serviceWrapper.Db.Order.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }


        //
        [HttpPost, ActionName("UndoOrder")]
        [ValidateAntiForgeryToken]
        public ActionResult UndoOrderConfirmed(Guid? id)
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
            return Redirect("/quan-tri/don-dat-hang-da-huy");
        }



        //Change status order
        public JsonResult ChangeStatus(Guid? id)
        {
            var result = _serviceWrapper.OrderService.ChangeOrderStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}
