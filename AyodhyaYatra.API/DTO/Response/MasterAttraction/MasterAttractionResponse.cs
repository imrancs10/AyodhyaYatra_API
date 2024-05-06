using AyodhyaYatra.API.DTO.Base;
using AyodhyaYatra.API.DTO.Response.Common;
using AyodhyaYatra.API.DTO.Response.Image;
using AyodhyaYatra.API.Models;

namespace AyodhyaYatra.API.DTO.Response
{
    public class MasterAttractionResponse:BaseResponse
    {
        public string? SequenceNo { get; set; }
        public int AttractionTypeId { get; set; }
        public string AttractionType{ get; set; }
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
        public List<ImageStoreResponse> Images { get; set; }
    }
}
