using AutoMapper;
using AyodhyaYatra.API.Contants;
using AyodhyaYatra.API.DTO.Request;
using AyodhyaYatra.API.DTO.Request.Common;
using AyodhyaYatra.API.DTO.Request.NewsUpdate;
using AyodhyaYatra.API.DTO.Response;
using AyodhyaYatra.API.DTO.Response.Common;
using AyodhyaYatra.API.DTO.Response.MasterData;
using AyodhyaYatra.API.Enums;
using AyodhyaYatra.API.Repository.IRepository;
using AyodhyaYatra.API.Services;
using AyodhyaYatra.API.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AyodhyaYatra.API.Controllers
{
    [Route(StaticValues.APIPrefix)]
    [ApiController]
    public class GalleryController : ControllerBase
    {
        #region Private Members
        private readonly IGalleryService _galleryService;
        #endregion

        #region CTOR
        public GalleryController(IGalleryService galleryService)
        {
            _galleryService = galleryService;
        }
        #endregion

        #region Public Methods
        #region Photo Album
        [HttpGet]
        [Route("get/album")]
        public async Task<List<PhotoAlbumResponse>> GetPhotoAlbum()
        {
            return await _galleryService.GetPhotoAlbum();
        }
        [HttpGet]
        [Route("album/get/{Id}")]
        public async Task<PhotoAlbumResponse> GetPhotoAlbumById([FromRoute] int Id)
        {
            return await _galleryService.GetPhotoAlbumById(Id);
        }
        [HttpPut]
        [Route("add/album")]
        public async Task<PhotoAlbumResponse> AddPhotoAlbum([FromBody] PhotoAlbumRequest request)
        {
            return await _galleryService.AddPhotoAlbum(request);
        }

        [HttpPost]
        [Route("update/album")]
        public async Task<int> UpdatePhotoAlbum([FromBody] PhotoAlbumRequest request)
        {
            return await _galleryService.UpdatePhotoAlbum(request);
        }
        [HttpDelete]
        [Route("delete/album")]
        public async Task<bool> DeletePhotoAlbum([FromQuery] int id)
        {
            return await _galleryService.DeletePhotoAlbum(id);
        }
        #endregion

        #region Photo Gallery
        [HttpGet]
        [Route("get/photogallery")]
        public async Task<List<PhotoGalleryResponse>> GetPhotoGallery()
        {
            return await _galleryService.GetPhotoGallery();
        }
        [HttpGet]
        [Route("photogallery/get/album/{Id}")]
        public async Task<List<PhotoGalleryResponse>> GetPhotoGalleryByAlbumId([FromRoute] int Id)
        {
            return await _galleryService.GetPhotoGalleryByAlbumId(Id);
        }
        [HttpGet]
        [Route("photogallery/get/{Id}")]
        public async Task<PhotoGalleryResponse> GetPhotoGalleryById([FromRoute] int Id)
        {
            return await _galleryService.GetPhotoGalleryById(Id);
        }
        [HttpPut]
        [Route("add/photogallery")]
        public async Task<PhotoGalleryResponse> AddPhotoGallery([FromBody] PhotoGalleryRequest request)
        {
            return await _galleryService.AddPhotoGallery(request);
        }

        [HttpPost]
        [Route("update/photogallery")]
        public async Task<int> UpdatePhotoGallery([FromBody] PhotoGalleryRequest request)
        {
            return await _galleryService.UpdatePhotoGallery(request);
        }
        [HttpDelete]
        [Route("delete/photogallery")]
        public async Task<bool> DeletePhotoGallery([FromQuery] int id)
        {
            return await _galleryService.DeletePhotoGallery(id);
        }
        #endregion

        #region Audio Gallery
        [HttpGet]
        [Route("get/audiogallery")]
        public async Task<List<AudioGalleryResponse>> GetAudioGallery()
        {
            return await _galleryService.GetAudioGallery();
        }
        [HttpGet]
        [Route("audiogallery/get/{Id}")]
        public async Task<AudioGalleryResponse> GetAudioGalleryById([FromRoute] int Id)
        {
            return await _galleryService.GetAudioGalleryById(Id);
        }
        [HttpPut]
        [Route("add/audiogallery")]
        public async Task<AudioGalleryResponse> AddAudioGallery([FromBody] AudioGalleryRequest request)
        {
            return await _galleryService.AddAudioGallery(request);
        }

        [HttpPost]
        [Route("update/audiogallery")]
        public async Task<int> UpdateAudioGallery([FromBody] AudioGalleryRequest request)
        {
            return await _galleryService.UpdateAudioGallery(request);
        }
        [HttpDelete]
        [Route("delete/audiogallery")]
        public async Task<bool> DeleteAudioGallery([FromQuery] int id)
        {
            return await _galleryService.DeleteAudioGallery(id);
        }
        #endregion

        #region Video Gallery
        [HttpGet]
        [Route("get/videogallery")]
        public async Task<List<VideoGalleryResponse>> GetVideoGallery()
        {
            return await _galleryService.GetVideoGallery();
        }
        [HttpGet]
        [Route("videogallery/get/{Id}")]
        public async Task<VideoGalleryResponse> GetVideoGalleryById([FromRoute] int Id)
        {
            return await _galleryService.GetVideoGalleryById(Id);
        }
        [HttpPut]
        [Route("add/videogallery")]
        public async Task<VideoGalleryResponse> AddVideoGallery([FromBody] VideoGalleryRequest request)
        {
            return await _galleryService.AddVideoGallery(request);
        }

        [HttpPost]
        [Route("update/videogallery")]
        public async Task<int> UpdateVideoGallery([FromBody] VideoGalleryRequest request)
        {
            return await _galleryService.UpdateVideoGallery(request);
        }
        [HttpDelete]
        [Route("delete/videogallery")]
        public async Task<bool> DeleteVideoGallery([FromQuery] int id)
        {
            return await _galleryService.DeleteVideoGallery(id);
        }
        #endregion

        #region 360 Degree Gallery
        [HttpGet]
        [Route("get/threesixtydegreegallery")]
        public async Task<List<ThreeSixtyDegreeGalleryResponse>> GetThreeSixtyDegreeGallery()
        {
            return await _galleryService.GetThreeSixtyDegreeGallery();
        }
        [HttpGet]
        [Route("threesixtydegreegallery/get/{Id}")]
        public async Task<ThreeSixtyDegreeGalleryResponse> GetThreeSixtyDegreeGalleryById([FromRoute] int Id)
        {
            return await _galleryService.GetThreeSixtyDegreeGalleryById(Id);
        }
        [HttpPut]
        [Route("add/threesixtydegreegallery")]
        public async Task<ThreeSixtyDegreeGalleryResponse> AddThreeSixtyDegreeGallery([FromBody] ThreeSixtyDegreeGalleryRequest request)
        {
            return await _galleryService.AddThreeSixtyDegreeGallery(request);
        }

        [HttpPost]
        [Route("update/threesixtydegreegallery")]
        public async Task<int> UpdateThreeSixtyDegreeGallery([FromBody] ThreeSixtyDegreeGalleryRequest request)
        {
            return await _galleryService.UpdateThreeSixtyDegreeGallery(request);
        }
        [HttpDelete]
        [Route("delete/threesixtydegreegallery")]
        public async Task<bool> DeleteThreeSixtyDegreeGallery([FromQuery] int id)
        {
            return await _galleryService.DeleteThreeSixtyDegreeGallery(id);
        }
        #endregion
        #endregion
    }
}
