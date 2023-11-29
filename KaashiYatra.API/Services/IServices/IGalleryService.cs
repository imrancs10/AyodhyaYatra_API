using KaashiYatra.API.DTO.Request;
using KaashiYatra.API.DTO.Request.Common;
using KaashiYatra.API.DTO.Request.NewsUpdate;
using KaashiYatra.API.DTO.Response;
using KaashiYatra.API.DTO.Response.Common;
using KaashiYatra.API.DTO.Response.MasterData;
using KaashiYatra.API.Enums;
using KaashiYatra.API.Models;

namespace KaashiYatra.API.Services.IServices
{
    public interface IGalleryService
    {
        //photo album
        Task<List<PhotoAlbumResponse>> GetPhotoAlbum();
        Task<PhotoAlbumResponse> GetPhotoAlbumById(int Id);
        Task<PhotoAlbumResponse> AddPhotoAlbum(PhotoAlbumRequest request);
        Task<int> UpdatePhotoAlbum(PhotoAlbumRequest request);
        Task<bool> DeletePhotoAlbum(int id);

        //photo Gallery
        Task<List<PhotoGalleryResponse>> GetPhotoGallery();
        Task<List<PhotoGalleryResponse>> GetPhotoGalleryByAlbumId(int Id);
        Task<PhotoGalleryResponse> GetPhotoGalleryById(int Id);
        Task<PhotoGalleryResponse> AddPhotoGallery(PhotoGalleryRequest request);
        Task<int> UpdatePhotoGallery(PhotoGalleryRequest request);
        Task<bool> DeletePhotoGallery(int id);

        //audio Gallery
        Task<List<AudioGalleryResponse>> GetAudioGallery();
        Task<AudioGalleryResponse> GetAudioGalleryById(int Id);
        Task<AudioGalleryResponse> AddAudioGallery(AudioGalleryRequest request);
        Task<int> UpdateAudioGallery(AudioGalleryRequest request);
        Task<bool> DeleteAudioGallery(int id);

        //Video Gallery
        Task<List<VideoGalleryResponse>> GetVideoGallery();
        Task<VideoGalleryResponse> GetVideoGalleryById(int Id);
        Task<VideoGalleryResponse> AddVideoGallery(VideoGalleryRequest request);
        Task<int> UpdateVideoGallery(VideoGalleryRequest request);
        Task<bool> DeleteVideoGallery(int id);

        //360 Gallery
        Task<List<ThreeSixtyDegreeGalleryResponse>> GetThreeSixtyDegreeGallery();
        Task<ThreeSixtyDegreeGalleryResponse> GetThreeSixtyDegreeGalleryById(int Id);
        Task<ThreeSixtyDegreeGalleryResponse> AddThreeSixtyDegreeGallery(ThreeSixtyDegreeGalleryRequest request);
        Task<int> UpdateThreeSixtyDegreeGallery(ThreeSixtyDegreeGalleryRequest request);
        Task<bool> DeleteThreeSixtyDegreeGallery(int id);

    }
}
