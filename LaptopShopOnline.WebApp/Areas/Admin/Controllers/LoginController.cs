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

namespace LaptopShopOnline.WebApp.Areas.Admin.Controllers
{
    public class LoginController : BaseController
    {



        public LoginController(ServiceWrapper serviceWrapper) : base(serviceWrapper)
        {
        }



        public ActionResult Login()
        {
            ViewBag.UserGroupId = new SelectList(CommonConstants.ADMIN_AREA_GROUP_ID, "Id");
            return View();
        }
        //
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _serviceWrapper.UserService.Login(model.UserName, Encryptor.MD5Hash(model.Password), model.UserGroupId);
                switch (result)
                {
                    case 1:
                        var user = _serviceWrapper.UserService.GetByName(model.UserName);
                        var userLoginSession = new UserLogin();
                        userLoginSession.UserId = user.Id;
                        userLoginSession.GroupId = model.UserGroupId;
                        userLoginSession.UserName = user.UserName;
                        userLoginSession.FirstName = user.FirstName;
                        userLoginSession.LastName = user.LastName;
                        userLoginSession.Email = user.Email;
                        userLoginSession.Address = user.Address;
                        if (model.UserGroupId == CommonConstants.SELLER_GROUP)
                            userLoginSession.ShopId = _serviceWrapper.Db.Shop.Where(p => p.SellerId == user.Id).First().Id;
                        //Phan quyen dua tren userLoginSession_credential
                        var listCredentials = _serviceWrapper.UserService.GetListCredential(model.UserName);
                        HttpContext.Session.Add(CommonConstants.CREDENTIALS_SESSION, listCredentials);
                        //Luu user info vao userLoginSession
                        HttpContext.Session.Add(CommonConstants.USER_LOGIN_SESSION, userLoginSession);
                        return Redirect("/quan-tri/trang-chu");
                    case 0:
                        ModelState.AddModelError("", "Tài khoản không tồn tại");
                        break;
                    case -1:
                        ModelState.AddModelError("", "Tài khoản đang bị khóa");
                        break;
                    case -2:
                        ModelState.AddModelError("", "Mật khẩu không đúng");
                        break;
                    case -3:
                        ModelState.AddModelError("", "Tài khoản không có quyền đăng nhập");
                        break;
                    default:
                        ModelState.AddModelError("", "Đăng nhập không đúng");
                        break;
                }
            }
            ViewBag.UserGroupId = new SelectList(CommonConstants.ADMIN_AREA_GROUP_ID, "Id");
            return View(model);
        }



        //  LogOut
        public ActionResult LogOut()
        {
            HttpContext.Session.Add<UserLogin>(CommonConstants.USER_LOGIN_SESSION, null);
            return Redirect("/quan-tri/dang-nhap");
        }
    }
}
