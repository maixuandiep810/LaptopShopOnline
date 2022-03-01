using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopShopOnline.Common
{
    public static class CommonConstants
    {
        public const string USER_LOGIN_SESSION = "USER_SESSION";
        public const string CART_SESSION = "CART_SESSION";
        public const string CREDENTIALS_SESSION = "CREDENTIALS_SESSION";

        public const string BUYER_GROUP = "BUYER";
        public const string ADMIN_GROUP = "ADMIN";
        public const string MOD_GROUP = "MOD";
        public const string SELLER_GROUP = "SELLER";
        public static List<string> ADMIN_AREA_GROUP_ID = (new string[] { "ADMIN", "MOD", "SELLER" }).ToList();

        public const string SELLER_ROLE_ID = "SELLER_ROLE";

    }
}
