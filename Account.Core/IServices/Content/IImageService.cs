﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Services.Content
{
    public interface IImageService
    {
        Task<Tuple<int, string>> SaveImageAsync(IFormFile imageFile);
        Task DeleteImageAsync(string imageFileName);
        Task<Tuple<int, string>> UploadImageAsync(IFormFile imageFile);
    }

}
