﻿using System.ComponentModel.DataAnnotations.Schema;

namespace AyodhyaYatra.API.Models
{
    public class ImageStore:BaseModel
    {
        public string FilePath { get; set; }
        public string? ThumbPath { get; set; }
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public string? Remark { get; set; }
        public string FileType { get; set; }
        public bool Verified { get; set; }
    }

    public class ImageStoreWithName:ImageStore
    {
        public string EnName { get; set; }
        public string HiName { get; set; }
        public string TeName { get; set; }
        public string TaName { get; set; }
    }
}
