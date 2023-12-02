using System.ComponentModel.DataAnnotations.Schema;

namespace AyodhyaYatra.API.Models
{
    public class ThreeSixtyDegreeGallery : BaseModel
    {
        public string EnName { get; set; }
        public string? HiName { get; set; }
        public string? TaName { get; set; }
        public string? TeName { get; set; }
        public string? VideoUrl { get; set; }
        public List<ImageStore> Images { get; set; }
    }
}
