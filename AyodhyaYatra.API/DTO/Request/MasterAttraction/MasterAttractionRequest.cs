

using AyodhyaYatra.API.DTO.Base;
using AyodhyaYatra.API.DTO.Request.ImageStore;
using AyodhyaYatra.API.Models;

namespace AyodhyaYatra.API.DTO.Request
{
    public class MasterAttractionRequest:BaseRequest
    {
        public string? SequenceNo { get; set; }
        public int AttractionTypeId { get; set; }
        public string? EnName { get; set; }
        public string? HiName { get; set; }
        public string? TaName { get; set; }
        public string? TeName { get; set; }
        public string? EnDescription { get; set; }
        public string? HiDescription { get; set; }
        public string? TaDescription { get; set; }
        public string? TeDescription { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public string? Video360URL { get; set; }
        public string? AttractionURL { get; set; }
        public string? VideoURL { get; set; }
        public string? BarcodeId { get; set; }
    }
}
