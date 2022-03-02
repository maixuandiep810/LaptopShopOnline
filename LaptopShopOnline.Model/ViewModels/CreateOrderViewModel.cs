using LaptopShopOnline.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopShopOnline.Model.ViewModels
{
    public class CreateOrderViewModel
    {
        public Order Order { get; set; }
        public List<Cart> Carts { get; set; }
    }
}
