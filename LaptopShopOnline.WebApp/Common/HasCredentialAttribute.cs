using LaptopShopOnline.Common;
using LaptopShopOnline.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LaptopShopOnline.WebApp.Common
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class HasCredentialAttribute : Attribute, IAuthorizationFilter
    {



        public string RoleId { get; set; }



        //public HasCredentialAttribute(string roleId)
        //{
        //    RoleId = roleId;
        //}



        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            var userLoginSession = filterContext.HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
            var isAjaxRequest = filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
            var viewResult401 = new ViewResult
            {
                ViewName = "~/Areas/Admin/Views/Shared/_Error401.cshtml"
            };
            var jsonResult401 = new JsonResult(new JsonResultData<bool>{ Message = "Bạn không có quyền thực hiện hành động này." }) { StatusCode = (int)HttpStatusCode.Unauthorized };
            if (userLoginSession == null)
            {
                filterContext.Result = isAjaxRequest == true ? jsonResult401 : viewResult401;
                return;
            }

            List<string> privilegeLevels = this.GetCredentialByLoggedInUser(filterContext, userLoginSession.UserName); // Call another method to get rights of the user from DB

            if (privilegeLevels == null || privilegeLevels.Contains(RoleId) == false)
            {
                filterContext.Result = isAjaxRequest == true ? jsonResult401 : viewResult401;
                return;
            }
            return;

        }



        private List<string> GetCredentialByLoggedInUser(AuthorizationFilterContext filterContext, string userName)
        {
            var credentialsSession = filterContext.HttpContext.Session.Get<List<string>>(CommonConstants.CREDENTIALS_SESSION);
            return credentialsSession;
        }
    }
}
