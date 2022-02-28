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
    public class FeedbacksController : BaseController
    {



        public FeedbacksController(ServiceWrapper serviceWrapper) : base(serviceWrapper)
        {

        }






        // GET: Admin/Feedbacks
        public ActionResult Index()
        {
            CountMessage();
            CountProduct();
            CountOrder();
            var result = _serviceWrapper.Db.Feedback.Where(x => x.IsDeleted == false).OrderByDescending(x => x.CreatedOn);
            return View(result.ToList());
        }



        // GET: Admin/Contacts/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Feedback feedback = _serviceWrapper.Db.Feedback.Find(id);
            if (feedback == null)
            {
                return NotFound();
            }
            return View(feedback);
        }



        // GET: Admin/Feedbacks/Edit/5
        public ActionResult Edit(Guid? id)
        {
            CountMessage();
            CountProduct();
            CountOrder();
            if (id == null)
            {
                return BadRequest();
            }
            Feedback feedback = _serviceWrapper.Db.Feedback.Find(id);
            if (feedback == null)
            {
                return NotFound();
            }
            return View(feedback);
        }



        // POST: Admin/Feedbacks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Id,Name,Phone,Email,Address,Content,Reply,CreatedOn,CreatedBy,IsDeleted")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
                AuditTable.UpdateAuditFields(feedback, userLoginSession.UserName);
                _serviceWrapper.Db.Entry(feedback).State = EntityState.Modified;
                _serviceWrapper.Db.SaveChanges();
                SetAlert("Cập nhật thành công", "success");
                return Redirect("/quan-tri/phan-hoi-y-kien-khach-hang");
            }
            return View(feedback);
        }



        // GET: Admin/Feedbacks/Delete/5
        public ActionResult Delete(Guid? id)
        {
            CountMessage();
            CountProduct();
            if (id == null)
            {
                return BadRequest();
            }
            Feedback feedback = _serviceWrapper.Db.Feedback.Find(id);
            if (feedback == null)
            {
                return NotFound();
            }
            return View(feedback);
        }



        // POST: Admin/Feedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Feedback feedback = _serviceWrapper.Db.Feedback.Find(id);
            feedback.IsDeleted = true;
            _serviceWrapper.Db.SaveChanges();
            SetAlert("Xóa thành công", "success");
            return Redirect("/quan-tri/phan-hoi-y-kien-khach-hang");
        }

    }
}
