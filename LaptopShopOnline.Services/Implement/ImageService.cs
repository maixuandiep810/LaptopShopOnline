using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopShopOnline.Service.Implement
{
    public class ImageService : IImageService
    {
        public string SaveImage(IFormFile formFile, string uploadFolder) 
        {
            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName);
            string filePath = Path.Combine(uploadFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                formFile.CopyTo(fileStream);
            }
            return uniqueFileName;
        }
    }

}
