using AyodhyaYatra.API.DTO.Base;
using AyodhyaYatra.API.DTO.Response.Common;
using AyodhyaYatra.API.DTO.Response.Image;
using AyodhyaYatra.API.Models;

namespace AyodhyaYatra.API.DTO.Response
{
    public class TempleResponse:BaseResponse
    {
        public string EnName { get; set; }
        public string HiName { get; set; }
        public string TaName { get; set; }
        public string TeName { get; set; }
        public string EnDescription { get; set; }
        public string HiDescription { get; set; }
        public string TaDescription { get; set; }
        public string TeDescription { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int? YatraId { get; set; }
        public int? PadavId { get; set; }
        public string PadavEnName { get; set; }
        public string PadavHiName { get; set; }
        public string PadavTaName { get; set; }
        public string PadavTeName { get; set; }
        public int? TempleCategoryId { get; set; }
        public string Temple360DegreeVideoURL { get; set; }
        public string? SequenceNo { get; set; }
        public string TempleCategoryName { get; set; }
        public string TempleURL { get; set; }
        public List<ImageStoreResponse> Images { get; set; }
        public MasterYatra Yatra { get; set; }
        public string VideoURL { get; set; }
    }
}
