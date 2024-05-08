namespace AyodhyaYatra.API.DTO.Request.Yatra
{
    public class YatraAttractionMapperRequest
    {
        public int Id { get; set; }
        public int YatraId { get; set; }
        public int MasterAttractionId { get; set; }
        public int DisplayOrder { get; set; }
    }
}
