using AyodhyaYatra.API.Enums;

namespace AyodhyaYatra.API.Models
{
    public class MasterDataExt
    {
        public int Id { get; set; }
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
        public string? Temple360DegreeVideoURL { get; set; }
        public ModuleNameEnum MasterDataType { get; set; }
        public List<ImageStore> Images { get; set; }
        public int? ParentYatraId { get; set; }
        public double? DistanceInKM { get; set; }
        public int DisplayOrder { get; set; }
        public string? VideoURL { get; set; }
    }
}
