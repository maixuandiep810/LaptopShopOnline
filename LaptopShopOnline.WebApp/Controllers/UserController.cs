﻿using LaptopShopOnline.Common;
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
                        return Redirect("/");
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
        //[CaptchaValidationActionFilter("CaptchaCode", "ExampleCaptcha", "Mã CAPTCHA không đúng!")]/**/
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (_serviceWrapper.UserService.CheckUserName(model.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại trong hệ thống");
                }
                else if (_serviceWrapper.UserService.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại trong hệ thống");
                }
                else
                {
                    var user = new User();
                    user.Id = Guid.NewGuid();
                    user.UserName = model.UserName;
                    user.Password = Encryptor.MD5Hash(model.Password);
                    user.ConfirmPassword = Encryptor.MD5Hash(model.ConfirmPassword);
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Email = model.Email;
                    //user.GroupId = "MEMBER";
                    user.Address = model.Address;
                    user.IsDeleted = false;
                    user.CreatedOn = DateTime.Now;
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
                    return Redirect("/");
                }
            }
            else
            {
                SetAlert("Đăng ký không thành công", "warning");
                //MvcCaptcha.ResetCaptcha("ExampleCaptcha");
            }
            return View(model);
        }



        [HasCredential(RoleId = "BUYER_ROLE")]
        public ActionResult Logout()
        {
            Object nullUserLogin = null;
            HttpContext.Session.Add(CommonConstants.USER_LOGIN_SESSION, nullUserLogin);
            return RedirectToAction("Index", "Homes");
        }




        ////Reset password function
        //[NonAction]
        //public void SendVerificationLinkEmail(string emailID, string activationCode, string emailFor = "VerifyAccount")
        //{
        //    var verifyUrl = "/User/" + emailFor + "/" + activationCode;
        //    var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

        //    var fromEmail = new MailAddress("nghia38511@donga.edu.vn", "FreeStyle Shoe Security");
        //    var toEmail = new MailAddress(emailID);
        //    var fromEmailPassword = "nghiakia2510"; // Replace with actual password

        //    string subject = "";
        //    string body = "";
        //    if (emailFor == "VerifyAccount")
        //    {
        //        subject = "Your account is successfully created!";
        //        body = "<br/><br/>We are excited to tell you that your Dotnet Awesome account is" +
        //            " successfully created. Please click on the below link to verify your account" +
        //            " <br/><br/><a href='" + link + "'>" + link + "</a> ";
        //    }
        //    else if (emailFor == "ResetPassword")
        //    {
        //        subject = "Đặt lại mật khẩu";
        //        body = "Chào bạn, Chúng tôi nhận được yêu cầu đặt lại mật khẩu tài khoản của bạn. Vui lòng nhấp vào liên kết dưới đây để thiết lập lại mật khẩu của bạn" +
        //            "<br/><br/><a href=" + link + ">Click vào đây để đặt lại mật khẩu</a>";
        //    }


        //    var smtp = new SmtpClient
        //    {
        //        Host = "smtp.gmail.com",
        //        Port = 587,
        //        EnableSsl = true,
        //        DeliveryMethod = SmtpDeliveryMethod.Network,
        //        UseDefaultCredentials = false,
        //        Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
        //    };

        //    using (var message = new MailMessage(fromEmail, toEmail)
        //    {
        //        Subject = subject,
        //        Body = body,
        //        IsBodyHtml = true
        //    })
        //        smtp.Send(message);
        //}
        //[HttpGet]
        //public ActionResult ForgotPassword()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult ForgotPassword(string EmailID)
        //{
        //    //Verify Email ID
        //    //Generate Reset password link 
        //    //Send Email 
        //    string message = "";
        //    //bool status = false;

        //    var account = _serviceWrapper.Db.User.Where(a => a.Email == EmailID).FirstOrDefault();
        //    if (account != null)
        //    {
        //        //Send email for reset password
        //        string resetCode = Guid.NewGuid().ToString();
        //        SendVerificationLinkEmail(account.Email, resetCode, "ResetPassword");
        //        account.ResetPasswordCode = resetCode;
        //        //This line I have added here to avoid confirm password not match issue , as we had added a confirm password property 
        //        //in our model class in part 1
        //        _serviceWrapper.Db.Configuration.ValidateOnSaveEnabled = false;
        //        _serviceWrapper.Db.SaveChanges();
        //        message = "Một liên kết đã được gửi đến Email của bạn. Vui lòng kiểm tra Email để thực hiện đặt lại mật khẩu";
        //    }
        //    else
        //    {
        //        message = "Email không tồn tại trong hệ thống. Vui lòng liên hệ tổng đài 1900.89.89.89 để biết thêm chi tiết.";
        //    }
        //    ViewBag.Message = message;
        //    return View();
        //}

        //public ActionResult ResetPassword(string id)
        //{
        //    //Verify the reset password link
        //    //Find account associated with this link
        //    //redirect to reset password page
        //    if (string.IsNullOrWhiteSpace(id))
        //    {
        //        return HttpNotFound();
        //    }

        //    var user = _serviceWrapper.Db.User.Where(a => a.ResetPasswordCode == id).FirstOrDefault();
        //    if (user != null)
        //    {
        //        ResetPasswordModel model = new ResetPasswordModel();
        //        model.ResetCode = id;
        //        return View(model);
        //    }
        //    else
        //    {
        //        return HttpNotFound();
        //    }
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult ResetPassword(ResetPasswordModel model)
        //{
        //    var message = "";
        //    if (ModelState.IsValid)
        //    {
        //        var user = _serviceWrapper.Db.User.Where(a => a.ResetPasswordCode == model.ResetCode).FirstOrDefault();
        //        if (user != null)
        //        {
        //            user.Password = Encryptor.MD5Hash(model.NewPassword);
        //            user.ConfirmPassword = Encryptor.MD5Hash(model.ConfirmPassword);
        //            user.ResetPasswordCode = null;
        //            _serviceWrapper.Db.Configuration.ValidateOnSaveEnabled = false;
        //            _serviceWrapper.Db.SaveChanges();
        //            SetAlert("Mật khẩu mới đã được thiết lập thành công", "success");
        //            return Redirect("/dang-nhap");
        //        }
        //    }
        //    else
        //    {
        //        message = "Không thành công. Vui lòng kiểm tra lại";
        //    }
        //    ViewBag.Message = message;
        //    return View(model);
        //}

        //login facebook
        //private Uri RedirectUri
        //{
        //    get
        //    {
        //        var uriBuilder = new UriBuilder(Request.Url);
        //        uriBuilder.Query = null;
        //        uriBuilder.Fragment = null;
        //        uriBuilder.Path = Url.Action("FacebookCallback");
        //        return uriBuilder.Uri;
        //    }
        //}
        //public ActionResult LoginFacebook()
        //{
        //    var fb = new FacebookClient();
        //    var loginUrl = fb.GetLoginUrl(new
        //    {
        //        client_id = ConfigurationManager.AppSettings["FbAppId"],
        //        client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
        //        redirect_uri = RedirectUri.AbsoluteUri,
        //        response_type = "code",
        //        scope = "email",
        //    });

        //    return Redirect(loginUrl.AbsoluteUri);
        //}
        //public ActionResult FacebookCallback(string code)
        //{
        //    var fb = new FacebookClient();
        //    dynamic result = fb.Post("oauth/access_token", new
        //    {
        //        client_id = ConfigurationManager.AppSettings["FbAppId"],
        //        client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
        //        redirect_uri = RedirectUri.AbsoluteUri,
        //        code = code
        //    });

        //    var accessToken = result.access_token;
        //    if (!string.IsNullOrEmpty(accessToken))
        //    {
        //        fb.AccessToken = accessToken;

        //        // Get the user's information, like email, first name, middle name etc
        //        dynamic me = fb.Get("me?fields=first_name,middle_name,last_name,id,email,address");
        //        string email = me.email;
        //        string userName = me.email;
        //        string firstname = me.first_name;
        //        string middlename = me.middle_name;
        //        string lastname = me.last_name;
        //        string address = me.address;

        //        var user = new User();
        //        user.Email = email;
        //        user.UserName = userName;
        //        user.FirstName = firstname + ' ' + middlename;
        //        user.LastName = lastname;
        //        user.IsDeleted = false;
        //        user.Address = address;
        //        user.CreatedOn = DateTime.Now;
        //        user.GroupId = "MEMBER";
        //        user.Password = DateTime.Now + user.UserName;
        //        user.ConfirmPassword = user.Password;

        //        var resultInsert = new UserDao().InsertForFacebook(user);
        //        if (resultInsert != null)
        //        {
        //            var userSession = new UserLogin();
        //            userSession.UserName = user.UserName;
        //            userSession.UserId = user.Id;
        //            userSession.FirstName = user.FirstName;
        //            userSession.LastName = user.LastName;
        //            Session.Add(CommonConstants.USER_LOGIN_SESSION, userSession);
        //        }
        //    }
        //    return Redirect("/");
        //}




        //Ho so nguoi dung
        public ActionResult EditProfile(Guid? id)
        {
            var session = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
            if (session == null)
            {
                return Redirect("/trang-chu");
            }
            else
            {
                if (id == null)
                {
                    return BadRequest();
                }
                User user = _serviceWrapper.Db.User.Find(id);
                if (user == null)
                {
                    return NotFound();
                }
                return View(user);
            }
        }
        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile(User user)
        {
            var session = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
            if (ModelState.IsValid)
            {
                AuditTable.UpdateAuditFields(user, session.UserName);
                user.Password = Encryptor.MD5Hash(user.Password);
                user.ConfirmPassword = Encryptor.MD5Hash(user.ConfirmPassword);
                _serviceWrapper.Db.Entry(user).State = EntityState.Modified;
                _serviceWrapper.Db.SaveChanges();
                SetAlert("Cập nhật thành công", "success");
                return Redirect("/trang-chu");
            }
            return View(user);
        }
    }
}