using LaptopShopOnline.Common;
using LaptopShopOnline.Model;
using LaptopShopOnline.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopShopOnline.Service.Implement
{
    public class UserService : IUserService
    {
        private readonly LaptopShopOnlineDbContext _db;

        public UserService(LaptopShopOnlineDbContext dbContext)
        {
            _db = dbContext;
        }



        public int Login(string userName, string password, bool isLoginAdmin = false)
        {
            var result = _db.User.SingleOrDefault(x => x.UserName == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (isLoginAdmin == true)
                {
                    if (result.GroupId == CommonConstants.ADMIN_GROUP || result.GroupId == CommonConstants.MOD_GROUP)
                    {
                        if (result.IsDeleted == true)
                        {
                            return -1;
                        }
                        else
                        {
                            if (result.Password == password)
                                return 1;
                            else
                                return -2;
                        }
                    }
                    else
                    {
                        return -3;
                    }
                }
                else
                {
                    if (result.GroupId == CommonConstants.MEMBER_GROUP)
                    {
                        if (result.IsDeleted == true)
                        {
                            return -1;
                        }
                        else
                        {
                            if (result.Password == password)
                                return 1;
                            else
                                return -2;
                        }
                    }
                    else
                    {
                        return -3;
                    }
                }
            }
        }



        public User GetByName(string userName)
        {
            return _db.User.OrderByDescending(x => x.CreatedOn).SingleOrDefault(x => x.UserName == userName);
        }



        public List<string> GetListCredential(string userName)
        {
            var user = _db.User.Single(x => x.UserName == userName);
            var data = (from a in _db.Credentials
                        join b in _db.UserGroup on a.UserGroupId equals b.Id
                        join c in _db.Role on a.RoleId equals c.Id
                        where b.Id == user.GroupId
                        select new
                        {
                            RoleId = a.RoleId,
                            UserGroupId = a.UserGroupId
                        }).AsEnumerable().Select(x => new Credential()
                        {
                            RoleId = x.RoleId,
                            UserGroupId = x.UserGroupId
                        });
            return data.Select(x => x.RoleId).ToList();
        }



        public bool CheckUserName(string userName)
        {
            return _db.User.Count(x => x.UserName == userName) > 0;
        }



        public bool CheckEmail(string email)
        {
            return _db.User.Count(x => x.Email == email) > 0;
        }



        public bool ChangeStatus(Guid? id)
        {
            var user = _db.User.Find(id);
            user.IsDeleted = !user.IsDeleted;
            _db.SaveChanges();
            return user.IsDeleted;
        }
    }
}
