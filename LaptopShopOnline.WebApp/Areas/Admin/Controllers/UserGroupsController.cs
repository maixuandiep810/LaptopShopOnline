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
        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_SYS_READ_ID)]
        public ActionResult Index()
        {
            CountMessage();
            CountProduct();
            CountOrder();
            return View(_serviceWrapper.Db.UserGroup.ToList());
        }



        // GET: Admin/UserGroups/Details/5
        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_SYS_READ_ID)]
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
        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_SYS_CREATE_ID)]
        public ActionResult Create()
        {
            CountMessage();
            CountProduct();
            CountOrder();
            return View();
        }
        // POST: Admin/UserGroups/Create
        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_SYS_CREATE_ID)]       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserGroup userGroup)
        {
            CountMessage();
            CountProduct();
            CountOrder();
            if (ModelState.IsValid)
            {
                _serviceWrapper.Db.UserGroup.Add(userGroup);
                _serviceWrapper.Db.SaveChanges();
                SetAlert("Thêm mới thành công", "success");
                return Redirect(CommonConstants.ROUTE_QUAN_TRI_NHOM_NGUOI_DUNG_PARAMS);
            }

            return View(userGroup);
        }



        // GET: Admin/UserGroups/Edit/5
        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_SYS_UPDATE_ID)]
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
        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_SYS_UPDATE_ID)]        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserGroup userGroup)
        {
            CountMessage();
            CountProduct();
            CountOrder();
            if (ModelState.IsValid)
            {
                _serviceWrapper.Db.Entry(userGroup).State = EntityState.Modified;
                _serviceWrapper.Db.SaveChanges();
                SetAlert("Cập nhật thành công", "success");
                return Redirect(CommonConstants.ROUTE_QUAN_TRI_NHOM_NGUOI_DUNG_PARAMS);
            }
            return View(userGroup);
        }



        // GET: Admin/UserGroups/Delete/5
        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_SYS_DELETE_ID)]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return PartialView("_Delete");
            }
            var userGroup = _serviceWrapper.Db.UserGroup.Where(x => x.Id == id).FirstOrDefault();
            if (userGroup == null)
            {
                return PartialView("_Delete");
            }
            return PartialView();
        }
        //
        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_SYS_DELETE_ID)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CountMessage();
            CountProduct();
            CountOrder();
            UserGroup userGroup = _serviceWrapper.Db.UserGroup.Find(id);
            _serviceWrapper.Db.UserGroup.Remove(userGroup);
            _serviceWrapper.Db.SaveChanges();
            SetAlert("Xóa thành công", "success");
            return Redirect(CommonConstants.ROUTE_QUAN_TRI_NHOM_NGUOI_DUNG_PARAMS);
        }

    }
}
