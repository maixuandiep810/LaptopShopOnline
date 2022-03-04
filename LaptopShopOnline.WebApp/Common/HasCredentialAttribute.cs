using LaptopShopOnline.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
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
            if (userLoginSession == null)
            {
                filterContext.Result = new ViewResult
                {
                    ViewName = "~/Areas/Admin/Views/Shared/_Error401.cshtml"
                };
                return;
            }

            List<string> privilegeLevels = this.GetCredentialByLoggedInUser(filterContext, userLoginSession.UserName); // Call another method to get rights of the user from DB

            if (privilegeLevels.Contains(RoleId))
            {
                return;
            }   
            else
            {
                filterContext.Result = new ViewResult
                {
                    ViewName = "~/Areas/Admin/Views/Shared/_Error401.cshtml"
                };
                return;
            }
        }



        private List<string> GetCredentialByLoggedInUser(AuthorizationFilterContext filterContext, string userName)
        {
            var credentialsSession = filterContext.HttpContext.Session.Get<List<string>>(CommonConstants.CREDENTIALS_SESSION);
            return credentialsSession;
        }
    }
}
