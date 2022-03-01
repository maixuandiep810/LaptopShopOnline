using LaptopShopOnline.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopShopOnline.Service
{
    public interface IOrderService
    {
        void ChangeOrderStatus(Guid? id, int orderStatus);
    }
}
