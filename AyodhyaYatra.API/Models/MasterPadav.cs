using System.ComponentModel.DataAnnotations.Schema;

namespace AyodhyaYatra.API.Models
{
    public class MasterPadav : BaseModel
    {
        public int? YatraId { get; set; } = null;
        public string EnName { get; set; }
        public string? HiName { get; set; }
        public string? TaName { get; set; }
        public string? TeName { get; set; }
        public string? TaDescription { get; set; }
        public string? TeDescription { get; set; }
        public string EnDescription { get; set; }
        public string? HiDescription { get; set; }
        public List<ImageStore> Images { get; set; }

        [ForeignKey("YatraId")]
        public MasterYatra Yatra { get; set; }
    }
}
