using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace AyodhyaYatra.API.Models
{

    public class Visitor:BaseModel
    {
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
        public Guid UniqueId { get; set; }

        [ForeignKey("DocumentTypeId")]
        public VisitorDocumentType? VisitorDocumentType { get; set; }

    }
}
