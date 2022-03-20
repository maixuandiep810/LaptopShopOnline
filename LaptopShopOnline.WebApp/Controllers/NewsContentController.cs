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


namespace LaptopShopOnline.WebApp.Controllers
{
    public class NewsContentController
    {



        //public NewsContentController(ServiceWrapper serviceWrapper) : base(serviceWrapper)
        //{
        //}



        //public ActionResult LoadAllNews(int? page)
        //{
        //    List<News> news = new List<News>();
        //    news = _serviceWrapper.Db.News.Where(x => x.IsDeleted == false).OrderByDescending(x => x.CreatedOn).ToList();
        //    ViewBag.Count = news.Count();
        //    int pageSize = 5;
        //    int pageNumber = (page ?? 1);
        //    return View(news.ToPagedList(pageNumber, pageSize));
        //}
        //public ActionResult NewsDetails(Guid id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    News news = _serviceWrapper.Db.News.Find(id);
        //    if (news == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(news);
        //}

        //public ActionResult LoadNewsCategory()
        //{
        //    List<NewsCategory> newsCategories = new List<NewsCategory>();
        //    newsCategories = _serviceWrapper.Db.NewsCategory.Where(x => x.IsDeleted == false).ToList();
        //    ViewBag.Count = newsCategories.Count();
        //    return PartialView(newsCategories);
        //}

        //public ActionResult NewsCategoryDetail(NewsCategory newsCategory)
        //{
        //    List<News> list = new List<News>();
        //    list = _serviceWrapper.Db.News.Where(x => x.IsDeleted == false && x.NewsCategoryId == newsCategory.Id).ToList();
        //    ViewBag.Count = list.Count();
        //    return View(list);
        //}
    }
}