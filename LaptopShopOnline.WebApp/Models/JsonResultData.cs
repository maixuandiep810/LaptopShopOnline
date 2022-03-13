using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LaptopShopOnline.WebApp.Models
{
    public class JsonResultData<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
    }
}