using AyodhyaYatra.API.DTO.Base;
using AyodhyaYatra.API.Enums;

namespace AyodhyaYatra.API.DTO.Request.Common
{
    public class MasterDataRequest : BaseRequest
    {
        public string Value { get; set; }
    }

    public class MasterDataRequest<T> : BaseRequest
    {
        public T Value { get; set; }
    }

    public class MasterRequest : BaseRequest
    {
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
    }

    public class MasterNearByPlacesRequest
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public double? NearByRangeInKM { get; set; }
    }
}
