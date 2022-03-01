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
    public class CredentialsController : BaseController
    {



        public CredentialsController(ServiceWrapper serviceWrapper) : base(serviceWrapper)
        {

        }






        // GET: Admin/Credentials
        [HasCredential(RoleId = "VIEW_AUTH")]
        public ActionResult Index()
        {
            CountMessage();
            CountOrder();
            CountProduct();
            var credentials = _serviceWrapper.Db.Credentials.Include(c => c.Role).Include(c => c.UserGroup);
            return View(credentials.ToList());
        }
        // GET: Admin/Credentials/Details/5
        [HasCredential(RoleId = "VIEW_AUTH")]
        public ActionResult Details(string groupId, string roleId)
        {
            Credential credential = _serviceWrapper.Db.Credentials.Include(p => p.Role).Include(p => p.UserGroup).FirstOrDefault();
            if (credential == null)
            {
                return NotFound();
            }
            return View(credential);
        }



        // GET: Admin/Credentials/Create
        [HasCredential(RoleId = "CREATE_AUTH")]
        public ActionResult Create()
        {
            CountMessage();
            CountOrder();
            CountProduct();
            ViewBag.RoleId = new SelectList(_serviceWrapper.Db.Role, "Id", "Name");
            ViewBag.UserGroupId = new SelectList(_serviceWrapper.Db.UserGroup, "Id", "Name");
            return View();
        }
        // POST: Admin/Credentials/Create
        [HasCredential(RoleId = "CREATE_AUTH")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("UserGroupId,RoleId")] Credential credential)
        {
            if (ModelState.IsValid)
            {
                _serviceWrapper.Db.Credentials.Add(credential);
                _serviceWrapper.Db.SaveChanges();
                SetAlert("Thêm mới thành công", "success");
                return Redirect("/quan-tri/phan-quyen-nguoi-dung");
            }

            ViewBag.RoleId = new SelectList(_serviceWrapper.Db.Role, "Id", "Name", credential.RoleId);
            ViewBag.UserGroupId = new SelectList(_serviceWrapper.Db.UserGroup, "Id", "Name", credential.UserGroupId);
            return View(credential);
        }



        // GET: Admin/Credentials/Delete/5
        [HasCredential(RoleId = "DELETE_AUTH")]
        public ActionResult Delete(string groupId, string roleId)
        {
            if (groupId == null || roleId == null)
            {
                return BadRequest();
            }
            Credential credential = _serviceWrapper.Db.Credentials.Find(groupId, roleId);
            if (credential == null)
            {
                return NotFound();
            }
            return View(credential);
        }
        // POST: Admin/Credentials/Delete/5
        [HasCredential(RoleId = "DELETE_AUTH")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string groupId, string roleId)
        {
            Credential credential = _serviceWrapper.Db.Credentials.Find(groupId, roleId);
            _serviceWrapper.Db.Credentials.Remove(credential);
            _serviceWrapper.Db.SaveChanges();
            SetAlert("Xóa thành công", "success");
            return Redirect("/quan-tri/phan-quyen-nguoi-dung");
        }

    }
}
