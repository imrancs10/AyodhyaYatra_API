using System.ComponentModel.DataAnnotations.Schema;

namespace KaashiYatra.API.Models
{
    public class PhotoAlbum : BaseModel
    {
        public string EnName { get; set; }
        public string? HiName { get; set; }
        public string? TaName { get; set; }
        public string? TeName { get; set; }
        public List<ImageStore> Images { get; set; }
    }
}
