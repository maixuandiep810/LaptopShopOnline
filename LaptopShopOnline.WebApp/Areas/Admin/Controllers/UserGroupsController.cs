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
    public class UserGroupsController : BaseController
    {



        public UserGroupsController(ServiceWrapper serviceWrapper) : base(serviceWrapper)
        {

        }






        // GET: Admin/UserGroups
        [HasCredential(RoleId = "VIEW_USER_GROUP")]
        public ActionResult Index()
        {
            CountMessage();
            CountProduct();
            CountOrder();
            return View(_serviceWrapper.Db.UserGroup.ToList());
        }



        // GET: Admin/UserGroups/Details/5
        [HasCredential(RoleId = "VIEW_USER_GROUP")]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            UserGroup userGroup = _serviceWrapper.Db.UserGroup.Find(id);
            if (userGroup == null)
            {
                return NotFound();
            }
            return View(userGroup);
        }



        // GET: Admin/UserGroups/Create
        [HasCredential(RoleId = "CREATE_USER_GROUP")]
        public ActionResult Create()
        {
            CountMessage();
            CountProduct();
            CountOrder();
            return View();
        }



        // POST: Admin/UserGroups/Create

        [HasCredential(RoleId = "CREATE_USER_GROUP")]        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Name")] UserGroup userGroup)
        {
            if (ModelState.IsValid)
            {
                _serviceWrapper.Db.UserGroup.Add(userGroup);
                _serviceWrapper.Db.SaveChanges();
                SetAlert("Thêm mới thành công", "success");
                return Redirect("/quan-tri/nhom-nguoi-dung");
            }

            return View(userGroup);
        }



        // GET: Admin/UserGroups/Edit/5
        [HasCredential(RoleId = "EDIT_USER_GROUP")]
        public ActionResult Edit(string id)
        {
            CountMessage();
            CountProduct();
            CountOrder();
            if (id == null)
            {
                return BadRequest();
            }
            UserGroup userGroup = _serviceWrapper.Db.UserGroup.Find(id);
            if (userGroup == null)
            {
                return NotFound();
            }
            return View(userGroup);
        }



        // POST: Admin/UserGroups/Edit/5

        [HasCredential(RoleId = "EDIT_USER_GROUP")]        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Id,Name")] UserGroup userGroup)
        {
            if (ModelState.IsValid)
            {
                _serviceWrapper.Db.Entry(userGroup).State = EntityState.Modified;
                _serviceWrapper.Db.SaveChanges();
                SetAlert("Cập nhật thành công", "success");
                return Redirect("/quan-tri/nhom-nguoi-dung");
            }
            return View(userGroup);
        }



        // GET: Admin/UserGroups/Delete/5
        [HasCredential(RoleId = "DELETE_USER_GROUP")]
        public ActionResult Delete(string id)
        {
            var existCredential = _serviceWrapper.Db.Credentials.Where(x => x.UserGroupId == id);
            var existUser = _serviceWrapper.Db.User.Where(x => x.GroupId == id);
            if (existCredential != null || existUser != null)
            {
                return PartialView("_Delete");
            }
            if (id == null)
            {
                return BadRequest();
            }
            UserGroup userGroup = _serviceWrapper.Db.UserGroup.Find(id);
            if (userGroup == null)
            {
                return NotFound();
            }
            return View(userGroup);
        }



        // POST: Admin/UserGroups/Delete/5
        [HasCredential(RoleId = "DELETE_USER_GROUP")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UserGroup userGroup = _serviceWrapper.Db.UserGroup.Find(id);
            _serviceWrapper.Db.UserGroup.Remove(userGroup);
            _serviceWrapper.Db.SaveChanges();
            SetAlert("Xóa thành công", "success");
            return Redirect("/quan-tri/nhom-nguoi-dung");
        }

    }
}
