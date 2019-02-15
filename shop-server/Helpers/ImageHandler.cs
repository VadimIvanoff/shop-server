using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using PhotoSauce.MagicScaler;
using shop_server.Models;

namespace shop_server.Helpers
{
    public static class ImageHandler
    {
       
       public static async Task<ProductImage> ProcessImage(IFormFile uploadedFile, int productId, string rootPath)
        {
            var settingsSmall = new ProcessImageSettings
            {
                Width = 200,
                Height = 200,
                SaveFormat = FileFormat.Jpeg,
                JpegQuality = 100,
                ResizeMode = CropScaleMode.Pad
            };
            var settingsBig = new ProcessImageSettings
            {
                Width = 400,
                Height = 400,
                SaveFormat = FileFormat.Jpeg,
                JpegQuality = 100,
                ResizeMode = CropScaleMode.Pad
            };
            string pathSmall = "/catalog/images/" + productId + "_" + "small.jpeg";
            string pathBig = "/catalog/images/" + productId + "_" + "big.jpeg";
            using (var fileStream = new FileStream(rootPath + pathSmall, FileMode.Create))
            {
                using (var memoryStream = new MemoryStream())
                {
                    await uploadedFile.CopyToAsync(memoryStream);
                    MagicImageProcessor.ProcessImage(memoryStream.ToArray(), fileStream, settingsSmall);
                }
            }
            // big
            using (var fileStream = new FileStream(rootPath + pathBig, FileMode.Create))
            {
                using (var memoryStream = new MemoryStream())
                {
                    await uploadedFile.CopyToAsync(memoryStream);
                    MagicImageProcessor.ProcessImage(memoryStream.ToArray(), fileStream, settingsBig);
                }
            }

            var newImage = new ProductImage
            {
                Name = productId + ".jpeg",
                Path = "/catalog/images/",
                ProductId = productId,
                ContentType = uploadedFile.ContentType,

            };
            return newImage; 

        }
        public static void DeleteImage(int prodId, string root)
        {
            string pathSmall = root + "/catalog/images/" + prodId + "_" + "small.jpeg";
            string pathBig = root + "/catalog/images/" + prodId + "_" + "big.jpeg";
            if (File.Exists(pathSmall) && File.Exists(pathBig))
            {
                try
                {
                    File.Delete(pathSmall);
                    File.Delete(pathBig);
                    
            }
                catch (Exception ex)
                {
                }
            }
           
        }
    }
}
