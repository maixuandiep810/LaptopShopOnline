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



    public class RolesController : BaseController
    {



        public RolesController(ServiceWrapper serviceWrapper) : base(serviceWrapper)
        {

        }






        // GET: Admin/Roles
        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_SYS_READ_ID)]
        public ActionResult Index()
        {
            CountMessage();
            CountOrder();
            CountProduct();
            return View(_serviceWrapper.Db.Role.ToList());
        }

        // GET: Admin/Roles/Details/5
        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_SYS_READ_ID)]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Role role = _serviceWrapper.Db.Role.Find(id);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }


        // GET: Admin/Roles/Edit/5
        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_SYS_UPDATE_ID)]
        public ActionResult Edit(string id)
        {
            CountMessage();
            CountOrder();
            CountProduct();
            if (id == null)
            {
                return BadRequest();
            }
            Role role = _serviceWrapper.Db.Role.Find(id);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }
        // POST: Admin/Roles/Edit/5

        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_SYS_UPDATE_ID)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Role role)
        {
            CountMessage();
            CountOrder();
            CountProduct();
            if (ModelState.IsValid)
            {
                _serviceWrapper.Db.Entry(role).State = EntityState.Modified;
                _serviceWrapper.Db.SaveChanges();
                SetAlert("Cập nhật thành công", "success");
                return Redirect(CommonConstants.ROUTE_QUAN_TRI_QUYEN_PARAMS);
            }
            return View(role);
        }






        //// GET: Admin/Roles/Create
        //[HasCredential(RoleId = CommonConstants.MANAGER_ROLE_SYS_CREATE_ID)]
        //public ActionResult Create()
        //{
        //    CountMessage();
        //    CountOrder();
        //    CountProduct();
        //    return View();
        //}
        //// POST: Admin/Roles/Create
        //[HasCredential(RoleId = CommonConstants.MANAGER_ROLE_SYS_CREATE_ID)]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Role role)
        //{
        //    CountMessage();
        //    CountOrder();
        //    CountProduct();
        //    if (ModelState.IsValid)
        //    {
        //        _serviceWrapper.Db.Role.Add(role);
        //        _serviceWrapper.Db.SaveChanges();
        //        SetAlert("Thêm mới thành công", "success");
        //        return Redirect(CommonConstants.ROUTE_QUAN_TRI_QUYEN_PARAMS);
        //    }

        //    return View(role);
        //}



        //// GET: Admin/Roles/Delete/5
        //[HasCredential(RoleId = "DELETE_SYS")]
        //public ActionResult Delete(string id)
        //{
        //    var existCredential = _serviceWrapper.Db.Credentials.Where(x => x.RoleId == id).FirstOrDefault();
        //    if (existCredential != null)
        //    {
        //        return PartialView("_Delete");
        //    }
        //    if (id == null)
        //    {
        //        return BadRequest();
        //    }
        //    Role role = _serviceWrapper.Db.Role.Find(id);
        //    if (role == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(role);
        //}
        //// POST: Admin/Roles/Delete/5
        //[HasCredential(RoleId = "DELETE_SYS")]
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    Role role = _serviceWrapper.Db.Role.Find(id);
        //    _serviceWrapper.Db.Role.Remove(role);
        //    _serviceWrapper.Db.SaveChanges();
        //    SetAlert("Xóa thành công", "success");
        //    return Redirect(CommonConstants.ROUTE_QUAN_TRI_QUYEN_PARAMS);
        //}

    }
}
