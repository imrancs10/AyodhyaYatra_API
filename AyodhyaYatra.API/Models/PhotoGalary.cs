using System.ComponentModel.DataAnnotations.Schema;

namespace AyodhyaYatra.API.Models
{
    public class PhotoGallery : BaseModel
    {
        public string EnName { get; set; }
        public string? HiName { get; set; }
        public string? TaName { get; set; }
        public string? TeName { get; set; }
        public int? PhotoAlbumId { get; set; }
        [ForeignKey("PhotoAlbumId")]
        public PhotoAlbum? PhotoAlbum { get; set; }
        public List<ImageStore> Images { get; set; }
    }
}
