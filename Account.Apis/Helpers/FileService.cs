using Account.Core.Services.Content;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Reposatory.Services.Content
{
    public class FileService : IFileService
    {
        private IWebHostEnvironment environment;
        public FileService(IWebHostEnvironment env)
        {
            this.environment = env;
        }
        public Tuple<int, List<string>> SaveImages(List<IFormFile> imageFiles)
        {
            try
            {
                var contentPath = this.environment.ContentRootPath;
                var path = Path.Combine(contentPath, "Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                var allowedExtensions = new string[] { ".jpg", ".png", ".jpeg" };
                List<string> savedFileNames = new List<string>();

                foreach (var imageFile in imageFiles)
                {
                    // Check the allowed extensions for each file
                    var ext = Path.GetExtension(imageFile.FileName);
                    if (!allowedExtensions.Contains(ext))
                    {
                        string msg = string.Format("Only {0} extensions are allowed", string.Join(",", allowedExtensions));
                        return new Tuple<int, List<string>>(0, new List<string> { msg });
                    }

                    string uniqueString = Guid.NewGuid().ToString();
                    var newFileName = uniqueString + ext;
                    var fileWithPath = Path.Combine(path, newFileName);
                    using (var stream = new FileStream(fileWithPath, FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }
                    savedFileNames.Add(newFileName);
                }

                return new Tuple<int, List<string>>(1, savedFileNames);
            }
            catch (Exception ex)
            {
                return new Tuple<int, List<string>>(0, new List<string> { "Error has occurred" });
            }
        }
        public Tuple<int, string> SaveImage(IFormFile imageFile)
        {
            try
            {
                var contentPath = this.environment.ContentRootPath;
                var path = Path.Combine(contentPath, "Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                var allowedExtensions = new string[] { ".jpg", ".png", ".jpeg" };

                // Check the allowed extensions for the file
                var ext = Path.GetExtension(imageFile.FileName);
                if (!allowedExtensions.Contains(ext))
                {
                    string msg = string.Format("Only {0} extensions are allowed", string.Join(",", allowedExtensions));
                    return new Tuple<int, string>(0, msg);
                }

                string uniqueString = Guid.NewGuid().ToString();
                var newFileName = uniqueString + ext;
                var fileWithPath = Path.Combine(path, newFileName);
                using (var stream = new FileStream(fileWithPath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                return new Tuple<int, string>(1, newFileName);
            }
            catch (Exception ex)
            {
                return new Tuple<int, string>(0, "Error has occurred");
            }
        }

        public async Task DeleteImage(string imageFileName)
        {
            var contentPath = this.environment.ContentRootPath;
            var path = Path.Combine(contentPath, $"Uploads", imageFileName);
            if (File.Exists(path))
                File.Delete(path);
        }
    }
}
