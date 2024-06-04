using AyodhyaYatra.API.DTO.Response.Image;

namespace AyodhyaYatra.API.DTO.Response.MasterAttraction
{
    public class MasterAttractionTypeResponse
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string HiName { get; set; }
        public string TaName { get; set; }
        public string TeName { get; set; }
        public List<ImageStoreResponse>? Images { get; set; }
    }
}
