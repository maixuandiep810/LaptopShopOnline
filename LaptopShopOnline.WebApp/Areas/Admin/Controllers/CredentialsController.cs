using LaptopShopOnline.Common;
using LaptopShopOnline.Model.Entities;
using LaptopShopOnline.Service;
using LaptopShopOnline.WebApp.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartFormat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;


namespace LaptopShopOnline.WebApp.Areas.Admin.Controllers
{
    public class CredentialsController : BaseController
    {



        public CredentialsController(ServiceWrapper serviceWrapper) : base(serviceWrapper)
        {

        }






        // GET: Admin/Credentials
        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_AUTH_VIEW_ID)]
        public ActionResult Index(string userGroupId)
        {
            CountMessage();
            CountOrder();
            CountProduct();
            List<Credential> credentials = null;
            if (String.IsNullOrEmpty(userGroupId) == false)
            {
                credentials = _serviceWrapper.Db.Credentials.Include(c => c.Role).Include(c => c.UserGroup).Where(c => c.UserGroupId == userGroupId).ToList();
                return View(credentials);
            }
            credentials = _serviceWrapper.Db.Credentials.Include(c => c.Role).Include(c => c.UserGroup).ToList();
            return View(credentials);
        }
        // GET: Admin/Credentials/Details/5
        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_AUTH_VIEW_ID)]
        public ActionResult Details(string userGroupId, string roleId)
        {
            if (String.IsNullOrEmpty(userGroupId) || String.IsNullOrEmpty(roleId))
            {
                return BadRequest();
            }
            Credential credential = _serviceWrapper.Db.Credentials.Include(p => p.Role).Include(p => p.UserGroup).Where(p => p.UserGroupId == userGroupId && p.RoleId == roleId).FirstOrDefault();
            if (credential == null)
            {
                return NotFound();
            }
            return View(credential);
        }



        // GET: Admin/Credentials/Create
        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_AUTH_CREATE_ID)]
        public ActionResult Create(string userGroupId)
        {
            CountMessage();
            CountOrder();
            CountProduct();
            ViewBag.RoleId = new SelectList(_serviceWrapper.Db.Role, "Id", "Name");
            ViewBag.UserGroupId = new SelectList(_serviceWrapper.Db.UserGroup, "Id", "Name");
            var credential = new Credential {UserGroupId = userGroupId};
            return View(credential);
        }
        // POST: Admin/Credentials/Create
        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_AUTH_CREATE_ID)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string userGroupId, [FromForm] Credential credential)
        {
            if (ModelState.IsValid)
            {
                _serviceWrapper.Db.Credentials.Add(credential);
                _serviceWrapper.Db.SaveChanges();
                SetAlert("Thêm mới thành công", "success");
                if (String.IsNullOrEmpty(userGroupId) == false)
                {
                    return Redirect(Smart.Format(CommonConstants.ROUTE_QUAN_TRI_PHAN_QUYEN_NHOM_NGUOI_DUNG_PARAMS, new { userGroupId = userGroupId }));
                }
                return Redirect(CommonConstants.ROUTE_QUAN_TRI_PHAN_QUYEN_PARAMS);
            }

            ViewBag.RoleId = new SelectList(_serviceWrapper.Db.Role, "Id", "Name", credential.RoleId);
            ViewBag.UserGroupId = new SelectList(_serviceWrapper.Db.UserGroup, "Id", "Name", credential.UserGroupId);
            return View(credential);
        }



        // GET: Admin/Credentials/Delete/5
        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_AUTH_DELETE_ID)]
        public ActionResult Delete(string userGroupId, string roleId)
        {
            if (userGroupId == null || roleId == null)
            {
                return BadRequest();
            }
            Credential credential = _serviceWrapper.Db.Credentials.Find(userGroupId, roleId);
            if (credential == null)
            {
                return NotFound();
            }
            return View(credential);
        }
        // POST: Admin/Credentials/Delete/5
        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_AUTH_DELETE_ID)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string userGroupId, string roleId)
        {
            Credential credential = _serviceWrapper.Db.Credentials.Find(userGroupId, roleId);
            _serviceWrapper.Db.Credentials.Remove(credential);
            _serviceWrapper.Db.SaveChanges();
            SetAlert("Xóa thành công", "success");
            if (String.IsNullOrEmpty(userGroupId) == false)
            {
                return Redirect(Smart.Format(CommonConstants.ROUTE_QUAN_TRI_PHAN_QUYEN_NHOM_NGUOI_DUNG_PARAMS, new { userGroupId = userGroupId }));
            }
            return Redirect(CommonConstants.ROUTE_QUAN_TRI_PHAN_QUYEN_PARAMS);
        }

    }
}
