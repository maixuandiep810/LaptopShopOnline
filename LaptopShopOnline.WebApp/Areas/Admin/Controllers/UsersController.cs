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
        [HasCredential(RoleId = "VIEW_AUTH")]
        public ActionResult Index(string sortOrder, string currentFilter, int? page, string searchString)
        {
            CountMessage();
            CountProduct();
            CountOrder();
            ViewBag.CurrentSort = sortOrder;
            ViewBag.UserNameSortParm = String.IsNullOrEmpty(sortOrder) ? "username_desc" : "";
            ViewBag.LastNameSortParm = sortOrder == "LastName" ? "lastname_desc" : "LastName";
            var user = _serviceWrapper.Db.User.Include(u => u.UserGroup).Select(p => p);

            //Search
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                user = user.Where(s => s.UserName.Contains(searchString)
                    || s.Email.ToString().Contains(searchString)
                    || s.UserGroup.Name.Contains(searchString)
                    || s.Address.Contains(searchString));
            }
            //Sort
            switch (sortOrder)
            {
                case "username_desc":
                    user = user.OrderByDescending(s => s.UserName);
                    break;
                case "LastName":
                    user = user.OrderBy(s => s.LastName);
                    break;
                case "lastname_desc":
                    user = user.OrderByDescending(s => s.LastName);
                    break;
                default:
                    user = user.OrderBy(s => s.UserName);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.SearchString = searchString;
            return View(user.ToPagedList(pageNumber, pageSize));
        }





        // GET: Admin/Users/Details/5
        [HasCredential(RoleId = "VIEW_AUTH")]
        public ActionResult Details(Guid? id)
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





        // GET: Admin/Users/Create
        [HasCredential(RoleId = "ADD_AUTH")]
        public ActionResult Create()
        {
            CountMessage();
            CountProduct();
            CountOrder();
            ViewBag.GroupId = new SelectList(_serviceWrapper.Db.UserGroup, "Id", "Name");
            return View();
        }





        // POST: Admin/Users/Create
        [HasCredential(RoleId = "ADD_AUTH")]
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
                    var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
                    AuditTable.InsertAuditFields(user, userLoginSession.UserName);
                    user.Password = Encryptor.MD5Hash(user.Password);
                    user.ConfirmPassword = Encryptor.MD5Hash(user.ConfirmPassword);
                    _serviceWrapper.Db.User.Add(user);
                    _serviceWrapper.Db.SaveChanges();
                    SetAlert("Thêm mới thành công", "success");
                    return Redirect("/quan-tri/tai-khoan-nguoi-dung");
                }
            }
            ViewBag.GroupId = new SelectList(_serviceWrapper.Db.UserGroup, "Id", "Name", user.GroupId);
            return View(user);
        }





        // GET: Admin/Users/Edit/5
        [HasCredential(RoleId = "EDIT_AUTH")]
        public ActionResult Edit(Guid? id)
        {
            CountMessage();
            CountProduct();
            CountOrder();
            if (id == null)
            {
                return BadRequest();
            }
            User user = _serviceWrapper.Db.User.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewBag.GroupId = new SelectList(_serviceWrapper.Db.UserGroup, "Id", "Name", user.GroupId);
            return View(user);
        }
        // POST: Admin/Users/Edit/5
        [HasCredential(RoleId = "EDIT_AUTH")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
                AuditTable.UpdateAuditFields(user, userLoginSession.UserName);
                user.Password = Encryptor.MD5Hash(user.Password);
                user.ConfirmPassword = Encryptor.MD5Hash(user.ConfirmPassword);
                _serviceWrapper.Db.Entry(user).State = EntityState.Modified;
                _serviceWrapper.Db.SaveChanges();
                SetAlert("Cập nhật thành công", "success");
                return Redirect("/quan-tri/tai-khoan-nguoi-dung");
            }
            ViewBag.GroupId = new SelectList(_serviceWrapper.Db.UserGroup, "Id", "Name", user.GroupId);
            return View(user);
        }





        // GET: Admin/Users/Delete/5
        [HasCredential(RoleId = "DELETE_AUTH")]
        public ActionResult Delete(Guid? id)
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





        // POST: Admin/Users/Delete/5
        [HasCredential(RoleId = "DELETE_AUTH")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            User user = _serviceWrapper.Db.User.Find(id);
            user.IsDeleted = true;
            _serviceWrapper.Db.SaveChanges();
            return Redirect("/quan-tri/tai-khoan-nguoi-dung");
        }



        //Change status order
        public JsonResult ChangeStatus(Guid? id)
        {
            var result = _serviceWrapper.UserService.ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}
