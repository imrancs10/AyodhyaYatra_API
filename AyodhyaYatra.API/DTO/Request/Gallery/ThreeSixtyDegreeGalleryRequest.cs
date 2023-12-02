using AyodhyaYatra.API.DTO.Base;
using AyodhyaYatra.API.DTO.Response.Image;
using AyodhyaYatra.API.Enums;

namespace AyodhyaYatra.API.DTO.Request.NewsUpdate
{
    public class ThreeSixtyDegreeGalleryRequest : BaseRequest
    {
        public string EnName { get; set; }
        public string HiName { get; set; }
        public string TaName { get; set; }
        public string TeName { get; set; }
        public string VideoUrl { get; set; }
    }
}
