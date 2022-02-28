using LaptopShopOnline.Model.Entities;
using LaptopShopOnline.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopShopOnline.WebApp.Controllers.Shared.Components
{
    public class ContactViewComponent : ViewComponent
    {
        private readonly ServiceWrapper _serviceWrapper;

        public ContactViewComponent(ServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }

        public IViewComponentResult Invoke()
        {
            List<Contact> contacts = new List<Contact>();
            contacts = _serviceWrapper.Db.Contact.Where(x => x.IsDeleted == false).ToList();
            ViewBag.Count = contacts.Count();
            return View("Contact", contacts);
        }
    }
}