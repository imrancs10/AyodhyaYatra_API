namespace AyodhyaYatra.API.DTO.Request.Visitor
{
    public class VisitorDocumentTypeRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int MinDocNumber { get; set; }
        public int MaxDocNumber { get; set; }
        public string? DocNumberDataType { get; set; }
    }
}
