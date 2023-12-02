using AyodhyaYatra.API.DTO.Base;
using AyodhyaYatra.API.DTO.Response.Image;
using AyodhyaYatra.API.Enums;

namespace AyodhyaYatra.API.DTO.Response.MasterData
{
    public class NewsUpdateResponse : BaseResponse
    {
        public string EnTitle { get; set; }
        public string HiTitle { get; set; }
        public string TaTitle { get; set; }
        public string TeTitle { get; set; }
        public string TaDescription { get; set; }
        public string TeDescription { get; set; }
        public string WebUrl { get; set; }
        public ModuleNameEnum MasterDataType { get; set; }
        public NewsUpdateEnum NewsUpdateType { get; set; }
        public string MasterDataTypeName { get; set; }
        public string NewsUpdateTypeName { get; set; }
        public List<ImageStoreResponse> Images { get; set; }
        public string EnDescription { get; set; }
        public string HiDescription { get; set; }
        public DateTime? EventDate { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
