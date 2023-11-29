using KaashiYatra.API.DTO.Base;
using KaashiYatra.API.DTO.Response.Image;
using KaashiYatra.API.Enums;

namespace KaashiYatra.API.DTO.Request.NewsUpdate
{
    public class PhotoGalleryRequest : BaseRequest
    {
        public string EnName { get; set; }
        public string HiName { get; set; }
        public string TaName { get; set; }
        public string TeName { get; set; }
        public int? PhotoAlbumId { get; set; }
       
    }
}
