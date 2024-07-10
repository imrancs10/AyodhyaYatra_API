namespace AyodhyaYatra.API.DTO.Response.Visitor
{
    public class VisitorResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Mobile { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? DocumentNumber { get; set; }
        public int DocumentTypeId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime VisitDate { get; set; }
        public string DocumentType { get; set; }
        public Guid UniqueId { get; set; }

        public string? QrImage { get; set; }
    }
}
