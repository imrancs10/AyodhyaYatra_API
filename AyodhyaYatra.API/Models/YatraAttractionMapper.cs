using System.ComponentModel.DataAnnotations.Schema;

namespace AyodhyaYatra.API.Models
{
    public class YatraAttractionMapper:BaseModel
    {
        public int MasterAttractionId { get; set; }
        public int YatraId { get; set; }
        [ForeignKey("MasterAttractionId")]
        public MasterAttraction? MasterAttraction { get; set; }
        [ForeignKey("YatraId")]
        public MasterYatra? MasterYatra { get; set; }
        public int DisplayOrder { get; set; }

    }
}
