using LaptopShopOnline.Model;
using LaptopShopOnline.Service.Implement;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopShopOnline.Service
{
    public class ServiceWrapper
    {


        private readonly IServiceProvider _serviceProvider;
        public readonly LaptopShopOnlineDbContext Db;



        public ServiceWrapper(IServiceProvider serviceProvider, LaptopShopOnlineDbContext db)
        {
            _serviceProvider = serviceProvider;
            Db = db;
        }


        private IImageService _imageService;
        private IUserService _userService;
        private IOrderService _orderService;
        private IProductService _productService;





        public IImageService ImageService
        {
            get
            {
                if (_imageService == null)
                {
                    _imageService = (ImageService)ActivatorUtilities.CreateInstance(_serviceProvider, typeof(ImageService));
                }
                return _imageService;
            }
        }

        public IUserService UserService
        {
            get
            {
                if (_userService == null)
                {
                    _userService = (UserService)ActivatorUtilities.CreateInstance(_serviceProvider, typeof(UserService));
                }
                return _userService;
            }
        }


        public IOrderService OrderService
        {
            get
            {
                if (_orderService == null)
                {
                    _orderService = (OrderService)ActivatorUtilities.CreateInstance(_serviceProvider, typeof(OrderService));
                }
                return _orderService;
            }
        }

        public IProductService ProductService
        {
            get
            {
                if (_productService == null)
                {
                    _productService = (ProductService)ActivatorUtilities.CreateInstance(_serviceProvider, typeof(ProductService));
                }
                return _productService;
            }
        }
    }
}
    