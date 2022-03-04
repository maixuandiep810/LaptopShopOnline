using System.Collections.Generic;
using System.Linq;

namespace LaptopShopOnline.Common
{
    public static class CommonConstants
    {
        public const string USER_LOGIN_SESSION = "USER_SESSION";
        public const string CART_SESSION = "CART_SESSION";
        public const string CREDENTIALS_SESSION = "CREDENTIALS_SESSION";

        public const string USER_GROUP_ID_PREFIX_BUYER = "BUYER";
        public const string USER_GROUP_ID_PREFIX_MANAGER = "MANAGER";
        public const string USER_GROUP_ID_PREFIX_SELLER = "SELLER";
        public static List<string> _USER_GROUP_ID_PREFIX_ADMIN_AREA_LIST = (new string[] { "MANAGER", "SELLER" }).ToList();

        public const string MANAGER_ROLE_AUTH_VIEW_ID = "MANAGER_ROLE_AUTH_VIEW";
        public const string MANAGER_ROLE_AUTH_CREATE_ID = "MANAGER_ROLE_AUTH_CREATE";
        public const string MANAGER_ROLE_AUTH_UPDATE_ID = "MANAGER_ROLE_AUTH_UPDATE";
        public const string MANAGER_ROLE_AUTH_DELETE_ID = "MANAGER_ROLE_AUTH_DELETE";

        public const string MANAGER_ROLE_LAYOUT_VIEW_ID = "MANAGER_ROLE_LAYOUT_VIEW";
        public const string MANAGER_ROLE_LAYOUT_CREATE_ID = "MANAGER_ROLE_LAYOUT_CREATE";
        public const string MANAGER_ROLE_LAYOUT_UPDATE_ID = "MANAGER_ROLE_LAYOUT_UPDATE";
        public const string MANAGER_ROLE_LAYOUT_DELETE_ID = "MANAGER_ROLE_LAYOUT_DELETE";

        public const string MANAGER_ROLE_SHOP_VIEW_ID = "MANAGER_ROLE_SHOP_VIEW";
        public const string MANAGER_ROLE_SHOP_CREATE_ID = "MANAGER_ROLE_SHOP_CREATE";
        public const string MANAGER_ROLE_SHOP_UPDATE_ID = "MANAGER_ROLE_SHOP_UPDATE";
        public const string MANAGER_ROLE_SHOP_DELETE_ID = "MANAGER_ROLE_SHOP_DELETE";

        public const string SELLER_ROLE_VIEW_ID = "SELLER_ROLE_VIEW";
        public const string SELLER_ROLE_CREATE_ID = "SELLER_ROLE_CREATE";
        public const string SELLER_ROLE_UPDATE_ID = "SELLER_ROLE_UPDATE";
        public const string SELLER_ROLE_DELETE_ID = "SELLER_ROLE_DELETE";

        public const string BUYER_ROLE_VIEW_ID = "BUYER_ROLE_VIEW";
        public const string BUYER_ROLE_CREATE_ID = "BUYER_ROLE_CREATE";
        public const string BUYER_ROLE_UPDATE_ID = "BUYER_ROLE_UPDATE";
        public const string BUYER_ROLE_DELETE_ID = "BUYER_ROLE_DELETE";





        //
        public const string ROUTE_QUAN_TRI = "/quan-tri/";
        public const string ROUTE_QUAN_TRI_DANG_NHAP = "/quan-tri/dang-nhap";
        public const string ROUTE_QUAN_TRI_DANG_XUAT = "/quan-tri/dang-xuat";

        public const string ROUTE_QUAN_TRI_PARAMS = "/quan-tri/";
        public const string ROUTE_QUAN_TRI_DANG_NHAP_PARAMS = "/quan-tri/dang-nhap";
        public const string ROUTE_QUAN_TRI_DANG_XUAT_PARAMS = "/quan-tri/dang-xuat";

        //
        public const string ROUTE_QUAN_TRI_QUYEN = "/quan-tri/quyen";
        public const string ROUTE_QUAN_TRI_QUYEN_CHI_TIET = "/quan-tri/quyen/chi-tiet/{id}";
        public const string ROUTE_QUAN_TRI_QUYEN_CAP_NHAT = "/quan-tri/quyen/cap-nhat/{id}";

        public const string ROUTE_QUAN_TRI_QUYEN_PARAMS = "/quan-tri/quyen";
        public const string ROUTE_QUAN_TRI_QUYEN_CHI_TIET_PARAMS = "/quan-tri/quyen/chi-tiet/{id}";
        public const string ROUTE_QUAN_TRI_QUYEN_CAP_NHAT_PARAMS = "/quan-tri/quyen/cap-nhat/{id}";

