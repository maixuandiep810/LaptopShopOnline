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
    public class FeedBackController : BaseController
    {



        public FeedBackController(ServiceWrapper serviceWrapper) : base(serviceWrapper)
        {
        }



        //// GET: Contact
        //[HttpGet]
        //public ActionResult ContactFromCustomer()
        //{
        //    if (Session[CommonConstants.USER_LOGIN_SESSION] != null)
        //    {
        //        return View();
        //    }
        //    else
        //    {
        //        SetAlert("Bạn cần đăng nhập để thực hiện", "warning");
        //        return Redirect("/dang-nhap");
        //    }
        //}
        //[HttpPost]
        //public ActionResult ContactFromCustomer(Feedback model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        model.Id = Guid.NewGuid();
        //        AuditTable.InsertAuditFields(model);
        //        _serviceWrapper.Db.Feedback.Add(model);
        //        _serviceWrapper.Db.SaveChanges();
        //        SetAlert("Cảm ơn bạn đã góp ý", "success");
        //        return Redirect("/phan-hoi-y-kien-khach-hang");
        //    }
        //    return View(model);
        //}
        //// Phan hoi y kien khach hang
        //public ActionResult ReplyFeedBack()
        //{
        //    var result = _serviceWrapper.Db.Feedback.Where(x => x.IsDeleted == false).OrderByDescending(x => x.CreatedOn).ToList();
        //    return View(result);
        //}
    }
}