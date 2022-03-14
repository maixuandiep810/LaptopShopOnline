using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace LaptopShopOnline.Common
{
    public static class CommonConstants
    {
        public const string USER_LOGIN_SESSION = "USER_SESSION";
        public const string CREDENTIALS_SESSION = "CREDENTIALS_SESSION";

        public const string USER_GROUP_ID_PREFIX_BUYER = "BUYER";
        public const string USER_GROUP_ID_PREFIX_MANAGER = "MANAGER";
        public const string USER_GROUP_ID_PREFIX_SELLER = "SELLER";
        public static List<string> _USER_GROUP_ID_PREFIX_ADMIN_AREA_LIST = (new string[] { "MANAGER", "SELLER" }).ToList();

        public const string MANAGER_ROLE_SYS_READ_ID = "MANAGER_ROLE_SYS_READ";
        public const string MANAGER_ROLE_SYS_CREATE_ID = "MANAGER_ROLE_SYS_CREATE";
        public const string MANAGER_ROLE_SYS_UPDATE_ID = "MANAGER_ROLE_SYS_UPDATE";
        public const string MANAGER_ROLE_SYS_DELETE_ID = "MANAGER_ROLE_SYS_DELETE";

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
        //
        public const string ROUTE_QUAN_TRI_PARAMS = "/quan-tri/";
        public const string ROUTE_QUAN_TRI_DANG_NHAP_PARAMS = "/quan-tri/dang-nhap";
        public const string ROUTE_QUAN_TRI_DANG_XUAT_PARAMS = "/quan-tri/dang-xuat";



        //
        public const string ROUTE_QUAN_TRI_QUYEN = "/quan-tri/quyen";
        public const string ROUTE_QUAN_TRI_QUYEN_CHI_TIET = "/quan-tri/quyen/chi-tiet/{id}";
        public const string ROUTE_QUAN_TRI_QUYEN_CAP_NHAT = "/quan-tri/quyen/cap-nhat/{id}";
        //
        public const string ROUTE_QUAN_TRI_QUYEN_PARAMS = "/quan-tri/quyen";
        public const string ROUTE_QUAN_TRI_QUYEN_CHI_TIET_PARAMS = "/quan-tri/quyen/chi-tiet/{id}";
        public const string ROUTE_QUAN_TRI_QUYEN_CAP_NHAT_PARAMS = "/quan-tri/quyen/cap-nhat/{id}";




        //
        public const string ROUTE_QUAN_TRI_NHOM_NGUOI_DUNG = "/quan-tri/nhom-nguoi-dung";
        public const string ROUTE_QUAN_TRI_NHOM_NGUOI_DUNG_CHI_TIET = "/quan-tri/nhom-nguoi-dung/chi-tiet/{id}";
        public const string ROUTE_QUAN_TRI_NHOM_NGUOI_DUNG_THEM_MOI = "/quan-tri/nhom-nguoi-dung/them-moi";
        public const string ROUTE_QUAN_TRI_NHOM_NGUOI_DUNG_CAP_NHAT = "/quan-tri/nhom-nguoi-dung/cap-nhat/{id}";
        public const string ROUTE_QUAN_TRI_NHOM_NGUOI_DUNG_XOA = "/quan-tri/nhom-nguoi-dung/xoa/{id}";
        //
        public const string ROUTE_QUAN_TRI_NHOM_NGUOI_DUNG_PARAMS = "/quan-tri/nhom-nguoi-dung";
        public const string ROUTE_QUAN_TRI_NHOM_NGUOI_DUNG_CHI_TIET_PARAMS = "/quan-tri/nhom-nguoi-dung/chi-tiet/{id}";
        public const string ROUTE_QUAN_TRI_NHOM_NGUOI_DUNG_THEM_MOI_PARAMS = "/quan-tri/nhom-nguoi-dung/them-moi";
        public const string ROUTE_QUAN_TRI_NHOM_NGUOI_DUNG_CAP_NHAT_PARAMS = "/quan-tri/nhom-nguoi-dung/cap-nhat/{id}";
        public const string ROUTE_QUAN_TRI_NHOM_NGUOI_DUNG_XOA_PARAMS = "/quan-tri/nhom-nguoi-dung/xoa/{id}";



        //
        public const string ROUTE_QUAN_TRI_PHAN_QUYEN = "/quan-tri/phan-quyen";
        public const string ROUTE_QUAN_TRI_PHAN_QUYEN_CHI_TIET = "/quan-tri/phan-quyen/chi-tiet";
        public const string ROUTE_QUAN_TRI_PHAN_QUYEN_THEM_MOI = "/quan-tri/phan-quyen/them-moi";
        public const string ROUTE_QUAN_TRI_PHAN_QUYEN_XOA = "/quan-tri/phan-quyen/xoa";
        //
        public const string ROUTE_QUAN_TRI_PHAN_QUYEN_PARAMS = "/quan-tri/phan-quyen";
        public const string ROUTE_QUAN_TRI_PHAN_QUYEN_CHI_TIET_PARAMS = "/quan-tri/phan-quyen/chi-tiet?userGroupId={userGroupId}&roleId={roleId}";
        public const string ROUTE_QUAN_TRI_PHAN_QUYEN_THEM_MOI_PARAMS = "/quan-tri/phan-quyen/them-moi";
        public const string ROUTE_QUAN_TRI_PHAN_QUYEN_XOA_PARAMS = "/quan-tri/phan-quyen/xoa?userGroupId={userGroupId}&roleId={roleId}";



        //
        public const string ROUTE_QUAN_TRI_TAI_KHOAN_NGUOI_DUNG = "/quan-tri/tai-khoan-nguoi-dung";
        public const string ROUTE_QUAN_TRI_TAI_KHOAN_NGUOI_DUNG_CHI_TIET = "/quan-tri/tai-khoan-nguoi-dung/chi-tiet/{id:regex(^[{{]?[0-9a-fA-F]{{8}}-([0-9a-fA-F]{{4}}-){{3}}[0-9a-fA-F]{{12}}[}}]?$)?}";
        public const string ROUTE_QUAN_TRI_TAI_KHOAN_NGUOI_DUNG_CAP_NHAT = "/quan-tri/tai-khoan-nguoi-dung/cap-nhat/{id:regex(^[{{]?[0-9a-fA-F]{{8}}-([0-9a-fA-F]{{4}}-){{3}}[0-9a-fA-F]{{12}}[}}]?$)?}";
        public const string ROUTE_QUAN_TRI_TAI_KHOAN_NGUOI_DUNG_THEM_MOI = "/quan-tri/tai-khoan-nguoi-dung/them-moi";
        public const string ROUTE_QUAN_TRI_TAI_KHOAN_NGUOI_DUNG_XOA = "/quan-tri/tai-khoan-nguoi-dung/xoa/{id:regex(^[{{]?[0-9a-fA-F]{{8}}-([0-9a-fA-F]{{4}}-){{3}}[0-9a-fA-F]{{12}}[}}]?$)?}";
        //
        public const string ROUTE_QUAN_TRI_TAI_KHOAN_NGUOI_DUNG_PARAMS = "/quan-tri/tai-khoan-nguoi-dung";
        public const string ROUTE_QUAN_TRI_TAI_KHOAN_NGUOI_DUNG_SEARCH_PARAMS = "/quan-tri/tai-khoan-nguoi-dung?sortOrder={sortOrder}&searchString={searchString}&page={page}";
        public const string ROUTE_QUAN_TRI_TAI_KHOAN_NGUOI_DUNG_CHI_TIET_PARAMS = "/quan-tri/tai-khoan-nguoi-dung/chi-tiet/{id}";
        public const string ROUTE_QUAN_TRI_TAI_KHOAN_NGUOI_DUNG_CAP_NHAT_PARAMS = "/quan-tri/tai-khoan-nguoi-dung/cap-nhat/{id}";
        public const string ROUTE_QUAN_TRI_TAI_KHOAN_NGUOI_DUNG_THEM_MOI_PARAMS = "/quan-tri/tai-khoan-nguoi-dung/them-moi";
        public const string ROUTE_QUAN_TRI_TAI_KHOAN_NGUOI_DUNG_XOA_PARAMS = "/quan-tri/tai-khoan-nguoi-dung/xoa/{id}";



        //
        public const string ROUTE_QUAN_TRI_DANH_MUC_SAN_PHAM = "/quan-tri/danh-muc-san-pham";
        public const string ROUTE_QUAN_TRI_DANH_MUC_SAN_PHAM_CHI_TIET = "/quan-tri/danh-muc-san-pham/chi-tiet/{id:regex(^[{{]?[0-9a-fA-F]{{8}}-([0-9a-fA-F]{{4}}-){{3}}[0-9a-fA-F]{{12}}[}}]?$)?}";
        public const string ROUTE_QUAN_TRI_DANH_MUC_SAN_PHAM_CAP_NHAT = "/quan-tri/danh-muc-san-pham/cap-nhat/{id:regex(^[{{]?[0-9a-fA-F]{{8}}-([0-9a-fA-F]{{4}}-){{3}}[0-9a-fA-F]{{12}}[}}]?$)?}";
        public const string ROUTE_QUAN_TRI_DANH_MUC_SAN_PHAM_THEM_MOI = "/quan-tri/danh-muc-san-pham/them-moi";
        public const string ROUTE_QUAN_TRI_DANH_MUC_SAN_PHAM_XOA = "/quan-tri/danh-muc-san-pham/xoa/{id:regex(^[{{]?[0-9a-fA-F]{{8}}-([0-9a-fA-F]{{4}}-){{3}}[0-9a-fA-F]{{12}}[}}]?$)?}";
        //
        public const string ROUTE_QUAN_TRI_DANH_MUC_SAN_PHAM_PARAMS = "/quan-tri/danh-muc-san-pham";
        public const string ROUTE_QUAN_TRI_DANH_MUC_SAN_PHAM_CHI_TIET_PARAMS = "/quan-tri/danh-muc-san-pham/chi-tiet/{id}";
        public const string ROUTE_QUAN_TRI_DANH_MUC_SAN_PHAM_CAP_NHAT_PARAMS = "/quan-tri/danh-muc-san-pham/cap-nhat/{id}";
        public const string ROUTE_QUAN_TRI_DANH_MUC_SAN_PHAM_THEM_MOI_PARAMS = "/quan-tri/danh-muc-san-pham/them-moi";
        public const string ROUTE_QUAN_TRI_DANH_MUC_SAN_PHAM_XOA_PARAMS = "/quan-tri/danh-muc-san-pham/xoa/{id}";



        //
        public const string ROUTE_QUAN_TRI_CUA_HANG = "/quan-tri/cua-hang";
        public const string ROUTE_QUAN_TRI_CUA_HANG_CHI_TIET = "/quan-tri/cua-hang/chi-tiet/{id:regex(^[{{]?[0-9a-fA-F]{{8}}-([0-9a-fA-F]{{4}}-){{3}}[0-9a-fA-F]{{12}}[}}]?$)?}";
        public const string ROUTE_QUAN_TRI_CUA_HANG_CAP_NHAT = "/quan-tri/cua-hang/cap-nhat/{id:regex(^[{{]?[0-9a-fA-F]{{8}}-([0-9a-fA-F]{{4}}-){{3}}[0-9a-fA-F]{{12}}[}}]?$)?}";
        public const string ROUTE_QUAN_TRI_CUA_HANG_THEM_MOI = "/quan-tri/cua-hang/them-moi";
        public const string ROUTE_QUAN_TRI_CUA_HANG_XOA = "/quan-tri/cua-hang/xoa/{id:regex(^[{{]?[0-9a-fA-F]{{8}}-([0-9a-fA-F]{{4}}-){{3}}[0-9a-fA-F]{{12}}[}}]?$)?}";
        public const string ROUTE_QUAN_TRI_NGUOI_BAN_CUA_HANG_CAP_NHAT = "/quan-tri/nguoi-ban/cua-hang/cap-nhat";
        //
        public const string ROUTE_QUAN_TRI_CUA_HANG_PARAMS = "/quan-tri/cua-hang";
        public const string ROUTE_QUAN_TRI_CUA_HANG_SEARCH_PARAMS = "/quan-tri/cua-hang?sortOrder={sortOrder}&searchString={searchString}&page={page}";
        public const string ROUTE_QUAN_TRI_CUA_HANG_CHI_TIET_PARAMS = "/quan-tri/cua-hang/chi-tiet/{id}";
        public const string ROUTE_QUAN_TRI_CUA_HANG_CAP_NHAT_PARAMS = "/quan-tri/cua-hang/cap-nhat/{id}";
        public const string ROUTE_QUAN_TRI_CUA_HANG_THEM_MOI_PARAMS = "/quan-tri/cua-hang/them-moi";
        public const string ROUTE_QUAN_TRI_CUA_HANG_XOA_PARAMS = "/quan-tri/cua-hang/xoa/{id}";
        public const string ROUTE_QUAN_TRI_NGUOI_BAN_CUA_HANG_CAP_NHAT_PARAMS = "/quan-tri/nguoi-ban/cua-hang/cap-nhat";




        //
        public const string ROUTE_QUAN_TRI_SAN_PHAM = "/quan-tri/san-pham";
        public const string ROUTE_QUAN_TRI_SAN_PHAM_CHI_TIET = "/quan-tri/san-pham/chi-tiet/{id:regex(^[{{]?[0-9a-fA-F]{{8}}-([0-9a-fA-F]{{4}}-){{3}}[0-9a-fA-F]{{12}}[}}]?$)?}";
        public const string ROUTE_QUAN_TRI_SAN_PHAM_CAP_NHAT = "/quan-tri/san-pham/cap-nhat/{id:regex(^[{{]?[0-9a-fA-F]{{8}}-([0-9a-fA-F]{{4}}-){{3}}[0-9a-fA-F]{{12}}[}}]?$)?}";
        public const string ROUTE_QUAN_TRI_SAN_PHAM_THEM_MOI = "/quan-tri/san-pham/them-moi";
        public const string ROUTE_QUAN_TRI_SAN_PHAM_XOA = "/quan-tri/san-pham/xoa/{id:regex(^[{{]?[0-9a-fA-F]{{8}}-([0-9a-fA-F]{{4}}-){{3}}[0-9a-fA-F]{{12}}[}}]?$)?}";
        //
        public const string ROUTE_QUAN_TRI_SAN_PHAM_PARAMS = "/quan-tri/san-pham";
        public const string ROUTE_QUAN_TRI_SAN_PHAM_SEARCH_PARAMS = "/quan-tri/san-pham?sortOrder={sortOrder}&searchString={searchString}&page={page}";
        public const string ROUTE_QUAN_TRI_SAN_PHAM_CHI_TIET_PARAMS = "/quan-tri/san-pham/chi-tiet/{id}";
        public const string ROUTE_QUAN_TRI_SAN_PHAM_CAP_NHAT_PARAMS = "/quan-tri/san-pham/cap-nhat/{id}";
        public const string ROUTE_QUAN_TRI_SAN_PHAM_THEM_MOI_PARAMS = "/quan-tri/san-pham/them-moi";
        public const string ROUTE_QUAN_TRI_SAN_PHAM_XOA_PARAMS = "/quan-tri/san-pham/xoa/{id}";



        //
        public const string ROUTE_QUAN_TRI_NGUOI_BAN_SAN_PHAM = "/quan-tri/nguoi-ban/san-pham";
        public const string ROUTE_QUAN_TRI_NGUOI_BAN_SAN_PHAM_CHI_TIET = "/quan-tri/nguoi-ban/san-pham/chi-tiet/{id:regex(^[{{]?[0-9a-fA-F]{{8}}-([0-9a-fA-F]{{4}}-){{3}}[0-9a-fA-F]{{12}}[}}]?$)?}";
        public const string ROUTE_QUAN_TRI_NGUOI_BAN_SAN_PHAM_CAP_NHAT = "/quan-tri/nguoi-ban/san-pham/cap-nhat/{id:regex(^[{{]?[0-9a-fA-F]{{8}}-([0-9a-fA-F]{{4}}-){{3}}[0-9a-fA-F]{{12}}[}}]?$)?}";
        public const string ROUTE_QUAN_TRI_NGUOI_BAN_SAN_PHAM_THEM_MOI = "/quan-tri/nguoi-ban/san-pham/them-moi";
        public const string ROUTE_QUAN_TRI_NGUOI_BAN_SAN_PHAM_XOA = "/quan-tri/nguoi-ban/san-pham/xoa/{id:regex(^[{{]?[0-9a-fA-F]{{8}}-([0-9a-fA-F]{{4}}-){{3}}[0-9a-fA-F]{{12}}[}}]?$)?}";
        //
        public const string ROUTE_QUAN_TRI_NGUOI_BAN_SAN_PHAM_PARAMS = "/quan-tri/nguoi-ban/san-pham";
        public const string ROUTE_QUAN_TRI_NGUOI_BAN_SAN_PHAM_SEARCH_PARAMS = "/quan-tri/nguoi-ban/san-pham?sortOrder={sortOrder}&searchString={searchString}&page={page}";
        public const string ROUTE_QUAN_TRI_NGUOI_BAN_SAN_PHAM_CHI_TIET_PARAMS = "/quan-tri/nguoi-ban/san-pham/chi-tiet/{id}";
        public const string ROUTE_QUAN_TRI_NGUOI_BAN_SAN_PHAM_CAP_NHAT_PARAMS = "/quan-tri/nguoi-ban/san-pham/cap-nhat/{id}";
        public const string ROUTE_QUAN_TRI_NGUOI_BAN_SAN_PHAM_THEM_MOI_PARAMS = "/quan-tri/nguoi-ban/san-pham/them-moi";
        public const string ROUTE_QUAN_TRI_NGUOI_BAN_SAN_PHAM_XOA_PARAMS = "/quan-tri/nguoi-ban/san-pham/xoa/{id}";




        //
        public const string ROUTE_QUAN_TRI_DON_HANG = "/quan-tri/don-hang";
        public const string ROUTE_QUAN_TRI_DON_HANG_CHI_TIET = "/quan-tri/don-hang/chi-tiet/{id:regex(^[{{]?[0-9a-fA-F]{{8}}-([0-9a-fA-F]{{4}}-){{3}}[0-9a-fA-F]{{12}}[}}]?$)?}";
        public const string ROUTE_QUAN_TRI_DON_HANG_CAP_NHAT = "/quan-tri/don-hang/cap-nhat/{id:regex(^[{{]?[0-9a-fA-F]{{8}}-([0-9a-fA-F]{{4}}-){{3}}[0-9a-fA-F]{{12}}[}}]?$)?}";
        public const string ROUTE_QUAN_TRI_DON_HANG_THEM_MOI = "/quan-tri/don-hang/them-moi";
        public const string ROUTE_QUAN_TRI_DON_HANG_XOA = "/quan-tri/don-hang/xoa/{id:regex(^[{{]?[0-9a-fA-F]{{8}}-([0-9a-fA-F]{{4}}-){{3}}[0-9a-fA-F]{{12}}[}}]?$)?}";
        //
        public const string ROUTE_QUAN_TRI_DON_HANG_PARAMS = "/quan-tri/don-hang";
        public const string ROUTE_QUAN_TRI_DON_HANG_SEARCH_PARAMS = "/quan-tri/don-hang?sortOrder={sortOrder}&searchString={searchString}&page={page}&orderStatus={orderStatus}";
        public const string ROUTE_QUAN_TRI_DON_HANG_CHI_TIET_PARAMS = "/quan-tri/don-hang/chi-tiet/{id}";
        public const string ROUTE_QUAN_TRI_DON_HANG_CAP_NHAT_PARAMS = "/quan-tri/don-hang/cap-nhat/{id}";
        public const string ROUTE_QUAN_TRI_DON_HANG_THEM_MOI_PARAMS = "/quan-tri/don-hang/them-moi";
        public const string ROUTE_QUAN_TRI_DON_HANG_XOA_PARAMS = "/quan-tri/don-hang/xoa/{id}";



        //
        public const string ROUTE_QUAN_TRI_NGUOI_BAN_DON_HANG = "/quan-tri/nguoi-ban/don-hang";
        public const string ROUTE_QUAN_TRI_NGUOI_BAN_DON_HANG_CHI_TIET = "/quan-tri/nguoi-ban/don-hang/chi-tiet/{id:regex(^[{{]?[0-9a-fA-F]{{8}}-([0-9a-fA-F]{{4}}-){{3}}[0-9a-fA-F]{{12}}[}}]?$)?}";
        public const string ROUTE_QUAN_TRI_NGUOI_BAN_DON_HANG_CAP_NHAT = "/quan-tri/nguoi-ban/don-hang/cap-nhat/{id:regex(^[{{]?[0-9a-fA-F]{{8}}-([0-9a-fA-F]{{4}}-){{3}}[0-9a-fA-F]{{12}}[}}]?$)?}";
        public const string ROUTE_QUAN_TRI_NGUOI_BAN_DON_HANG_THEM_MOI = "/quan-tri/nguoi-ban/don-hang/them-moi";
        public const string ROUTE_QUAN_TRI_NGUOI_BAN_DON_HANG_XOA = "/quan-tri/nguoi-ban/don-hang/xoa/{id:regex(^[{{]?[0-9a-fA-F]{{8}}-([0-9a-fA-F]{{4}}-){{3}}[0-9a-fA-F]{{12}}[}}]?$)?}";
        //
        public const string ROUTE_QUAN_TRI_NGUOI_BAN_DON_HANG_PARAMS = "/quan-tri/nguoi-ban/don-hang";
        public const string ROUTE_QUAN_TRI_NGUOI_BAN_DON_HANG_SEARCH_PARAMS = "/quan-tri/nguoi-ban/don-hang?sortOrder={sortOrder}&searchString={searchString}&page={page}&orderStatus={orderStatus}";
        public const string ROUTE_QUAN_TRI_NGUOI_BAN_DON_HANG_CHI_TIET_PARAMS = "/quan-tri/nguoi-ban/don-hang/chi-tiet/{id}";
        public const string ROUTE_QUAN_TRI_NGUOI_BAN_DON_HANG_CAP_NHAT_PARAMS = "/quan-tri/nguoi-ban/don-hang/cap-nhat/{id}";
        public const string ROUTE_QUAN_TRI_NGUOI_BAN_DON_HANG_THEM_MOI_PARAMS = "/quan-tri/nguoi-ban/don-hang/them-moi";
        public const string ROUTE_QUAN_TRI_NGUOI_BAN_DON_HANG_XOA_PARAMS = "/quan-tri/nguoi-ban/don-hang/xoa/{id}";



        //
        public const string ROUTE_QUAN_TRI_CHI_TIET_DON_HANG = "/quan-tri/chi-tiet-don-hang/{orderId}";
        public const string ROUTE_QUAN_TRI_CHI_TIET_DON_HANG_CHI_TIET = "/quan-tri/chi-tiet-don-hang/chi-tiet/{id:regex(^[{{]?[0-9a-fA-F]{{8}}-([0-9a-fA-F]{{4}}-){{3}}[0-9a-fA-F]{{12}}[}}]?$)?}";
        public const string ROUTE_QUAN_TRI_CHI_TIET_DON_HANG_CAP_NHAT = "/quan-tri/chi-tiet-don-hang/cap-nhat/{id:regex(^[{{]?[0-9a-fA-F]{{8}}-([0-9a-fA-F]{{4}}-){{3}}[0-9a-fA-F]{{12}}[}}]?$)?}";
        public const string ROUTE_QUAN_TRI_CHI_TIET_DON_HANG_THEM_MOI = "/quan-tri/chi-tiet-don-hang/them-moi";
        public const string ROUTE_QUAN_TRI_CHI_TIET_DON_HANG_XOA = "/quan-tri/chi-tiet-don-hang/xoa/{id:regex(^[{{]?[0-9a-fA-F]{{8}}-([0-9a-fA-F]{{4}}-){{3}}[0-9a-fA-F]{{12}}[}}]?$)?}";
        //
        public const string ROUTE_QUAN_TRI_CHI_TIET_DON_HANG_PARAMS = "/quan-tri/chi-tiet-don-hang/{orderId}";
        public const string ROUTE_QUAN_TRI_CHI_TIET_DON_HANG_SEARCH_PARAMS = "/quan-tri/chi-tiet-don-hang?sortOrder={sortOrder}&searchString={searchString}&page={page}&orderStatus={orderStatus}";
        public const string ROUTE_QUAN_TRI_CHI_TIET_DON_HANG_CHI_TIET_PARAMS = "/quan-tri/chi-tiet-don-hang/chi-tiet/{id}";
        public const string ROUTE_QUAN_TRI_CHI_TIET_DON_HANG_CAP_NHAT_PARAMS = "/quan-tri/chi-tiet-don-hang/cap-nhat/{id}";
        public const string ROUTE_QUAN_TRI_CHI_TIET_DON_HANG_THEM_MOI_PARAMS = "/quan-tri/chi-tiet-don-hang/them-moi";
        public const string ROUTE_QUAN_TRI_CHI_TIET_DON_HANG_XOA_PARAMS = "/quan-tri/chi-tiet-don-hang/xoa/{id}";




        //
        public const string ROUTE_QUAN_TRI_NGUOI_BAN_CHI_TIET_DON_HANG = "/quan-tri/nguoi-ban/chi-tiet-don-hang/{orderId}";
        public const string ROUTE_QUAN_TRI_NGUOI_BAN_CHI_TIET_DON_HANG_CHI_TIET = "/quan-tri/nguoi-ban/chi-tiet-don-hang/chi-tiet/{id:regex(^[{{]?[0-9a-fA-F]{{8}}-([0-9a-fA-F]{{4}}-){{3}}[0-9a-fA-F]{{12}}[}}]?$)?}";
        public const string ROUTE_QUAN_TRI_NGUOI_BAN_CHI_TIET_DON_HANG_CAP_NHAT = "/quan-tri/nguoi-ban/chi-tiet-don-hang/cap-nhat/{id:regex(^[{{]?[0-9a-fA-F]{{8}}-([0-9a-fA-F]{{4}}-){{3}}[0-9a-fA-F]{{12}}[}}]?$)?}";
        public const string ROUTE_QUAN_TRI_NGUOI_BAN_CHI_TIET_DON_HANG_THEM_MOI = "/quan-tri/nguoi-ban/chi-tiet-don-hang/them-moi";
        public const string ROUTE_QUAN_TRI_NGUOI_BAN_CHI_TIET_DON_HANG_XOA = "/quan-tri/nguoi-ban/chi-tiet-don-hang/xoa/{id:regex(^[{{]?[0-9a-fA-F]{{8}}-([0-9a-fA-F]{{4}}-){{3}}[0-9a-fA-F]{{12}}[}}]?$)?}";
        //
        public const string ROUTE_QUAN_TRI_NGUOI_BAN_CHI_TIET_DON_HANG_PARAMS = "/quan-tri/nguoi-ban/chi-tiet-don-hang/{orderId}";
        public const string ROUTE_QUAN_TRI_NGUOI_BAN_CHI_TIET_DON_HANG_SEARCH_PARAMS = "/quan-tri/nguoi-ban/chi-tiet-don-han?sortOrder={sortOrder}&searchString={searchString}&page={page}&orderStatus={orderStatus}";
        public const string ROUTE_QUAN_TRI_NGUOI_BAN_CHI_TIET_DON_HANG_CHI_TIET_PARAMS = "/quan-tri/nguoi-ban/chi-tiet-don-hang/chi-tiet/{id}";
        public const string ROUTE_QUAN_TRI_NGUOI_BAN_CHI_TIET_DON_HANG_CAP_NHAT_PARAMS = "/quan-tri/nguoi-ban/chi-tiet-don-hang/cap-nhat/{id}";
        public const string ROUTE_QUAN_TRI_NGUOI_BAN_CHI_TIET_DON_HANG_THEM_MOI_PARAMS = "/quan-tri/nguoi-ban/chi-tiet-don-hang/them-moi";
        public const string ROUTE_QUAN_TRI_NGUOI_BAN_CHI_TIET_DON_HANG_XOA_PARAMS = "/quan-tri/nguoi-ban/chi-tiet-don-hang/xoa/{id}";










        //
        //  USER
        //



        //
        public const string ROUTE_TRANG_CHU = "/";
        //
        public const string ROUTE_TRANG_CHU_PARAMS = "/";




        //
        public const string ROUTE_DANG_NHAP = "/dang-nhap";
        public const string ROUTE_DANG_XUAT = "/dang-xuat";
        //
        public const string ROUTE_DANG_NHAP_PARAMS = "/dang-nhap";
        public const string ROUTE_DANG_XUAT_PARAMS = "/dang-xuat";



        //
        public const string ROUTE_SAN_PHAM = "/san-pham";
        public const string ROUTE_SAN_PHAM_CHI_TIET = "/san-pham/chi-tiet/{id:regex(^[{{]?[0-9a-fA-F]{{8}}-([0-9a-fA-F]{{4}}-){{3}}[0-9a-fA-F]{{12}}[}}]?$)?}";
        //
        public const string ROUTE_SAN_PHAM_PARAMS = "/san-pham";
        public const string ROUTE_SAN_PHAM_SEARCH_PARAMS = "/san-pham?sortOrder={sortOrder}&searchString={searchString}&page={page}";
        public const string ROUTE_SAN_PHAM_CHI_TIET_PARAMS = "/san-pham/chi-tiet/{id}";




//
        public const string ROUTE_GIO_HANG = "/gio-hang";
        public const string ROUTE_GIO_HANG_THEM_MOI = "/gio-hang/them-moi";
        //
        public const string ROUTE_GIO_HANG_PARAMS = "/gio-hang";
        public const string ROUTE_GIO_HANG_THEM_MOI_PARAMS = "/gio-hang/them-moi";



        //
        public const string ROUTE_DON_HANG = "/don-hang";
        public const string ROUTE_DON_HANG_THEM_MOI = "/don-hang/them-moi";
        public const string ROUTE_DON_HANG_XOA = "/don-hang/xoa/{id:regex(^[{{]?[0-9a-fA-F]{{8}}-([0-9a-fA-F]{{4}}-){{3}}[0-9a-fA-F]{{12}}[}}]?$)?}";
        //
        public const string ROUTE_DON_HANG_PARAMS = "/don-hang";
        public const string ROUTE_DON_HANG_THEM_MOI_PARAMS = "/don-hang/them-moi?cartId={cartId}&shopId={shopId}&shouldOrderAll={shouldOrderAll}";
        public const string ROUTE_DON_HANG_XOA_PARAMS = "/don-hang/xoa/{id}";






        //{id:regex(^[{{]?[0-9a-fA-F]{{8}}-([0-9a-fA-F]{{4}}-){{3}}[0-9a-fA-F]{{12}}[}}]?$)?}";




        public static CultureInfo VietNamCultureInfo = CultureInfo.CreateSpecificCulture("vi-VN");
        public const string CurrencyFormat = "c";
    }
}
