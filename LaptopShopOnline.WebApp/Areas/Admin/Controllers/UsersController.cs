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
    public class UsersController : BaseController
    {



        public UsersController(ServiceWrapper serviceWrapper) : base(serviceWrapper)
        {

        }





        // GET: Admin/Users
        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_AUTH_VIEW_ID)]
        public ActionResult Index(int? page)
        {
            CountMessage();
            CountProduct();
            CountOrder();
            var user = _serviceWrapper.Db.User.Where(u => u.IsDeleted == false).Include(u => u.UserGroup).Select(p => p);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(user.ToPagedList(pageNumber, pageSize));
        }





        // GET: Admin/Users/Details/5
        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_AUTH_VIEW_ID)]
        public ActionResult Details(Guid? id)
        {
            CountMessage();
            CountProduct();
            CountOrder();
            if (id == null)
            {
                return BadRequest();
            }
            User user = _serviceWrapper.Db.User.Where(u => u.IsDeleted == false && u.Id == id).Include(u => u.UserGroup).Select(p => p).FirstOrDefault();
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }





        // GET: Admin/Users/Create
        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_AUTH_CREATE_ID)]
        public ActionResult Create()
        {
            CountMessage();
            CountProduct();
            CountOrder();
            ViewBag.GroupId = new SelectList(_serviceWrapper.Db.UserGroup, "Id", "Name");
            return View();
        }
        // POST: Admin/Users/Create
        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_AUTH_CREATE_ID)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                if (_serviceWrapper.UserService.CheckEmail(user.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại trong hệ thống");
                }
                else if (_serviceWrapper.UserService.CheckUserName(user.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại trong hệ thống");
                }
                else
                {
                    user.Id = Guid.NewGuid();
                    AuditTable.InsertAuditFields(user, _userLoginSession?.UserName);
                    user.Password = Encryptor.MD5Hash(user.Password);
                    _serviceWrapper.Db.User.Add(user);
                    _serviceWrapper.Db.SaveChanges();
                    SetAlert("Thêm mới thành công", "success");
                    return Redirect(CommonConstants.ROUTE_QUAN_TRI_TAI_KHOAN_NGUOI_DUNG_PARAMS);
                }
            }
            ViewBag.GroupId = new SelectList(_serviceWrapper.Db.UserGroup, "Id", "Name", user.GroupId);
            return View(user);
        }





        // GET: Admin/Users/Edit/5
        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_AUTH_UPDATE_ID)]
        public ActionResult Edit(Guid? id)
        {
            CountMessage();
            CountProduct();
            CountOrder();
            if (id == null)
            {
                return BadRequest();
            }
            User user = _serviceWrapper.Db.User.Where(u => u.IsDeleted == false && u.Id == id).Include(u => u.UserGroup).Select(p => p).FirstOrDefault();
            if (user == null)
            {
                return NotFound();
            }
            ViewBag.GroupId = new SelectList(_serviceWrapper.Db.UserGroup, "Id", "Name", user.GroupId);
            return View(user);
        }
        // POST: Admin/Users/Edit/5
        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_AUTH_UPDATE_ID)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            CountMessage();
            CountProduct();
            CountOrder();
            if (ModelState.IsValid)
            {
                User oldUser = _serviceWrapper.Db.User.Where(u => u.IsDeleted == false && u.Id == user.Id).Include(u => u.UserGroup).Select(p => p).FirstOrDefault();
                if (user == null)
                {
                    return NotFound();
                }
                AuditTable.UpdateAuditFields(user, _userLoginSession?.UserName);
                _serviceWrapper.Db.Entry(user).State = EntityState.Modified;
                _serviceWrapper.Db.SaveChanges();
                SetAlert("Cập nhật thành công", "success");
                return Redirect(CommonConstants.ROUTE_QUAN_TRI_TAI_KHOAN_NGUOI_DUNG_PARAMS);
            }
            ViewBag.GroupId = new SelectList(_serviceWrapper.Db.UserGroup, "Id", "Name", user.GroupId);
            return View(user);
        }




















        // GET: Admin/Users/Delete/5
        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_AUTH_DELETE_ID)]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return PartialView("_Delete");
            }
            User user = _serviceWrapper.Db.User.Where(u => u.IsDeleted == false && u.Id == id).Include(u => u.UserGroup).Select(p => p).FirstOrDefault();
            if (user == null)
            {
                return PartialView("_Delete");
            }
            return PartialView();
        }
        // POST: Admin/Users/Delete/5
        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_AUTH_DELETE_ID)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            User user = _serviceWrapper.Db.User.Where(u => u.IsDeleted == false && u.Id == id).Include(u => u.UserGroup).Select(p => p).FirstOrDefault();
            if (user == null)
            {
                return NotFound();
            }
            user.IsDeleted = true;
            _serviceWrapper.Db.SaveChanges();
            return Redirect(CommonConstants.ROUTE_QUAN_TRI_TAI_KHOAN_NGUOI_DUNG_PARAMS);
        }





        ////Change status order
        //public JsonResult ChangeStatus(Guid? id)
        //{
        //    var result = _serviceWrapper.UserService.ChangeStatus(id);
        //    return Json(new
        //    {
        //        status = result
        //    });
        //}
    }
}
