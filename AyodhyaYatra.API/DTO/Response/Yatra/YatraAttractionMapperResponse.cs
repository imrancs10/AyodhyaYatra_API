using AyodhyaYatra.API.DTO.Response.MasterData;

namespace AyodhyaYatra.API.DTO.Response.Yatra
{
    public class YatraAttractionMapperResponse
    {
        public int Id { get; set; }
        public int YatraId { get; set; }
        public int MasterAttractionId { get; set; }
        public string? YatraName { get; set; }
        public MasterResponse? Yatra { get; set; }
        public string? MasterAttractionName { get; set; }
        public MasterAttractionResponse? MasterAttractionResponse { get; set; }
        public int DisplayOrder { get; set; }
    }
}
