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
    public class NewsController : BaseController
    {



        public NewsController(ServiceWrapper serviceWrapper) : base(serviceWrapper)
        {

        }






        // GET: Admin/News
        public ActionResult Index(string sortOrder, int? page, string searchString, string currentFilter)
        {
            CountMessage();
            CountOrder();
            CountProduct();
            //Sort
            ViewBag.CurrentSort = sortOrder;
            ViewBag.TitleSortParm = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.NewsCategorySortParm = sortOrder == "NewsCategory" ? "newsCategory_desc" : "NewsCategory";
            var news = _serviceWrapper.Db.News.Include(n => n.NewsCategory).Where(x => x.IsDeleted == false);

            //Filter
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
                news = news.Where(s => s.Name.Contains(searchString) || s.NewsCategory.Name.Contains(searchString)
                || s.Summary.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "title_desc":
                    news = news.OrderByDescending(s => s.Name);
                    break;
                case "NewsCategory":
                    news = news.OrderBy(s => s.NewsCategory.Name);
                    break;
                case "newsCategory_desc":
                    news = news.OrderByDescending(s => s.NewsCategory.Name);
                    break;
                default:
                    news = news.OrderBy(s => s.Name);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.SearchString = searchString;
            return View(news.ToPagedList(pageNumber, pageSize));
        }



        // GET: Admin/News/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            News news = _serviceWrapper.Db.News.Find(id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }



        // GET: Admin/News/Create
        public ActionResult Create()
        {
            CountMessage();
            CountProduct();
            CountOrder();
            ViewBag.NewsCategoryId = new SelectList(_serviceWrapper.Db.NewsCategory, "Id", "Name");
            return View();
        }



        // POST: Admin/News/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(News news)
        {
            if (ModelState.IsValid)
            {
                news.Id = Guid.NewGuid();
                var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
                AuditTable.InsertAuditFields(news, userLoginSession.UserName); news.CreatedBy = userLoginSession.UserName;
                news.Id = Guid.NewGuid();
                _serviceWrapper.Db.News.Add(news);
                _serviceWrapper.Db.SaveChanges();
                SetAlert("Thêm mới thành công", "success");
                return Redirect("/quan-tri/tin-tuc");
            }

            ViewBag.NewsCategoryId = new SelectList(_serviceWrapper.Db.NewsCategory, "Id", "Name", news.NewsCategoryId);
            return View(news);
        }



        // GET: Admin/News/Edit/5
        public ActionResult Edit(Guid? id)
        {
            CountMessage();
            CountProduct();
            CountOrder();
            if (id == null)
            {
                return BadRequest();
            }
            News news = _serviceWrapper.Db.News.Find(id);
            if (news == null)
            {
                return NotFound();
            }
            ViewBag.NewsCategoryId = new SelectList(_serviceWrapper.Db.NewsCategory, "Id", "Name", news.NewsCategoryId);
            return View(news);
        }



        // POST: Admin/News/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(News news)
        {
            if (ModelState.IsValid)
            {
                var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
                AuditTable.UpdateAuditFields(news, userLoginSession.UserName);
                _serviceWrapper.Db.Entry(news).State = EntityState.Modified;
                _serviceWrapper.Db.SaveChanges();
                SetAlert("Cập nhật thành công", "success");
                return Redirect("/quan-tri/tin-tuc");
            }
            ViewBag.NewsCategoryId = new SelectList(_serviceWrapper.Db.NewsCategory, "Id", "Name", news.NewsCategoryId);
            return View(news);
        }



        // GET: Admin/News/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            News news = _serviceWrapper.Db.News.Find(id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }



        // POST: Admin/News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            News news = _serviceWrapper.Db.News.Find(id);
            news.IsDeleted = true;
            _serviceWrapper.Db.SaveChanges();
            SetAlert("Xóa thành công", "success");
            return Redirect("/quan-tri/tin-tuc");
        }

    }
}
