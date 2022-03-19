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



    public class RolesController : BaseController
    {



        public RolesController(ServiceWrapper serviceWrapper) : base(serviceWrapper)
        {

        }






        // GET: Admin/Roles
        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_SYS_READ_ID)]
        public ActionResult Index()
        {
            CountMessage();
            CountOrder();
            CountProduct();

            return View(_serviceWrapper.Db.Role.ToList());
        }

        // GET: Admin/Roles/Details/5
        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_SYS_READ_ID)]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Role role = _serviceWrapper.Db.Role.Find(id);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }


        // GET: Admin/Roles/Edit/5
        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_SYS_UPDATE_ID)]
        public ActionResult Edit(string id)
        {
            CountMessage();
            CountOrder();
            CountProduct();
            if (id == null)
            {
                return BadRequest();
            }
            Role role = _serviceWrapper.Db.Role.Find(id);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }
        // POST: Admin/Roles/Edit/5

        [HasCredential(RoleId = CommonConstants.MANAGER_ROLE_SYS_UPDATE_ID)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Role role)
        {
            if (ModelState.IsValid)
            {
                _serviceWrapper.Db.Entry(role).State = EntityState.Modified;
                _serviceWrapper.Db.SaveChanges();
                SetAlert("Cập nhật thành công", "success");
                return Redirect(CommonConstants.ROUTE_QUAN_TRI_QUYEN_PARAMS);
            }
            return View(role);
        }
    }
}
