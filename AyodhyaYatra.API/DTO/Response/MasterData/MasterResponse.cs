using AyodhyaYatra.API.DTO.Base;
using AyodhyaYatra.API.DTO.Response.Image;
using AyodhyaYatra.API.Enums;

namespace AyodhyaYatra.API.DTO.Response.MasterData
{
    public class MasterResponse : BaseResponse
    {
        public MasterResponse()
        {
            Images = new List<ImageStoreResponse>();
        }
        public string EnName { get; set; }
        public string? HiName { get; set; }
        public string? TaName { get; set; }
        public string? TeName { get; set; }
        public string EnDescription { get; set; }
        public string? HiDescription { get; set; }
        public string? TaDescription { get; set; }
        public string? TeDescription { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public ModuleNameEnum MasterDataType { get; set; }
        public string MasterDataTypeName { get; set; }
        public List<ImageStoreResponse> Images { get; set; }
        public double? DistanceInKM { get; set; }
        public int? ParentYatraId { get; set; }
        public int DisplayOrder { get; set; }
    }
}
