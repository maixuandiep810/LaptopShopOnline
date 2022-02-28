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
    public class NewsCategoriesController : BaseController { 






        public NewsCategoriesController(ServiceWrapper serviceWrapper) : base(serviceWrapper)
        {

        }






        // GET: Admin/NewsCategories
        public ActionResult Index()
        {
            CountMessage();
            CountProduct();
            CountOrder();
            return View(_serviceWrapper.Db.NewsCategory.Where(x => x.IsDeleted == false).OrderByDescending(x => x.CreatedOn).ToList());
        }



        // GET: Admin/NewsCategories/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            NewsCategory newsCategory = _serviceWrapper.Db.NewsCategory.Find(id);
            if (newsCategory == null)
            {
                return NotFound();
            }
            return View(newsCategory);
        }



        // GET: Admin/NewsCategories/Create
        public ActionResult Create()
        {
            CountMessage();
            CountOrder();
            CountProduct();
            return View();
        }



        // POST: Admin/NewsCategories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewsCategory newsCategory)
        {
            if (ModelState.IsValid)
            {
                newsCategory.Id = Guid.NewGuid();
                var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
                AuditTable.InsertAuditFields(newsCategory, userLoginSession.UserName);
                newsCategory.Id = Guid.NewGuid();
                _serviceWrapper.Db.NewsCategory.Add(newsCategory);
                _serviceWrapper.Db.SaveChanges();
                SetAlert("Thêm mới thành công", "success");
                return Redirect("/quan-tri/loai-tin-tuc");
            }

            return View(newsCategory);
        }



        // GET: Admin/NewsCategories/Edit/5
        public ActionResult Edit(Guid? id)
        {
            CountMessage();
            CountOrder();
            CountProduct();
            if (id == null)
            {
                return BadRequest();
            }
            NewsCategory newsCategory = _serviceWrapper.Db.NewsCategory.Find(id);
            if (newsCategory == null)
            {
                return NotFound();
            }
            return View(newsCategory);
        }



        // POST: Admin/NewsCategories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NewsCategory newsCategory)
        {
            if (ModelState.IsValid)
            {
                var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
                AuditTable.UpdateAuditFields(newsCategory, userLoginSession.UserName);
                _serviceWrapper.Db.Entry(newsCategory).State = EntityState.Modified;
                _serviceWrapper.Db.SaveChanges();
                SetAlert("Cập nhật thành công", "success");
                return Redirect("/quan-tri/loai-tin-tuc");
            }
            return View(newsCategory);
        }



        // GET: Admin/NewsCategories/Delete/5
        public ActionResult Delete(Guid? id)
        {
            var isExists = _serviceWrapper.Db.News.Where(x => x.NewsCategoryId == id);
            if (isExists != null)
            {
                return PartialView("_Delete");
            }
            if (id == null)
            {
                return BadRequest();
            }
            NewsCategory newsCategory = _serviceWrapper.Db.NewsCategory.Find(id);
            if (newsCategory == null)
            {
                return NotFound();
            }
            return View(newsCategory);
        }



        // POST: Admin/NewsCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            NewsCategory newsCategory = _serviceWrapper.Db.NewsCategory.Find(id);
            newsCategory.IsDeleted = true;
            _serviceWrapper.Db.SaveChanges();
            return Redirect("/quan-tri/loai-tin-tuc");
        }

    }
}
