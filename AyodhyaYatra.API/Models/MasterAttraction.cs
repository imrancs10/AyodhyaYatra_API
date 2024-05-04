using System.ComponentModel.DataAnnotations.Schema;

namespace AyodhyaYatra.API.Models
{
    public class MasterAttraction : BaseModel
    {
        public string? SequenceNo { get; set; }
        public int AttractionTypeId { get; set; }
        public string? EnName { get; set; }
        public string? HiName { get; set; }
        public string? TaName { get; set; }
        public string? TeName { get; set; }
        public string? EnDescription { get; set; }
        public string? HiDescription { get; set; }
        public string? TaDescription { get; set; }
        public string? TeDescription { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public string? Video360URL { get; set; }
        public List<ImageStore>? Images { get; set; }
        public bool Verified { get; set; }
        public string? AttractionURL { get; set; }
        public string? VideoURL { get; set; }
        public string? BarcodeId { get; set; }
        [ForeignKey("AttractionTypeId")]
        public MasterAttractionType? MasterAttractionType { get; set; }
    }
}
