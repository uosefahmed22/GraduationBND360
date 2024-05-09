using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Services.Content
{
    public interface IFileService
    {
        Tuple<int, List<string>> SaveImages(List<IFormFile> imageFiles);
        public Task DeleteImage(string imageFileName);
    }
}
