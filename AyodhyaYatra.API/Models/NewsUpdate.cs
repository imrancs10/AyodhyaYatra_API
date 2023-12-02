using AyodhyaYatra.API.Enums;

namespace AyodhyaYatra.API.Models
{
    public class NewsUpdate : BaseModel
    {
        public string EnTitle { get; set; }
        public string? HiTitle { get; set; }
        public string? TaTitle { get; set; }
        public string? TeTitle { get; set; }
        public string? WebUrl { get; set; }
        public ModuleNameEnum MasterDataType { get; set; }
        public NewsUpdateEnum NewsUpdateType { get; set; }
        public string EnDescription { get; set; }
        public string? HiDescription { get; set; }
        public string? TaDescription { get; set; }
        public string? TeDescription { get; set; }
        public DateTime? EventDate { get; set; }
        public List<ImageStore> Images { get; set; }
    }
}
