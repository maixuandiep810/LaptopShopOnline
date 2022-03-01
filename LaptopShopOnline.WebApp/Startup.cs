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
                    pattern: "quan-tri/",
                    defaults: new { area = "Admin", controller = "Home", action = "Index" },
                    dataTokens: new { area = "Admin" }
                    );




                //
                //  ADMIN AREA AUTH
                //

                //endpoints.MapRoute(
                //    name: "Admin",
                //    url: "quan-tri",
                //    defaults: new { controller = "Login", action = "Login", id = null },
                //    namespaces: new[] { "LaptopShopOnline.WebApp.Areas.Admin.Controllers" }
                //).DataTokens["area"] = "Admin";
                //endpoints.MapRoute(
                //    name: "Admin-Home",
                //    url: "quan-tri/trang-chu",
                //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                //    namespaces: new[] { "LaptopShopOnline.WebApp.Areas.Admin.Controllers" }
                //).DataTokens["area"] = "Admin";

                // Login in Admin Areas
                endpoints.MapControllerRoute(
                    name: "Admin-Login",
                    pattern: "quan-tri/dang-nhap",
                    defaults: new { area = "Admin", controller = "Login", action = "Login" },
                    dataTokens: new { area = "Admin" });

                ///LogOut in Admin Areas
                endpoints.MapControllerRoute(
                    name: "Admin-Logout",
                    pattern: "quan-tri/dang-xuat",
                    defaults: new { area = "Admin", controller = "Login", action = "LogOut" },
                    dataTokens: new { area = "Admin" });



                //
                //  ADMIN - USER
                //

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Account",
                    pattern: "quan-tri/tai-khoan-nguoi-dung",
                    defaults: new { area = "Admin", controller = "Users", action = "Index" },
                    dataTokens: new { area = "Admin" });
                
                //
                endpoints.MapControllerRoute(
                    name: "Admin-Account",
                    pattern: "quan-tri/tai-khoan-nguoi-dung/{id:regex(^(?!((them-moi)|(cap-nhat))$).*)?}",
                    defaults: new { area = "Admin", controller = "Users", action = "Details" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Account-Create",
                    pattern: "quan-tri/tai-khoan-nguoi-dung/them-moi",
                    defaults: new { area = "Admin", controller = "Users", action = "Create" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Account-Edit",
                    pattern: "quan-tri/tai-khoan-nguoi-dung/cap-nhat",
                    defaults: new { area = "Admin", controller = "Users", action = "Edit" },
                    dataTokens: new { area = "Admin" });



                //
                //  ADMIN - ROLE
                //

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Role",
                    pattern: "quan-tri/quan-ly-phan-quyen",
                    defaults: new { area = "Admin", controller = "Roles", action = "Index" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Role",
                    pattern: "quan-tri/quan-ly-phan-quyen/{id:regex(^(?!((them-moi)|(cap-nhat))$).*)?}",
                    defaults: new { area = "Admin", controller = "Roles", action = "Details" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Role-Create",
                    pattern: "quan-tri/quan-ly-phan-quyen/them-moi",
                    defaults: new { area = "Admin", controller = "Roles", action = "Create" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Role-Edit",
                    pattern: "quan-tri/quan-ly-phan-quyen/cap-nhat",
                    defaults: new { area = "Admin", controller = "Roles", action = "Edit" },
                    dataTokens: new { area = "Admin" });



                //
                //  ADMIN - CREDENTIAL
                //

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Credential",
                    pattern: "quan-tri/phan-quyen-nguoi-dung",
                    defaults: new { area = "Admin", controller = "Credentials", action = "Index" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Credential",
                    pattern: "quan-tri/phan-quyen-nguoi-dung/{groupId:regex(^(?!((them-moi)|(cap-nhat))$).*)?}/{roleId:regex(^(?!((them-moi)|(cap-nhat))$).*)?}",
                    defaults: new { area = "Admin", controller = "Credentials", action = "Details" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Credential-Create",
                    pattern: "quan-tri/phan-quyen-nguoi-dung/them-moi",
                    defaults: new { area = "Admin", controller = "Credentials", action = "Create" },
                    dataTokens: new { area = "Admin" });


                //
                //  ADMIN - SHOP
                //

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Shop",
                    pattern: "quan-tri/quan-ly-cua-hang",
                    defaults: new { area = "Admin", controller = "Shops", action = "Index" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Shop",
                    pattern: "quan-tri/quan-ly-cua-hang/{id:regex(^(?!((them-moi)|(cap-nhat))$).*)?}",
                    defaults: new { area = "Admin", controller = "Shops", action = "Details" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Shop-Create",
                    pattern: "quan-tri/quan-ly-cua-hang/them-moi",
                    defaults: new { area = "Admin", controller = "Shops", action = "Create" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Shop-Edit",
                    pattern: "quan-tri/quan-ly-cua-hang/cap-nhat",
                    defaults: new { area = "Admin", controller = "Shops", action = "Edit" },
                    dataTokens: new { area = "Admin" });

                //  S
                endpoints.MapControllerRoute(
                    name: "Admin-Seller-Shop-Edit",
                    pattern: "quan-tri/nguoi-ban/quan-ly-cua-hang",
                    defaults: new { area = "Admin", controller = "Shops", action = "EditSG" },
                    dataTokens: new { area = "Admin" });




                //
                //  ADMIN - PRODUCT_CATEGORY
                //

                //
                endpoints.MapControllerRoute(
                    name: "Admin-ProductCategory",
                    pattern: "quan-tri/loai-san-pham",
                    defaults: new { area = "Admin", controller = "ProductCategories", action = "Index" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-ProductCategory",
                    pattern: "quan-tri/loai-san-pham/{id:regex(^(?!((them-moi)|(cap-nhat))$).*)?}",
                    defaults: new { area = "Admin", controller = "ProductCategories", action = "Details" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-ProductCategory-Create",
                    pattern: "quan-tri/loai-san-pham/them-moi",
                    defaults: new { area = "Admin", controller = "ProductCategories", action = "Create" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-ProductCategory-Edit",
                    pattern: "quan-tri/loai-san-pham/cap-nhat",
                    defaults: new { area = "Admin", controller = "ProductCategories", action = "Edit" },
                    dataTokens: new { area = "Admin" });



                //
                //  ADMIN - PRODUCT
                //

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Product",
                    pattern: "quan-tri/danh-muc-san-pham",
                    defaults: new { area = "Admin", controller = "Products", action = "Index" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Product",
                    pattern: "quan-tri/danh-muc-san-pham/{id:regex(^(?!((them-moi)|(cap-nhat))$).*)?}",
                    defaults: new { area = "Admin", controller = "Products", action = "Details" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Product-Create",
                    pattern: "quan-tri/danh-muc-san-pham/them-moi",
                    defaults: new { area = "Admin", controller = "Products", action = "Create" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Product-Edit",
                    pattern: "quan-tri/danh-muc-san-pham/cap-nhat",
                    defaults: new { area = "Admin", controller = "Products", action = "Edit" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Seller-Product",
                    pattern: "quan-tri/nguoi-ban/danh-muc-san-pham",
                    defaults: new { area = "Admin", controller = "Products", action = "IndexSG" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Seller-Product",
                    pattern: "quan-tri/nguoi-ban/danh-muc-san-pham/{id:regex(^(?!((them-moi)|(cap-nhat))$).*)?}",
                    defaults: new { area = "Admin", controller = "Products", action = "DetailsSG" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Seller-Product-Create",
                    pattern: "quan-tri/nguoi-ban/danh-muc-san-pham/them-moi",
                    defaults: new { area = "Admin", controller = "Products", action = "CreateSG" },
                    dataTokens: new { area = "Admin" });

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Seller-Product-Edit",
                    pattern: "quan-tri/nguoi-ban/danh-muc-san-pham/cap-nhat",
                    defaults: new { area = "Admin", controller = "Products", action = "EditSG" },
                    dataTokens: new { area = "Admin" });



                //
                //  ADMIN - ORDER
                //

                //
                endpoints.MapControllerRoute(
                    name: "Admin-Order",
                    pattern: "quan-tri/don-dat-hang",
                    defaults: new { area = "Admin", controller = "Orders", action = "Index" },
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
                    defaults: new { controller = "Cart", action = "Create" });

                //
                endpoints.MapControllerRoute(
                    name: "Cart-Edit",
                    pattern: "gio-hang/cap-nhat",
                    defaults: new { controller = "Cart", action = "Edit" });

                //
                endpoints.MapControllerRoute(
                    name: "Cart-Delete",
                    pattern: "gio-hang/xoa/{id?}",
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
                //  USER - PRODUCT
                //

                //
                endpoints.MapControllerRoute(
                    name: "Product",
                    pattern: "danh-muc-san-pham",
                    defaults: new { controller = "Product", action = "Index" });

                //
                endpoints.MapControllerRoute(
                    name: "Product",
                    pattern: "danh-muc-san-pham/{id}",
                    defaults: new { controller = "Product", action = "Details" });









                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
