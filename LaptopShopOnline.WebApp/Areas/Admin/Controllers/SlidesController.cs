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
    public class SlidesController : BaseController
    {



        public SlidesController(ServiceWrapper serviceWrapper) : base(serviceWrapper)
        {

        }






        // GET: Admin/Slides
        [HasCredential(RoleId = "VIEW_LAYOUT")]
        public ActionResult Index()
        {
            CountMessage();
            CountOrder();
            CountProduct();
            return View(_serviceWrapper.Db.Slide.Where(x => x.IsDeleted == false).OrderByDescending(x => x.CreatedOn).Take(3).ToList());
        }



        // GET: Admin/Slides/Details/5
        [HasCredential(RoleId = "VIEW_LAYOUT")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Slide slide = _serviceWrapper.Db.Slide.Find(id);
            if (slide == null)
            {
                return NotFound();
            }
            return View(slide);
        }



        // GET: Admin/Slides/Create
        [HasCredential(RoleId = "VIEW_LAYOUT")]
        public ActionResult Create()
        {
            CountMessage();
            CountProduct();
            CountOrder();
            return View();
        }



        // POST: Admin/Slides/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HasCredential(RoleId = "VIEW_LAYOUT")]
        public ActionResult Create([Bind("Id,UrlImage,DisplayOrder,Link,Description,CreatedOn,CreatedBy,ModifiedOn,ModifiedBy,IsDeleted")] Slide slide)
        {
            if (ModelState.IsValid)
            {
                var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
                AuditTable.InsertAuditFields(slide, userLoginSession.UserName);
                _serviceWrapper.Db.Slide.Add(slide);
                _serviceWrapper.Db.SaveChanges();
                SetAlert("Thêm mới thành công", "success");
                return Redirect("/quan-tri/slide");
            }

            return View(slide);
        }



        // GET: Admin/Slides/Edit/5
        [HasCredential(RoleId = "VIEW_LAYOUT")]
        public ActionResult Edit(int? id)
        {
            CountMessage();
            CountOrder();
            CountProduct();
            if (id == null)
            {
                return BadRequest();
            }
            Slide slide = _serviceWrapper.Db.Slide.Find(id);
            if (slide == null)
            {
                return NotFound();
            }
            return View(slide);
        }



        // POST: Admin/Slides/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HasCredential(RoleId = "VIEW_LAYOUT")]
        public ActionResult Edit([Bind("Id,UrlImage,DisplayOrder,Link,Description,CreatedOn,CreatedBy,ModifiedOn,ModifiedBy,IsDeleted")] Slide slide)
        {
            if (ModelState.IsValid)
            {
                var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
                AuditTable.UpdateAuditFields(slide, userLoginSession.UserName);
                _serviceWrapper.Db.Entry(slide).State = EntityState.Modified;
                _serviceWrapper.Db.SaveChanges();
                SetAlert("Cập nhật thành công", "success");
                return Redirect("/quan-tri/slide");
            }
            return View(slide);
        }



        // GET: Admin/Slides/Delete/5
        [HasCredential(RoleId = "VIEW_LAYOUT")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Slide slide = _serviceWrapper.Db.Slide.Find(id);
            if (slide == null)
            {
                return NotFound();
            }
            return View(slide);
        }



        // POST: Admin/Slides/Delete/5
        [HttpPost, ActionName("Delete")]
        [HasCredential(RoleId = "VIEW_LAYOUT")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slide slide = _serviceWrapper.Db.Slide.Find(id);
            slide.IsDeleted = true;
            _serviceWrapper.Db.SaveChanges();
            SetAlert("Xóa thành công", "success");
            return Redirect("/quan-tri/slide");
        }

    }
}
