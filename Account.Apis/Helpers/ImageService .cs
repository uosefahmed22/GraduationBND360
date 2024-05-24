using Account.Core.Services.Content;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;

namespace Account.Reposatory.Services.Content
{
    public class ImageService : IImageService
    {
        private readonly Cloudinary _cloudinary;
        private readonly string[] _allowedExtensions = new string[] { ".jpg", ".png", ".jpeg" };

        public ImageService(Cloudinary cloudinary)
        {
            _cloudinary = cloudinary ?? throw new ArgumentNullException(nameof(cloudinary));
        }

        public async Task<Tuple<int, string>> SaveImageAsync(IFormFile imageFile)
        {
            return await UploadImageAsync(imageFile);
        }
        public async Task<Tuple<int, string>> UploadImageAsync(IFormFile imageFile)
        {
            try
            {
                var ext = Path.GetExtension(imageFile.FileName).ToLower();
                if (!_allowedExtensions.Contains(ext))
                {
                    string msg = $"Only {string.Join(", ", _allowedExtensions)} extensions are allowed";
                    return new Tuple<int, string>(0, msg);
                }

                await using var stream = imageFile.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(imageFile.FileName, stream)
                };

                var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                if (uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return new Tuple<int, string>(1, uploadResult.SecureUrl.AbsoluteUri);
                }
                else
                {
                    // Log detailed information
                    string errorMessage = $"Error occurred while uploading the image. Status Code: {uploadResult.StatusCode}, Error: {uploadResult.Error?.Message}";
                    Console.WriteLine(errorMessage); // Replace with your logging framework
                    return new Tuple<int, string>(0, errorMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}"); // Replace with your logging framework
                return new Tuple<int, string>(0, $"Error has occurred: {ex.Message}");
            }
        }
        public async Task DeleteImageAsync(string imageUrl)
        {
            try
            {
                var publicId = GetPublicIdFromUrl(imageUrl);
                var deletionParams = new DeletionParams(publicId);
                await _cloudinary.DestroyAsync(deletionParams);
            }
            catch (Exception ex)
            {
            }
        }
        private string GetPublicIdFromUrl(string url)
        {
            var uri = new Uri(url);
            var path = uri.AbsolutePath;
            return path.Substring(path.LastIndexOf('/') + 1).Split('.')[0];
        }
    }


}
