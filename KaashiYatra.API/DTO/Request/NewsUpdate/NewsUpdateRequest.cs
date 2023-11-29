using KaashiYatra.API.DTO.Base;
using KaashiYatra.API.DTO.Response.Image;
using KaashiYatra.API.Enums;

namespace KaashiYatra.API.DTO.Request.NewsUpdate
{
    public class NewsUpdateRequest : BaseRequest
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
        public string EnDescription { get; set; }
        public string HiDescription { get; set; }
        public string EventDate { get; set; }
    }
}
