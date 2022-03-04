using LaptopShopOnline.Common;
using LaptopShopOnline.Service;
using LaptopShopOnline.WebApp.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopShopOnline.WebApp.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {



        protected readonly ServiceWrapper _serviceWrapper;
        protected UserLogin _userLoginSession;



        public BaseController(ServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }


        //
        //      Chỉ có MANAGER && SELLER
        //
/*        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
            if (filterContext.HttpContext.Request.Path.Value != CommonConstants.ROUTE_ADMIN_DANG_NHAP && 
                    (_userLoginSession == null || _userLoginSession.GroupId != CommonConstants.ADMIN_GROUP 
                    && _userLoginSession.GroupId != CommonConstants.MOD_GROUP
                    && _userLoginSession.GroupId != CommonConstants.SELLER_GROUP))
            {
                filterContext.Result = Redirect("/dang-nhap");
            }
            base.OnActionExecuting(filterContext);
        }*/



        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            switch (type)
            {
                case "success":
                    TempData["AlertType"] = "alert-success";
                    break;
                case "warning":
                    TempData["AlertType"] = "alert-warning";
                    break;
                case "danger":
                    TempData["AlertType"] = "alert-danger";
                    break;
                default:
                    break;
            }
        }




        protected void CountMessage()
        {
            //var feedbacks = _serviceWrapper.Db.Feedback.Where(x => x.IsDeleted == false && x.Reply == null);
            //TempData["cms"] = feedbacks.Count().ToString();
        }
        protected void CountProduct()
        {
            var products = _serviceWrapper.Db.Product.Where(x => x.IsDeleted == false && x.Quantity < 5);
            TempData["cpd"] = products.Count().ToString();
        }
        protected void CountOrder()
        {
            //var orders = _serviceWrapper.Db.Order.Where(x => x.Status == false && x.IsDeleted == false);
            //TempData["ord"] = orders.Count().ToString();
        }
    }
}