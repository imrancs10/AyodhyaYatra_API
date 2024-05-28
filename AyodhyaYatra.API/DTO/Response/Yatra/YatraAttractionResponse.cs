using AyodhyaYatra.API.DTO.Response.MasterData;

namespace AyodhyaYatra.API.DTO.Response
{
    public class YatraAttractionResponse
    {
        public MasterResponse Yatra { get; set; }
        public List<MasterAttractionResponse> Attractions { get; set; }
    }
}
