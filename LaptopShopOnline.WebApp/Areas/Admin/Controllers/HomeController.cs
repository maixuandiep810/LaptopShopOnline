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
    public class HomeController : BaseController
    {



        public HomeController(ServiceWrapper serviceWrapper) : base(serviceWrapper)
        {

        }





        // GET: Admin/Home
        public ActionResult Index()
        {
            CountMessage();
            CountOrder();
            CountProduct();
            ViewBag.CountUserGroup = _serviceWrapper.Db.UserGroup.Count();
            ViewBag.CountUser = _serviceWrapper.Db.User.Where(x => x.IsDeleted == false).Count();
            ViewBag.CountRole = _serviceWrapper.Db.Role.Count();
            ViewBag.CountCredential = _serviceWrapper.Db.Credentials.Count();
            ViewBag.CountProduct = _serviceWrapper.Db.Product.Where(x => x.IsDeleted == false).Count();
            ViewBag.CountProductCategory = _serviceWrapper.Db.ProductCategory.Where(x => x.IsDeleted == false).Count();
            ViewBag.CountNews = _serviceWrapper.Db.News.Where(x => x.IsDeleted == false).Count();
            ViewBag.CountNewsCategory = _serviceWrapper.Db.NewsCategory.Where(x => x.IsDeleted == false).Count();
            ViewBag.CountMenu = _serviceWrapper.Db.Menu.Where(x => x.IsDeleted == false && x.ParentId == null).Count();
            ViewBag.CountOrder = _serviceWrapper.Db.Order.Where(x => x.IsDeleted == false).Count();
            ViewBag.Reven = _serviceWrapper.Db.OrderDetail.Where(x => x.IsDeleted == false).Sum(i => i.Price * i.Quantity);
            //tong tien ban
            //var sumPrice = _serviceWrapper.Db.OrderDetail.Where(x => x.IsDeleted == false).Sum(i => i.Price * i.Quantity);
            var result = from o in _serviceWrapper.Db.OrderDetail
                         join p in _serviceWrapper.Db.Product on o.ProductId equals p.Id
                         where o.IsDeleted == false
                         select new
                         {
                             Code = p.Code,
                             Price = o.Price,
                             Quantity = o.Quantity,
                             ProductId = p.Id
                         };
            var sumPrice = result.Sum(x => x.Quantity * x.Price);
            var sum = result.Sum(x => x.Quantity * x.Price);
            ViewBag.Benefit = sumPrice - sum;
            return View();
        }

        //public ActionResult ExportToExcel()
        //{
        //    var ExcelData = (from od in _serviceWrapper.Db.OrderDetail
        //                     join o in _serviceWrapper.Db.Order
        //                     on od.OrderId equals o.Id
        //                     join u in _serviceWrapper.Db.User
        //                     on o.UserId equals u.Id
        //                     join p in _serviceWrapper.Db.Product
        //                     on od.ProductId equals p.Id
        //                     select new ExcelModel
        //                     {
        //                         Customer = u.FirstName + u.LastName,
        //                         Email = u.Email,
        //                         Phone = o.ShipPhone,
        //                         ProductName = p.Name,
        //                         CreatedOn = o.CreatedOn.Value,
        //                         Price = od.Price.Value,
        //                         Quantity = od.Quantity.Value,
        //                         Total = od.Price.Value * od.Quantity.Value
        //                     }).ToList();
        //    var orderDetail = _serviceWrapper.Db.OrderDetail.Where(x => !x.IsDeleted).ToList();
        //    var gv = new GridView();
        //    gv.DataSource = ExcelData;
        //    gv.DataBind();
        //    Response.ClearContent();
        //    Response.Buffer = true;
        //    Response.AddHeader("content-disposition", "attachment; filename=DemoExcel.xls");
        //    Response.ContentType = "application/ms-excel";
        //    Response.Charset = "";
        //    StringWriter objStringWriter = new StringWriter();
        //    HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
        //    gv.RenderControl(objHtmlTextWriter);
        //    Response.Output.Write(objStringWriter.ToString());
        //    Response.Flush();
        //    Response.End();
        //    return View();
        //}



        //public JsonResult Chart(int year)
        //{
        //    List<decimal> price = new List<decimal>();
        //    List<decimal> stock = new List<decimal>();
        //    Dictionary<string, List<decimal>> result = new Dictionary<string, List<decimal>>();

        //    for (int month = 1; month <= 12; month++)
        //    {
        //        var priceByMonth = _serviceWrapper.Db.OrderDetail
        //            .Where(x => !x.IsDeleted && x.CreatedOn.Value.Month == month && x.CreatedOn.Value.Year == year)
        //            .Sum(x => x.Quantity * x.Price);

        //        price.Add(priceByMonth == null ? 0 : priceByMonth.Value);
        //        var stockByMonth = (from o in _serviceWrapper.Db.OrderDetail
        //                            join p in _serviceWrapper.Db.Product
        //                            on o.ProductId equals p.Id
        //                            where o.IsDeleted == false && o.CreatedOn.Value.Year == year && o.CreatedOn.Value.Month == month
        //                            select new
        //                            {
        //                                Quantity = o.Quantity,
        //                                Stock = p.Code
        //                            }).Sum(x => x.Quantity * x.Stock);
        //        stock.Add(stockByMonth == null ? 0 : stockByMonth.Value);
        //    }
        //    result.Add("price", price);
        //    result.Add("stock", stock);
        //    return Json(new { data = result },
        //        JsonRequestBehavior.AllowGet);
        //}
    }

}