using KaashiYatra.API.Enums;

namespace KaashiYatra.API.Models
{
    public class MasterData : BaseModel
    {
        public string EnName { get; set; }
        public string? HiName { get; set; }
        public string? TaName { get; set; }
        public string? TeName { get; set; }
        public string EnDescription { get; set; }
        public string? HiDescription { get; set; }
        public string? TaDescription { get; set; }
        public string? TeDescription { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public ModuleNameEnum MasterDataType { get; set; }
        public List<ImageStore> Images { get; set; }
        public int DisplayOrder { get; set; }
        public string VideoURL { get; set; } = "";
    }
}
