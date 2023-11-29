using KaashiYatra.API.DTO.Base;
using KaashiYatra.API.DTO.Response.Image;
using KaashiYatra.API.Enums;

namespace KaashiYatra.API.DTO.Response.MasterData
{
    public class FeedbackResponse : BaseResponse
    {
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string FeedbackComment { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
