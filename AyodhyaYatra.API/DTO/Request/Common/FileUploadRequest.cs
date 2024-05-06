using AyodhyaYatra.API.Contants;
using AyodhyaYatra.API.Enums;
using Newtonsoft.Json;

namespace AyodhyaYatra.API.DTO.Request
{
    public class FileUploadQueryRequest
    {
        public int ModuleId { get; set; }
        public ModuleNameEnum ModuleName { get; set; }
        public bool CreateThumbnail { get; set; } = true;
        public string Remark { get; set; }
        public int SequenceNo { get; set; }
        public string FileType { get; set; } = "Image";
    }
    public class FileUploadRequest: FileUploadQueryRequest
    {
        //[AllowedExtensions(new string[] { ".jpg", ".png", ".jpeg", "image/png", "image/jpeg" })]
        //[MaxFileSize(StaticValues.MaxAllowedFileSize)]
        [JsonIgnore]
        public IFormFile File { get; set; }
    }
}
