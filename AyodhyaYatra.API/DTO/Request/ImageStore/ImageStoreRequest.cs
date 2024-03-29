﻿using AyodhyaYatra.API.DTO.Base;
using Microsoft.AspNetCore.Http;

namespace AyodhyaYatra.API.DTO.Request.ImageStore
{
    public class ImageStoreRequest:BaseRequest
    {
        public IFormFile File { get; set; }
        public string ImageTag { get; set; }
        public string ModuleName { get; set; }
        public string Remark { get; set; }
    }
}
