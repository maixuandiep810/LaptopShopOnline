using LaptopShopOnline.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopShopOnline.Service
{
    public interface IUserService
    {
        int Login(string userName, string password, string loginAsUserGroupId);
        User GetByName(string userName);
        List<string> GetListCredential(string userName);
        bool CheckUserName(string userName);
        bool CheckEmail(string email);
        bool ChangeStatus(Guid? id);
    }
}
