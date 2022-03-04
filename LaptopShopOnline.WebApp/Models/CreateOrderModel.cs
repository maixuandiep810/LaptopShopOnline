using LaptopShopOnline.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopShopOnline.WebApp.Models
{
    public class CreateOrderModel
    {
        public Order Order { get; set; }
        public List<Cart> Carts { get; set; }
    }
}
