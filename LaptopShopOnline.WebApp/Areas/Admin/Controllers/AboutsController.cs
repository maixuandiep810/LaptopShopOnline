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
    public class AboutsController : BaseController
    {



        public AboutsController(ServiceWrapper serviceWrapper) : base(serviceWrapper)
        {

        }






        // GET: Admin/Abouts
        public ActionResult Index()
        {
            CountMessage();
            CountProduct();
            CountOrder();
            return View(_serviceWrapper.Db.About.Where(x => x.IsDeleted == false).ToList());
        }



        // GET: Admin/Abouts/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            About about = _serviceWrapper.Db.About.Find(id);
            if (about == null)
            {
                return NotFound();
            }
            return View(about);
        }



        // GET: Admin/Abouts/Create
        public ActionResult Create()
        {
            CountMessage();
            CountProduct();
            CountOrder();
            return View();
        }



        // POST: Admin/Abouts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(About about)
        {
            if (ModelState.IsValid)
            {
                about.Id = Guid.NewGuid();
                var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
                AuditTable.InsertAuditFields(about, userLoginSession.UserName);
                about.CreatedBy = userLoginSession.UserName;
                _serviceWrapper.Db.About.Add(about);
                _serviceWrapper.Db.SaveChanges();
                SetAlert("Thêm mới thành công", "success");
                return Redirect("/quan-tri/gioi-thieu-cua-hang");
            }
            return View(about);
        }



        // GET: Admin/Abouts/Edit/5
        public ActionResult Edit(Guid? id)
        {
            CountMessage();
            CountProduct();
            CountOrder();
            if (id == null)
            {
                return BadRequest();
            }
            About about = _serviceWrapper.Db.About.Find(id);
            if (about == null)
            {
                return NotFound();
            }
            return View(about);
        }



        // POST: Admin/Abouts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(About about)
        {
            if (ModelState.IsValid)
            {
                var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
                AuditTable.UpdateAuditFields(about, userLoginSession.UserName);
                about.ModifiedBy = userLoginSession.UserName;
                _serviceWrapper.Db.Entry(about).State = EntityState.Modified;
                _serviceWrapper.Db.SaveChanges();
                SetAlert("Cập nhật thành công", "success");
                return Redirect("/quan-tri/gioi-thieu-cua-hang");
            }
            return View(about);
        }



        // GET: Admin/Abouts/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            About about = _serviceWrapper.Db.About.Find(id);
            if (about == null)
            {
                return NotFound();
            }
            return View(about);
        }



        // POST: Admin/Abouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            About about = _serviceWrapper.Db.About.Find(id);
            about.IsDeleted = true;
            _serviceWrapper.Db.SaveChanges();
            SetAlert("Xóa thành công", "success");
            return Redirect("/quan-tri/gioi-thieu-cua-hang");
        }

    }
}
