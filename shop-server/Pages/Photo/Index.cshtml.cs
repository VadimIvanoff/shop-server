using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhotoSauce.MagicScaler;
using shop_server.Helpers;

namespace shop_server.Pages.Photo
{
    public class IndexModel : PageModel
    {
        private IHostingEnvironment appEnvironment;
        [BindProperty]
        public IFormFile uploadedFile { get; set; }
        [BindProperty]
        public IFormFile uploadedFile2 { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }

        public IndexModel(IHostingEnvironment appEnv)
        {
            appEnvironment = appEnv;
        }
        public void OnGet()
        {
            return;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (uploadedFile != null)
            {
                var settingsSmall = new ProcessImageSettings
                {
                    Width = 100,
                    SaveFormat = FileFormat.Jpeg,
                    JpegQuality = 100
                };
                var settingsBig = new ProcessImageSettings
                {
                    Width = 900,
                    SaveFormat = FileFormat.Jpeg,
                    JpegQuality = 100
                };

                // Path to file folder
                string path1 = "/files/" + "small.jpeg";
                string path2 = "/files/" + "big.jpeg";
                // Save File to folder

                // small
                using (var fileStream = new FileStream(appEnvironment.WebRootPath + path1, FileMode.Create))
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await uploadedFile.CopyToAsync(memoryStream);
                        MagicImageProcessor.ProcessImage(memoryStream.ToArray(), fileStream, settingsSmall);                    
                    }
                }
                // big
                using (var fileStream = new FileStream(appEnvironment.WebRootPath + path2, FileMode.Create))
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await uploadedFile.CopyToAsync(memoryStream);
                        MagicImageProcessor.ProcessImage(memoryStream.ToArray(), fileStream, settingsBig);
                    }
                }
                //FileName = uploadedFile.Name;
                //Path = path;
            }
            return Page();
        }
    }
}