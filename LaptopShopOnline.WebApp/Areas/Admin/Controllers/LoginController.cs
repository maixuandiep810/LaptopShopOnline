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

namespace LaptopShopOnline.WebApp.Areas.Admin.Controllers
{
    public class LoginController : BaseController
    {



        public LoginController(ServiceWrapper serviceWrapper) : base(serviceWrapper)
        {
        }



        public ActionResult Login()
        {
            return View();
        }
        //
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _serviceWrapper.UserService.Login(model.UserName, Encryptor.MD5Hash(model.Password), true);
                if (result == 1)
                {
                    var user = _serviceWrapper.UserService.GetByName(model.UserName);
                    var userLoginSession = new UserLogin();
                    userLoginSession.UserId = user.Id;
                    userLoginSession.GroupId = user.GroupId;
                    userLoginSession.UserName = user.UserName;
                    userLoginSession.FirstName = user.FirstName;
                    userLoginSession.LastName = user.LastName;
                    userLoginSession.Email = user.Email;
                    userLoginSession.Address = user.Address;
                    //Phan quyen dua tren userLoginSession_credential
                    var listCredentials = _serviceWrapper.UserService.GetListCredential(model.UserName);
                    HttpContext.Session.Add(CommonConstants.SESSION_CREDENTIALS, listCredentials);
                    //Luu user info vao userLoginSession
                    HttpContext.Session.Add(CommonConstants.USER_LOGIN_SESSION, userLoginSession);
                    return Redirect("/quan-tri/trang-chu");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khóa");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                }
                else if (result == -3)
                {
                    ModelState.AddModelError("", "Tài khoản không có quyền đăng nhập");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng");
                }
            }
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
