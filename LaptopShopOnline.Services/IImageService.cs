using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopShopOnline.Service
{
    public interface IImageService
    {
        string SaveImage(IFormFile formFile, string uploadFolder);
    }
}
