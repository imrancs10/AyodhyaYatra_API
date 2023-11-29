using KaashiYatra.API.DTO.Base;
using KaashiYatra.API.DTO.Response.Image;
using KaashiYatra.API.Enums;

namespace KaashiYatra.API.DTO.Response.MasterData
{
    public class ThreeSixtyDegreeGalleryResponse : BaseResponse
    {
        public string EnName { get; set; }
        public string HiName { get; set; }
        public string TaName { get; set; }
        public string TeName { get; set; }
        public string VideoUrl { get; set; }
        public List<ImageStoreResponse> Images { get; set; }
    }
}
