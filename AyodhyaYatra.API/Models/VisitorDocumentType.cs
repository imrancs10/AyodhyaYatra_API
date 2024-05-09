namespace AyodhyaYatra.API.Models
{
    public class VisitorDocumentType:BaseModel
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int MinDocNumber { get; set; }
        public int MaxDocNumber { get; set; }
        public string? DocNumberDataType { get; set; }

    }
}