        //
        public const string ROUTE_QUAN_TRI_NHOM_NGUOI_DUNG = "/quan-tri/nhom-nguoi-dung";
        public const string ROUTE_QUAN_TRI_NHOM_NGUOI_DUNG_CHI_TIET = "/quan-tri/nhom-nguoi-dung/chi-tiet/{id}";
        public const string ROUTE_QUAN_TRI_NHOM_NGUOI_DUNG_THEM_MOI = "/quan-tri/nhom-nguoi-dung/them-moi";
        public const string ROUTE_QUAN_TRI_NHOM_NGUOI_DUNG_CAP_NHAT = "/quan-tri/nhom-nguoi-dung/cap-nhat/{id}";
        public const string ROUTE_QUAN_TRI_NHOM_NGUOI_DUNG_XOA = "/quan-tri/nhom-nguoi-dung/xoa/{id}";

        public const string ROUTE_QUAN_TRI_NHOM_NGUOI_DUNG_PARAMS = "/quan-tri/nhom-nguoi-dung";
        public const string ROUTE_QUAN_TRI_NHOM_NGUOI_DUNG_CHI_TIET_PARAMS = "/quan-tri/nhom-nguoi-dung/chi-tiet/{id}";
        public const string ROUTE_QUAN_TRI_NHOM_NGUOI_DUNG_THEM_MOI_PARAMS = "/quan-tri/nhom-nguoi-dung/them-moi";
        public const string ROUTE_QUAN_TRI_NHOM_NGUOI_DUNG_CAP_NHAT_PARAMS = "/quan-tri/nhom-nguoi-dung/cap-nhat/{id}";
        public const string ROUTE_QUAN_TRI_NHOM_NGUOI_DUNG_XOA_PARAMS = "/quan-tri/nhom-nguoi-dung/xoa/{id}";

        //
        public const string ROUTE_QUAN_TRI_PHAN_QUYEN = "/quan-tri/phan-quyen";
        public const string ROUTE_QUAN_TRI_PHAN_QUYEN_NHOM_NGUOI_DUNG = "/quan-tri/phan-quyen/nhom-nguoi-dung/{userGroupId}";
        public const string ROUTE_QUAN_TRI_PHAN_QUYEN_CHI_TIET = "/quan-tri/phan-quyen/chi-tiet";
        public const string ROUTE_QUAN_TRI_PHAN_QUYEN_THEM_MOI = "/quan-tri/phan-quyen/them-moi";
        public const string ROUTE_QUAN_TRI_PHAN_QUYEN_NHOM_NGUOI_DUNG_THEM_MOI = "/quan-tri/phan-quyen/nhom-nguoi-dung/them-moi/{userGroupId}";
        public const string ROUTE_QUAN_TRI_PHAN_QUYEN_XOA = "/quan-tri/phan-quyen/xoa";

        //
        public const string ROUTE_QUAN_TRI_PHAN_QUYEN_PARAMS = "/quan-tri/phan-quyen";
        public const string ROUTE_QUAN_TRI_PHAN_QUYEN_NHOM_NGUOI_DUNG_PARAMS = "/quan-tri/phan-quyen/nhom-nguoi-dung/{userGroupId}";
        public const string ROUTE_QUAN_TRI_PHAN_QUYEN_CHI_TIET_PARAMS = "/quan-tri/phan-quyen/chi-tiet?userGroupId={userGroupId}&roleId={roleId}";
        public const string ROUTE_QUAN_TRI_PHAN_QUYEN_NHOM_NGUOI_DUNG_THEM_MOI_PARAMS = "/quan-tri/phan-quyen/nhom-nguoi-dung/them-moi/{userGroupId}";
        public const string ROUTE_QUAN_TRI_PHAN_QUYEN_THEM_MOI_PARAMS = "/quan-tri/phan-quyen/them-moi";
        public const string ROUTE_QUAN_TRI_PHAN_QUYEN_XOA_PARAMS = "/quan-tri/phan-quyen/xoa?userGroupId={userGroupId}&roleId={roleId}";


        //{id:regex(^[{ {]?[0 - 9a - fA - F]{ { 8} } -([0 - 9a - fA - F]{ { 4} } -){ { 3} }[0 - 9a - fA - F]{ { 12} }[} }]?$)?}";

    }
}
