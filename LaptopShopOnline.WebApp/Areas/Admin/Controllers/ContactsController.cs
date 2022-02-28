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
    public class ContactsController : BaseController
    {



        public ContactsController(ServiceWrapper serviceWrapper) : base(serviceWrapper)
        {

        }






        // GET: Admin/Contacts
        [HasCredential(RoleId = "VIEW_LAYOUT")]
        public ActionResult Index()
        {
            CountMessage();
            CountProduct();
            CountOrder();
            return View(_serviceWrapper.Db.Contact.Where(x => x.IsDeleted == false).OrderByDescending(x => x.CreatedOn).Take(2).ToList());
        }



        // GET: Admin/Contacts/Details/5
        [HasCredential(RoleId = "VIEW_LAYOUT")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Contact contact = _serviceWrapper.Db.Contact.Find(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }



        // GET: Admin/Contacts/Create
        [HasCredential(RoleId = "VIEW_LAYOUT")]
        public ActionResult Create()
        {
            CountMessage();
            CountProduct();
            CountOrder();
            return View();
        }



        // POST: Admin/Contacts/Create

        [HasCredential(RoleId = "VIEW_LAYOUT")]        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Title,ObjectName,Address,Mobile,Website,Email,CreatedOn,CreatedBy,ModifiedOn,ModifiedBy,IsDeleted")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
                AuditTable.InsertAuditFields(contact, userLoginSession.UserName);
                _serviceWrapper.Db.Contact.Add(contact);
                _serviceWrapper.Db.SaveChanges();
                SetAlert("Thêm mới thành công", "success");
                return Redirect("/quan-tri/thong-tin-cua-hang");
            }

            return View(contact);
        }



        // GET: Admin/Contacts/Edit/5
        [HasCredential(RoleId = "VIEW_LAYOUT")]
        public ActionResult Edit(int? id)
        {
            CountMessage();
            CountProduct();
            CountOrder();
            if (id == null)
            {
                return BadRequest();
            }
            Contact contact = _serviceWrapper.Db.Contact.Find(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }



        // POST: Admin/Contacts/Edit/5

        [HasCredential(RoleId = "VIEW_LAYOUT")]        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                var userLoginSession = HttpContext.Session.Get<UserLogin>(CommonConstants.USER_LOGIN_SESSION);
                AuditTable.UpdateAuditFields(contact, userLoginSession.UserName);
                _serviceWrapper.Db.Entry(contact).State = EntityState.Modified;
                _serviceWrapper.Db.SaveChanges();
                SetAlert("Cập nhật thành công", "success");
                return Redirect("/quan-tri/thong-tin-cua-hang");
            }
            return View(contact);
        }



        // GET: Admin/Contacts/Delete/5
        [HasCredential(RoleId = "VIEW_LAYOUT")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Contact contact = _serviceWrapper.Db.Contact.Find(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }



        // POST: Admin/Contacts/Delete/5
        [HasCredential(RoleId = "VIEW_LAYOUT")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = _serviceWrapper.Db.Contact.Find(id);
            contact.IsDeleted = true;
            _serviceWrapper.Db.SaveChanges();
            SetAlert("Xóa thành công", "success");
            return Redirect("/quan-tri/thong-tin-cua-hang");
        }

    }
}
