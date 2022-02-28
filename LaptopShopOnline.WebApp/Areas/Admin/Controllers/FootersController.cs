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
    public class FootersController : BaseController
    {



        public FootersController(ServiceWrapper serviceWrapper) : base(serviceWrapper)
        {

        }






        // GET: Admin/Footers
        [HasCredential(RoleId = "VIEW_LAYOUT")]
        public ActionResult Index()
        {
            CountMessage();
            CountProduct();
            CountOrder();
            return View(_serviceWrapper.Db.Footer.Where(x => x.IsDeleted == false).OrderByDescending(x => x.CreatedOn).ToList());
        }



        // GET: Admin/Footers/Details/5
        [HasCredential(RoleId = "VIEW_LAYOUT")]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Footer footer = _serviceWrapper.Db.Footer.Find(id);
            if (footer == null)
            {
                return NotFound();
            }
            return View(footer);
        }



        // GET: Admin/Footers/Create
        [HasCredential(RoleId = "VIEW_LAYOUT")]
        public ActionResult Create()
        {
            CountMessage();
            CountProduct();
            CountOrder();
            return View();
        }



        // POST: Admin/Footers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HasCredential(RoleId = "VIEW_LAYOUT")]
        public ActionResult Create([Bind("Id,CoppyRight,Address,PhoneNumber,CreatedOn,CreatedBy,ModifiedOn,ModifiedBy,IsDeleted")] Footer footer)
        {
            if (ModelState.IsValid)
            {
                footer.Id = Guid.NewGuid();
                var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
                AuditTable.InsertAuditFields(footer, userLoginSession.UserName); footer.CreatedBy = userLoginSession.UserName;
                _serviceWrapper.Db.Footer.Add(footer);
                _serviceWrapper.Db.SaveChanges();
                SetAlert("Thêm mới thành công", "success");
                return Redirect("/quan-tri/footer");
            }
            return View(footer);
        }



        // GET: Admin/Footers/Edit/5
        [HasCredential(RoleId = "VIEW_LAYOUT")]
        public ActionResult Edit(Guid? id)
        {
            CountMessage();
            CountProduct();
            CountOrder();
            if (id == null)
            {
                return BadRequest();
            }
            Footer footer = _serviceWrapper.Db.Footer.Find(id);
            if (footer == null)
            {
                return NotFound();
            }
            return View(footer);
        }



        // POST: Admin/Footers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HasCredential(RoleId = "VIEW_LAYOUT")]
        public ActionResult Edit([Bind("Id,CoppyRight,Address,PhoneNumber,CreatedOn,CreatedBy,ModifiedOn,ModifiedBy,IsDeleted")] Footer footer)
        {
            if (ModelState.IsValid)
            {
                var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
                AuditTable.UpdateAuditFields(footer, userLoginSession.UserName);
                _serviceWrapper.Db.Entry(footer).State = EntityState.Modified;
                _serviceWrapper.Db.SaveChanges();
                SetAlert("Cập nhật thành công", "success");
                return Redirect("/quan-tri/footer");
            }
            return View(footer);
        }



        // GET: Admin/Footers/Delete/5
        [HasCredential(RoleId = "VIEW_LAYOUT")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Footer footer = _serviceWrapper.Db.Footer.Find(id);
            if (footer == null)
            {
                return NotFound();
            }
            return View(footer);
        }



        // POST: Admin/Footers/Delete/5
        [HttpPost, ActionName("Delete")]
        [HasCredential(RoleId = "VIEW_LAYOUT")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Footer footer = _serviceWrapper.Db.Footer.Find(id);
            //_serviceWrapper.Db.Footer.Remove(footer);
            footer.IsDeleted = true;
            _serviceWrapper.Db.SaveChanges();
            SetAlert("Xóa thành công", "success");
            return Redirect("/quan-tri/footer");
        }

    }
}
