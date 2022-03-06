using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopShopOnline.WebApp.Areas.Admin.Models;
using LaptopShopOnline.Service;
using LaptopShopOnline.Common;
using LaptopShopOnline.WebApp.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.RegularExpressions;

namespace LaptopShopOnline.WebApp.Areas.Admin.Controllers
{
    public class LoginController : BaseController
    {



        public LoginController(ServiceWrapper serviceWrapper) : base(serviceWrapper)
        {
        }



        public ActionResult Login()
        {
            ViewBag.UserGroupIdPrefix = new SelectList(CommonConstants._USER_GROUP_ID_PREFIX_ADMIN_AREA_LIST, "Id");
            return View();
        }
        //
        [HttpPost]
        public ActionResult Login(AdminLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _serviceWrapper.UserService.Login(model.UserName, Encryptor.MD5Hash(model.Password), model.UserGroupIdPrefix);
                switch (result)
                {
                    case 1:
                        var user = _serviceWrapper.UserService.GetByName(model.UserName);
                        var userLoginSession = new UserLogin();
                        userLoginSession.UserId = user.Id;
                        userLoginSession.GroupId = user.UserGroup.Id;
                        userLoginSession.UserName = user.UserName;
                        userLoginSession.FirstName = user.FirstName;
                        userLoginSession.LastName = user.LastName;
                        userLoginSession.Email = user.Email;
                        userLoginSession.Address = user.Address;
                        if (Regex.IsMatch(user.UserGroupId, CommonConstants.USER_GROUP_ID_PREFIX_SELLER))
                            userLoginSession.ShopId = _serviceWrapper.Db.Shop.Where(p => p.SellerId == user.Id).First().Id;
                        //Phan quyen dua tren userLoginSession_credential
                        var listCredentials = _serviceWrapper.UserService.GetListCredential(model.UserName);
                        HttpContext.Session.Add(CommonConstants.CREDENTIALS_SESSION, listCredentials);
                        //Luu user info vao userLoginSession
                        HttpContext.Session.Add(CommonConstants.USER_LOGIN_SESSION, userLoginSession);
                        return Redirect(CommonConstants.ROUTE_QUAN_TRI_PARAMS);
                    case 0:
                        ModelState.AddModelError("", "Tài khoản không tồn tại");
                        break;
                    case -1:
                        ModelState.AddModelError("", "Tài khoản đang bị khóa");
                        break;
                    case -2:
                    case -3:
                        ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng.");
                        break;
                    default:
                        ModelState.AddModelError("", "Đăng nhập không đúng");
                        break;
                }
            }
            ViewBag.UserGroupIdPrefix = new SelectList(CommonConstants._USER_GROUP_ID_PREFIX_ADMIN_AREA_LIST, "Id");
            return View(model);
        }



        //  LogOut
        public ActionResult LogOut()
        {
            HttpContext.Session.Add<UserLogin>(CommonConstants.USER_LOGIN_SESSION, null);
            return Redirect(CommonConstants.ROUTE_QUAN_TRI_DANG_NHAP_PARAMS);
        }
    }
}
