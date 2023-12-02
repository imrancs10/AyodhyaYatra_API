using AyodhyaYatra.API.DTO.Base;
using AyodhyaYatra.API.DTO.Response.Image;
using AyodhyaYatra.API.Enums;

namespace AyodhyaYatra.API.DTO.Response
{
    public class MasterPadavResponse : BaseResponse
    {
        public int YatraId { get; set; }
        public string EnYatraName { get; set; }
        public string HiYatraName { get; set; }
        public string TaYatraName { get; set; }
        public string TeYatraName { get; set; }
        public string EnPadavName { get; set; }
        public string? HiPadavName { get; set; }
        public string TaPadavName { get; set; }
        public string? TePadavName { get; set; }
        public string EnDescription { get; set; }
        public string? HiDescription { get; set; }
        public string TaDescription { get; set; }
        public string? TeDescription { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public ModuleNameEnum MasterDataType { get; set; }
        public string MasterDataTypeName { get; set; }
        public List<ImageStoreResponse> Images { get; set; }
    }
}
