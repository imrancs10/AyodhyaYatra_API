

using KaashiYatra.API.DTO.Base;
using KaashiYatra.API.DTO.Request.ImageStore;
using KaashiYatra.API.Models;

namespace KaashiYatra.API.DTO.Request
{
    public class TempleRequest:BaseRequest
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
        public string Temple360DegreeVideoURL { get; set; }
        public string? SequenceNo { get; set; }
        public int? TempleCategoryId { get; set; }
        public string TempleURL { get; set; }
        public string VideoURL { get; set; }
    }
}
