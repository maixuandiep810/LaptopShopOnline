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

                //endpoints.MapAreaControllerRoute(
                //    name: "Admin_default",
                //    areaName: "Admin",
                //    pattern: "quan-tri/{controller=Home}/{action=Index}/{id?}");




                //
                //  HELLO
                //

                //
                //endpoints.MapControllerRoute(
                //    name: "Admin-Hello",
                //    pattern: "quan-tri/dang-nhap",
                //    defaults: new { area = "Admin", controller = "Hello", action = "Index" },
                //    dataTokens: new { area = "Admin" });



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




                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
