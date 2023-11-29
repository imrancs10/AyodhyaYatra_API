using KaashiYatra.API.DTO.Base;
using KaashiYatra.API.DTO.Response.Image;
using KaashiYatra.API.Enums;

namespace KaashiYatra.API.DTO.Request.NewsUpdate
{
    public class FeedbackRequest : BaseRequest
    {
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string FeedbackComment { get; set; }
    }
}
