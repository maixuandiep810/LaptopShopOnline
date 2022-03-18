using LaptopShopOnline.Common;
using LaptopShopOnline.Model.Entities;
using LaptopShopOnline.Service;
using LaptopShopOnline.WebApp.Common;
using LaptopShopOnline.WebApp.Models;
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
    public class UserController : BaseController
    {



        public UserController(ServiceWrapper serviceWrapper) : base(serviceWrapper)
        {
        }




        //// GET: Users
        //public ActionResult Login(string message = null, string type = null)
        //{
        //    if (message != null && type != null)
        //    {
        //        SetAlert(message, type);
        //    }
        //    return View();
        //}
        // GET: Users
        public ActionResult Login()
        {
            return View();
        }
        //
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _serviceWrapper.UserService.Login(model.UserName, Encryptor.MD5Hash(model.Password), CommonConstants.USER_GROUP_ID_PREFIX_BUYER);
                switch (result)
                {
                    case 1:
                        var user = _serviceWrapper.UserService.GetByName(model.UserName);
                        var userSession = new UserLogin();
                        userSession.UserName = user.UserName;
                        userSession.UserId = user.Id;
                        userSession.Email = user.Email;
                        userSession.Address = user.Address;
                        userSession.FirstName = user.FirstName;
                        userSession.LastName = user.LastName;
                        HttpContext.Session.Add(CommonConstants.USER_LOGIN_SESSION, userSession);
                        return Redirect(CommonConstants.ROUTE_TRANG_CHU_PARAMS);
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
            return View(model);
        }




        // Register New Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (_serviceWrapper.UserService.CheckUserName(model.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại trong hệ thống");
                    SetAlert("Đăng ký không thành công", "warning");
                    return View(model);
                }
                if (_serviceWrapper.UserService.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại trong hệ thống");
                    SetAlert("Đăng ký không thành công", "warning");
                    return View(model);
                }

                var user = new User();
                user.Id = Guid.NewGuid();
                user.UserName = model.UserName;
                user.Password = Encryptor.MD5Hash(model.Password);
                user.Email = model.Email;
                user.IsDeleted = false;
                user.CreatedOn = DateTime.Now;
                user.UserGroupId = CommonConstants.USER_GROUP_ID_BUYER_DEFAULT;
                //Save
                _serviceWrapper.Db.User.Add(user);
                _serviceWrapper.Db.SaveChanges();
                SetAlert("Đăng ký thành công", "success");

                //Login
                var userSession = new UserLogin();
                userSession.UserName = user.UserName;
                userSession.UserId = user.Id;
                userSession.Email = user.Email;
                userSession.Address = user.Address;
                userSession.FirstName = user.FirstName;
                userSession.LastName = user.LastName;
                HttpContext.Session.Add(CommonConstants.USER_LOGIN_SESSION, userSession);
                return Redirect(CommonConstants.ROUTE_TRANG_CHU_PARAMS);
            }
            SetAlert("Đăng ký không thành công", "warning");
            return View(model);
        }



        /*        [HasCredential(RoleId = "BUYER_ROLE")]*/
        public ActionResult Logout()
        {
            Object nullUserLogin = null;
            HttpContext.Session.Add(CommonConstants.USER_LOGIN_SESSION, nullUserLogin);
            return Redirect(CommonConstants.ROUTE_TRANG_CHU_PARAMS);
        }



        public ActionResult EditProfile()
        {
            var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
            User user = _serviceWrapper.Db.User.Where(x => x.Id == userLoginSession.UserId).FirstOrDefault();
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile(User user)
        {
            var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
            if (ModelState.IsValid)
            {
                AuditTable.UpdateAuditFields(user, userLoginSession.UserName);
                _serviceWrapper.Db.Entry(user).State = EntityState.Modified;
                _serviceWrapper.Db.SaveChanges();
                SetAlert("Cập nhật thành công", "success");
                return Redirect(CommonConstants.ROUTE_TRANG_CHU_PARAMS);
            }
            return View(user);
        }



        public ActionResult EditPassword()
        {
            var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
            User user = _serviceWrapper.Db.User.Where(x => x.Id == userLoginSession.UserId).FirstOrDefault();
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPassword(User user)
        {
            var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
            if (ModelState.IsValid)
            {
                AuditTable.UpdateAuditFields(user, userLoginSession.UserName);
                user.Password = Encryptor.MD5Hash(user.Password);
                _serviceWrapper.Db.Entry(user).State = EntityState.Modified;
                _serviceWrapper.Db.SaveChanges();
                SetAlert("Cập nhật thành công", "success");
                return Redirect(CommonConstants.ROUTE_TRANG_CHU_PARAMS);
            }
            return View(user);
        }
    }
}