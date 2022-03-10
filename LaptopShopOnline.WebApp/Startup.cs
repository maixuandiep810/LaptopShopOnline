using LaptopShopOnline.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LaptopShopOnline.Service;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using LaptopShopOnline.Common;

namespace LaptopShopOnline.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();


            //
            //
            //
            //  SQL SERVER
            services.AddDbContext<LaptopShopOnlineDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();
            //  SESSION
            // Adding Authentication  
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(360000);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });





            //
            //  Add SERVICES LAYER
            //
            services.AddScoped<ServiceWrapper, ServiceWrapper>();
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                       Path.Combine(env.ContentRootPath, "Content")),
                RequestPath = "/Content"
            });
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                       Path.Combine(env.ContentRootPath, "Content")),
                RequestPath = "/Scripts"
            });
            app.UseRouting();



            //  SESSION
            app.UseSession();



            ////  CAPTCHA
            ////configure BotDetectCaptcha
            //app.UseCaptcha(Configuration);



            app.UseEndpoints(endpoints =>
            {
                //
                //  ADMIN AREA
                //

                endpoints.MapAreaControllerRoute(
                    areaName: "Admin",
                    name: "Admin_Default",
                    pattern: CommonConstants.ROUTE_QUAN_TRI,
                    defaults: new { area = "Admin", controller = "Home", action = "Index" },
                    dataTokens: new { area = "Admin" }
                    );




                //
                //  ADMIN AREA AUTH
                //

                // Login in Admin Areas
                endpoints.MapControllerRoute(
                    name: "Admin",
                    pattern: CommonConstants.ROUTE_QUAN_TRI,
                    defaults: new { area = "Admin", controller = "Home", action = "Index" },
                    dataTokens: new { area = "Admin" });

                // Login in Admin Areas
                endpoints.MapControllerRoute(
                    name: "Admin-Login",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_DANG_NHAP,
                    defaults: new { area = "Admin", controller = "Login", action = "Login" },
                    dataTokens: new { area = "Admin" });

                ///LogOut in Admin Areas
                endpoints.MapControllerRoute(
                    name: "Admin-Logout",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_DANG_XUAT,
                    defaults: new { area = "Admin", controller = "Login", action = "LogOut" },
                    dataTokens: new { area = "Admin" });




               //
                //  ADMIN - USERGROUP
                //

                //
                endpoints.MapControllerRoute(
                    name: "Admin-UserGroup",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_NHOM_NGUOI_DUNG,
                    defaults: new { area = "Admin", controller = "UserGroups", action = "Index" },
                    dataTokens: new { area = "Admin" });
                
                //
                endpoints.MapControllerRoute(
                    name: "Admin-UserGroup-Details",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_NHOM_NGUOI_DUNG_CHI_TIET,
                    defaults: new { area = "Admin", controller = "UserGroups", action = "Details" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-UserGroup-Create",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_NHOM_NGUOI_DUNG_THEM_MOI,
                    defaults: new { area = "Admin", controller = "UserGroups", action = "Create" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-UserGroup-Edit",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_NHOM_NGUOI_DUNG_CAP_NHAT,
                    defaults: new { area = "Admin", controller = "UserGroups", action = "Edit" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-UserGroup-Delete",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_NHOM_NGUOI_DUNG_XOA,
                    defaults: new { area = "Admin", controller = "UserGroups", action = "Delete" },
                    dataTokens: new { area = "Admin" });




               //
                //  ADMIN - CREDENTIAL
                //

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Credential",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_PHAN_QUYEN,
                    defaults: new { area = "Admin", controller = "Credentials", action = "Index" },
                    dataTokens: new { area = "Admin" });

                
                //
                endpoints.MapControllerRoute(
                    name: "Admin-Credential-Details",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_PHAN_QUYEN_CHI_TIET,
                    defaults: new { area = "Admin", controller = "Credentials", action = "Details" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Credential-Create",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_PHAN_QUYEN_THEM_MOI,
                    defaults: new { area = "Admin", controller = "Credentials", action = "Create" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Credential-Delete",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_PHAN_QUYEN_XOA,
                    defaults: new { area = "Admin", controller = "Credentials", action = "Delete" },
                    dataTokens: new { area = "Admin" });



                //
                //  ADMIN - USER
                //

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Account",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_TAI_KHOAN_NGUOI_DUNG,
                    defaults: new { area = "Admin", controller = "Users", action = "Index" },
                    dataTokens: new { area = "Admin" });
                
                //
                endpoints.MapControllerRoute(
                    name: "Admin-Account",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_TAI_KHOAN_NGUOI_DUNG_CHI_TIET,
                    defaults: new { area = "Admin", controller = "Users", action = "Details" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Account-Create",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_TAI_KHOAN_NGUOI_DUNG_THEM_MOI,
                    defaults: new { area = "Admin", controller = "Users", action = "Create" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Account-Edit",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_TAI_KHOAN_NGUOI_DUNG_CAP_NHAT,
                    defaults: new { area = "Admin", controller = "Users", action = "Edit" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Account-Edit",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_TAI_KHOAN_NGUOI_DUNG_XOA,
                    defaults: new { area = "Admin", controller = "Users", action = "Delete" },
                    dataTokens: new { area = "Admin" });



                //
                //  ADMIN - ROLE
                //

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Role",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_QUYEN,
                    defaults: new { area = "Admin", controller = "Roles", action = "Index" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Role-Details",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_QUYEN_CHI_TIET,
                    defaults: new { area = "Admin", controller = "Roles", action = "Details" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Role-Edit",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_QUYEN_CAP_NHAT,
                    defaults: new { area = "Admin", controller = "Roles", action = "Edit" },
                    dataTokens: new { area = "Admin" });



                //
                //  ADMIN - SHOP
                //

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Shop",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_CUA_HANG,
                    defaults: new { area = "Admin", controller = "Shops", action = "Index" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Shop",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_CUA_HANG_CHI_TIET,
                    defaults: new { area = "Admin", controller = "Shops", action = "Details" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Shop-Create",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_CUA_HANG_THEM_MOI,
                    defaults: new { area = "Admin", controller = "Shops", action = "Create" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Shop-Edit",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_CUA_HANG_CAP_NHAT,
                    defaults: new { area = "Admin", controller = "Shops", action = "Edit" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Seller-Shop-Edit",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_CUA_HANG_XOA,
                    defaults: new { area = "Admin", controller = "Shops", action = "Delete" },
                    dataTokens: new { area = "Admin" });

                //  S
                endpoints.MapControllerRoute(
                    name: "Admin-Seller-Shop-Edit",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_NGUOI_BAN_CUA_HANG_CAP_NHAT_PARAMS,
                    defaults: new { area = "Admin", controller = "Shops", action = "EditSG" },
                    dataTokens: new { area = "Admin" });




                //
                //  ADMIN - PRODUCT_CATEGORY
                //

                //
                endpoints.MapControllerRoute(
                    name: "Admin-ProductCategory",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_DANH_MUC_SAN_PHAM,
                    defaults: new { area = "Admin", controller = "ProductCategories", action = "Index" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-ProductCategory",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_DANH_MUC_SAN_PHAM_CHI_TIET,
                    defaults: new { area = "Admin", controller = "ProductCategories", action = "Details" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-ProductCategory-Create",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_DANH_MUC_SAN_PHAM_THEM_MOI,
                    defaults: new { area = "Admin", controller = "ProductCategories", action = "Create" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-ProductCategory-Edit",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_DANH_MUC_SAN_PHAM_CAP_NHAT,
                    defaults: new { area = "Admin", controller = "ProductCategories", action = "Edit" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-ProductCategory-Edit",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_DANH_MUC_SAN_PHAM_XOA,
                    defaults: new { area = "Admin", controller = "ProductCategories", action = "Delete" },
                    dataTokens: new { area = "Admin" });



                //
                //  ADMIN - PRODUCT
                //

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Product",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_SAN_PHAM,
                    defaults: new { area = "Admin", controller = "Products", action = "Index" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Product",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_SAN_PHAM_CHI_TIET,
                    defaults: new { area = "Admin", controller = "Products", action = "Details" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Product-Create",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_SAN_PHAM_THEM_MOI,
                    defaults: new { area = "Admin", controller = "Products", action = "Create" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Product-Edit",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_SAN_PHAM_CAP_NHAT,
                    defaults: new { area = "Admin", controller = "Products", action = "Edit" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Product-Delete",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_SAN_PHAM_XOA,
                    defaults: new { area = "Admin", controller = "Products", action = "Delete" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Seller-Product",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_NGUOI_BAN_SAN_PHAM_PARAMS,
                    defaults: new { area = "Admin", controller = "Products", action = "IndexSG" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Seller-Product",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_NGUOI_BAN_SAN_PHAM_CHI_TIET,
                    defaults: new { area = "Admin", controller = "Products", action = "DetailsSG" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin_Seller-Product-Create",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_NGUOI_BAN_SAN_PHAM_THEM_MOI,
                    defaults: new { area = "Admin", controller = "Products", action = "CreateSG" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin_Seller-Product-Edit",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_NGUOI_BAN_SAN_PHAM_CAP_NHAT,
                    defaults: new { area = "Admin", controller = "Products", action = "EditSG" },
                    dataTokens: new { area = "Admin" });

                // //
                // endpoints.MapControllerRoute(
                //     name: "Admin-Seller-Product-Create",
                //     pattern: "quan-tri/nguoi-ban/danh-muc-san-pham/them-moi",
                //     defaults: new { area = "Admin", controller = "Products", action = "CreateSG" },
                //     dataTokens: new { area = "Admin" });

                // //
                // endpoints.MapControllerRoute(
                //     name: "Admin-Seller-Product-Edit",
                //     pattern: "quan-tri/nguoi-ban/danh-muc-san-pham/cap-nhat",
                //     defaults: new { area = "Admin", controller = "Products", action = "EditSG" },
                //     dataTokens: new { area = "Admin" });



                //
                //  ADMIN - ORDER
                //

                //

                endpoints.MapControllerRoute(
                    name: "Admin-Order",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_DON_HANG,
                    defaults: new { area = "Admin", controller = "Orders", action = "Index" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Order-Create",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_DON_HANG_THEM_MOI,
                    defaults: new { area = "Admin", controller = "Orders", action = "Create" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Order-Edit",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_DON_HANG_CAP_NHAT,
                    defaults: new { area = "Admin", controller = "Orders", action = "Edit" },
                    dataTokens: new { area = "Admin" });

                ////
                //endpoints.MapControllerRoute(
                //    name: "Admin-Order-Cancelled",
                //    pattern: "quan-tri/don-dat-hang-da-huy",
                //    defaults: new { area = "Admin", controller = "Orders", action = "CancelOrder" },
                //    dataTokens: new { area = "Admin" });

                ////
                //endpoints.MapControllerRoute(
                //    name: "Admin-OrderDetail",
                //    pattern: "quan-tri/don-dat-hang-da-huy",
                //    defaults: new { area = "Admin", controller = "Products", action = "Create" },
                //    dataTokens: new { area = "Admin" });


                endpoints.MapControllerRoute(
                    name: "Admin-Seller-Order",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_NGUOI_BAN_DON_HANG,
                    defaults: new { area = "Admin", controller = "Orders", action = "IndexSG" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Seller-Order-Create",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_NGUOI_BAN_DON_HANG_THEM_MOI,
                    defaults: new { area = "Admin", controller = "Orders", action = "CreateSG" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Seller-Order-Edit",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_NGUOI_BAN_DON_HANG_CAP_NHAT,
                    defaults: new { area = "Admin", controller = "Orders", action = "EditSG" },
                    dataTokens: new { area = "Admin" });




                //
                //  ADMIN - ORDERDETAIL
                //

                //

                endpoints.MapControllerRoute(
                    name: "Admin-OrderDetail",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_CHI_TIET_DON_HANG,
                    defaults: new { area = "Admin", controller = "OrderDetails", action = "Index" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-OrderDetail-Create",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_CHI_TIET_DON_HANG_THEM_MOI,
                    defaults: new { area = "Admin", controller = "OrderDetails", action = "Create" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-OrderDetail-Edit",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_CHI_TIET_DON_HANG_CAP_NHAT,
                    defaults: new { area = "Admin", controller = "OrderDetails", action = "Edit" },
                    dataTokens: new { area = "Admin" });

                ////
                //endpoints.MapControllerRoute(
                //    name: "Admin-OrderDetail-Cancelled",
                //    pattern: "quan-tri/don-dat-hang-da-huy",
                //    defaults: new { area = "Admin", controller = "OrderDetails", action = "CancelOrderDetail" },
                //    dataTokens: new { area = "Admin" });

                ////
                //endpoints.MapControllerRoute(
                //    name: "Admin-OrderDetailDetail",
                //    pattern: "quan-tri/don-dat-hang-da-huy",
                //    defaults: new { area = "Admin", controller = "Products", action = "Create" },
                //    dataTokens: new { area = "Admin" });


                endpoints.MapControllerRoute(
                    name: "Admin-Seller-OrderDetail",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_NGUOI_BAN_CHI_TIET_DON_HANG,
                    defaults: new { area = "Admin", controller = "OrderDetails", action = "IndexSG" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Seller-OrderDetail-Create",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_NGUOI_BAN_CHI_TIET_DON_HANG_THEM_MOI,
                    defaults: new { area = "Admin", controller = "OrderDetails", action = "CreateSG" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Seller-OrderDetail-Edit",
                    pattern: CommonConstants.ROUTE_QUAN_TRI_NGUOI_BAN_CHI_TIET_DON_HANG_CAP_NHAT,
                    defaults: new { area = "Admin", controller = "OrderDetails", action = "EditSG" },
                    dataTokens: new { area = "Admin" });





                //
                //  USER 
                //


                //
                //  USER - USER
                //

                endpoints.MapControllerRoute(
                    name: "Login",
                    pattern: "dang-nhap",
                    defaults: new { controller = "User", action = "Login" });


                //endpoints.MapControllerRoute(
                //    name: "Register",
                //    pattern: "dang-ky",
                //    defaults: new { controller = "User", action = "Register" });


                //endpoints.MapControllerRoute(
                //    name: "EditProfile",
                //    pattern: "ho-so-nguoi-dung",
                //    defaults: new { controller = "User", action = "EditProfile" });



                //
                //  USER - HOME
                //

                endpoints.MapControllerRoute(
                    name: "Home",
                    pattern: "/",
                    defaults: new { controller = "Homes", action = "Index" });



                //
                //  USER - CART
                //

                //
                endpoints.MapControllerRoute(
                    name: "Cart",
                    pattern: "gio-hang",
                    defaults: new { controller = "Cart", action = "Index" });

                //
                endpoints.MapControllerRoute(
                    name: "Cart-Create",
                    pattern: "gio-hang/them-vao",
                    defaults: new { controller = "Cart", action = "Add" });

                //
                endpoints.MapControllerRoute(
                    name: "Cart-Edit",
                    pattern: "gio-hang/cap-nhat",
                    defaults: new { controller = "Cart", action = "Edit" });

                //
                endpoints.MapControllerRoute(
                    name: "Cart-Delete",
                    pattern: "gio-hang/xoa/{id}",
                    defaults: new { controller = "Cart", action = "Delete" });



                //
                //  USER - ORDER
                //

                //
                endpoints.MapControllerRoute(
                    name: "Cart",
                    pattern: "don-hang",
                    defaults: new { controller = "Order", action = "Index" });

                //
                endpoints.MapControllerRoute(
                    name: "Cart-Create",
                    pattern: "don-hang/tao",
                    defaults: new { controller = "Order", action = "Create" });

                //
                endpoints.MapControllerRoute(
                    name: "Cart-Create",
                    pattern: "don-hang/xoa/{id}",
                    defaults: new { controller = "Order", action = "Delete" });



                //
                //  USER - PRODUCT
                //

                //
                endpoints.MapControllerRoute(
                    name: "Product",
                    pattern: CommonConstants.ROUTE_SAN_PHAM,
                    defaults: new { controller = "Product", action = "Index" });

                //
                endpoints.MapControllerRoute(
                    name: "Product",
                    pattern: CommonConstants.ROUTE_SAN_PHAM_CHI_TIET,
                    defaults: new { controller = "Product", action = "Details" });








                //
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
