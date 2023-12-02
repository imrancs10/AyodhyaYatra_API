using AutoMapper;
using Azure;
using AyodhyaYatra.API.Contants;
using AyodhyaYatra.API.Data;
using AyodhyaYatra.API.DTO.Request;
using AyodhyaYatra.API.DTO.Request.Common;
using AyodhyaYatra.API.DTO.Request.NewsUpdate;
using AyodhyaYatra.API.DTO.Response;
using AyodhyaYatra.API.DTO.Response.Common;
using AyodhyaYatra.API.DTO.Response.Image;
using AyodhyaYatra.API.DTO.Response.MasterData;
using AyodhyaYatra.API.Enums;
using AyodhyaYatra.API.Exceptions;
using AyodhyaYatra.API.Models;
using AyodhyaYatra.API.Repository;
using AyodhyaYatra.API.Repository.IRepository;
using AyodhyaYatra.API.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace AyodhyaYatra.API.Services
{
    public class GalleryService : IGalleryService
    {
        #region Private Members
        private readonly IMapper _mapper;
        private readonly IImageStoreRepository _imageStoreRepository;
        private AyodhyaYatraContext _context;
        #endregion

        #region CTOR
        public GalleryService(IMapper mapper,
            IImageStoreRepository imageStoreRepository,
            AyodhyaYatraContext context)
        {
            _context = context;
            _mapper = mapper;
            _imageStoreRepository = imageStoreRepository;
        }
        #endregion

        #region Public Methods
        #region Photo Album
        public async Task<List<PhotoAlbumResponse>> GetPhotoAlbum()
        {
            var result = await _context.PhotoAlbum.Where(x => !x.IsDeleted).OrderBy(x => x.EnName).ToListAsync();
            var res = _mapper.Map<List<PhotoAlbumResponse>>(result);
            if (res != null && res.Count > 0)
            {
                var moduleIds = res.Select(x => x.Id).Distinct().ToList();
                var images = _mapper.Map<List<ImageStoreResponse>>(await _imageStoreRepository.GetImageStore(Enums.ModuleNameEnum.PhotoAlbum, moduleIds, true));
                foreach (var item in res)
                {
                    item.Images = images.Where(x => x.ModuleId == item.Id).ToList();
                }
            }
            return res;
        }
        public async Task<PhotoAlbumResponse> GetPhotoAlbumById(int Id)
        {
            var result = await _context.PhotoAlbum
             .Where(x => !x.IsDeleted && x.Id == Id)
             .OrderBy(x => x.EnName)
             .FirstOrDefaultAsync();
            return _mapper.Map<PhotoAlbumResponse>(result);
        }
        public async Task<PhotoAlbumResponse> AddPhotoAlbum(PhotoAlbumRequest request)
        {
            PhotoAlbum masterData = _mapper.Map<PhotoAlbum>(request);
            var oldData = await _context.PhotoAlbum.Where(x => !x.IsDeleted && x.EnName == request.EnName).CountAsync();
            if (oldData > 0) throw new BusinessRuleViolationException(StaticValues.ErrorType_AlreadyExist, StaticValues.Error_AlreadyExist);

            var entity = _context.PhotoAlbum.Add(masterData);
            entity.State = EntityState.Added;
            if (await _context.SaveChangesAsync() > 0) return _mapper.Map<PhotoAlbumResponse>(entity.Entity);
            return default(PhotoAlbumResponse);
        }
        public async Task<int> UpdatePhotoAlbum(PhotoAlbumRequest request)
        {
            var oldData = await _context.PhotoAlbum.Where(x => !x.IsDeleted && x.Id == request.Id).FirstOrDefaultAsync() ?? throw new BusinessRuleViolationException(StaticValues.ErrorType_RecordNotFound, StaticValues.Error_RecordNotFound);

            //oldData.IsDeleted = true;
            oldData.EnName = request.EnName;
            oldData.HiName = request.HiName;
            oldData.TaName = request.TaName;
            oldData.TeName = request.TeName;
            var entity = _context.Attach(oldData);
            entity.State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
        public async Task<bool> DeletePhotoAlbum(int id)
        {
            var oldData = await _context.PhotoAlbum.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();
            if (oldData == null) throw new BusinessRuleViolationException(StaticValues.ErrorType_RecordNotFound, StaticValues.Error_RecordNotFound);

            oldData.IsDeleted = true;
            var entity = _context.Attach(oldData);
            entity.State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }
        #endregion

        #region Photo Gallery
        public async Task<List<PhotoGalleryResponse>> GetPhotoGallery()
        {
            var result = await _context.PhotoGallery.Where(x => !x.IsDeleted).OrderBy(x => x.EnName).Include(x => x.PhotoAlbum).ToListAsync();
            var res = _mapper.Map<List<PhotoGalleryResponse>>(result);
            if (res != null && res.Count > 0)
            {
                var moduleIds = res.Select(x => x.Id).Distinct().ToList();
                var images = _mapper.Map<List<ImageStoreResponse>>(await _imageStoreRepository.GetImageStore(Enums.ModuleNameEnum.PhotoGallery, moduleIds, true));
                foreach (var item in res)
                {
                    item.Images = images.Where(x => x.ModuleId == item.Id).ToList();
                }
            }

            return res;
        }
        public async Task<List<PhotoGalleryResponse>> GetPhotoGalleryByAlbumId(int Id)
        {
            var result = await _context.PhotoGallery.Where(x => !x.IsDeleted && x.PhotoAlbumId == Id).OrderBy(x => x.EnName).Include(x => x.PhotoAlbum).ToListAsync();
            var res = _mapper.Map<List<PhotoGalleryResponse>>(result);
            if (res != null && res.Count > 0)
            {
                var moduleIds = res.Select(x => x.Id).Distinct().ToList();
                var images = _mapper.Map<List<ImageStoreResponse>>(await _imageStoreRepository.GetImageStore(Enums.ModuleNameEnum.PhotoGallery, moduleIds, true));
                foreach (var item in res)
                {
                    item.Images = images.Where(x => x.ModuleId == item.Id).ToList();
                }
            }

            return res;
        }
        public async Task<PhotoGalleryResponse> GetPhotoGalleryById(int Id)
        {
            var result = await _context.PhotoGallery
             .Where(x => !x.IsDeleted && x.Id == Id)
             .OrderBy(x => x.EnName)
             .FirstOrDefaultAsync();
            return _mapper.Map<PhotoGalleryResponse>(result);
        }
        public async Task<PhotoGalleryResponse> AddPhotoGallery(PhotoGalleryRequest request)
        {
            PhotoGallery masterData = _mapper.Map<PhotoGallery>(request);
            var oldData = await _context.PhotoGallery.Where(x => !x.IsDeleted && x.EnName == request.EnName).CountAsync();
            if (oldData > 0) throw new BusinessRuleViolationException(StaticValues.ErrorType_AlreadyExist, StaticValues.Error_AlreadyExist);

            var entity = _context.PhotoGallery.Add(masterData);
            entity.State = EntityState.Added;
            if (await _context.SaveChangesAsync() > 0) return _mapper.Map<PhotoGalleryResponse>(entity.Entity);
            return default(PhotoGalleryResponse);
        }
        public async Task<int> UpdatePhotoGallery(PhotoGalleryRequest request)
        {
            var oldData = await _context.PhotoGallery.Where(x => !x.IsDeleted && x.Id == request.Id).FirstOrDefaultAsync() ?? throw new BusinessRuleViolationException(StaticValues.ErrorType_RecordNotFound, StaticValues.Error_RecordNotFound);

            //oldData.IsDeleted = true;
            oldData.EnName = request.EnName;
            oldData.HiName = request.HiName;
            oldData.TaName = request.TaName;
            oldData.TeName = request.TeName;
            oldData.PhotoAlbumId = request.PhotoAlbumId;
            var entity = _context.Attach(oldData);
            entity.State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
        public async Task<bool> DeletePhotoGallery(int id)
        {
            var oldData = await _context.PhotoGallery.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();
            if (oldData == null) throw new BusinessRuleViolationException(StaticValues.ErrorType_RecordNotFound, StaticValues.Error_RecordNotFound);

            oldData.IsDeleted = true;
            var entity = _context.Attach(oldData);
            entity.State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }
        #endregion

        #region Audio Gallery
        public async Task<List<AudioGalleryResponse>> GetAudioGallery()
        {
            var result = await _context.AudioGallery.Where(x => !x.IsDeleted).OrderBy(x => x.EnName).ToListAsync();
            var res = _mapper.Map<List<AudioGalleryResponse>>(result);
            if (res != null && res.Count > 0)
            {
                var moduleIds = res.Select(x => x.Id).Distinct().ToList();
                var images = _mapper.Map<List<ImageStoreResponse>>(await _imageStoreRepository.GetImageStore(Enums.ModuleNameEnum.AudioGallery, moduleIds, true));
                foreach (var item in res)
                {
                    item.Images = images.Where(x => x.ModuleId == item.Id).ToList();
                }
            }
            return res;
        }
        public async Task<AudioGalleryResponse> GetAudioGalleryById(int Id)
        {
            var result = await _context.AudioGallery
             .Where(x => !x.IsDeleted && x.Id == Id)
             .OrderBy(x => x.EnName)
             .FirstOrDefaultAsync();
            return _mapper.Map<AudioGalleryResponse>(result);
        }
        public async Task<AudioGalleryResponse> AddAudioGallery(AudioGalleryRequest request)
        {
            AudioGallery masterData = _mapper.Map<AudioGallery>(request);
            var oldData = await _context.AudioGallery.Where(x => !x.IsDeleted && x.EnName == request.EnName).CountAsync();
            if (oldData > 0) throw new BusinessRuleViolationException(StaticValues.ErrorType_AlreadyExist, StaticValues.Error_AlreadyExist);

            var entity = _context.AudioGallery.Add(masterData);
            entity.State = EntityState.Added;
            if (await _context.SaveChangesAsync() > 0) return _mapper.Map<AudioGalleryResponse>(entity.Entity);
            return default(AudioGalleryResponse);
        }
        public async Task<int> UpdateAudioGallery(AudioGalleryRequest request)
        {
            var oldData = await _context.AudioGallery.Where(x => !x.IsDeleted && x.Id == request.Id).FirstOrDefaultAsync() ?? throw new BusinessRuleViolationException(StaticValues.ErrorType_RecordNotFound, StaticValues.Error_RecordNotFound);

            //oldData.IsDeleted = true;
            oldData.EnName = request.EnName;
            oldData.HiName = request.HiName;
            oldData.TaName = request.TaName;
            oldData.TeName = request.TeName;
            var entity = _context.Attach(oldData);
            entity.State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
        public async Task<bool> DeleteAudioGallery(int id)
        {
            var oldData = await _context.AudioGallery.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();
            if (oldData == null) throw new BusinessRuleViolationException(StaticValues.ErrorType_RecordNotFound, StaticValues.Error_RecordNotFound);

            oldData.IsDeleted = true;
            var entity = _context.Attach(oldData);
            entity.State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }
        #endregion

        #region Video Gallery
        public async Task<List<VideoGalleryResponse>> GetVideoGallery()
        {
            var result = await _context.VideoGallery.Where(x => !x.IsDeleted).OrderBy(x => x.EnName).ToListAsync();
            var res = _mapper.Map<List<VideoGalleryResponse>>(result);
            if (res != null && res.Count > 0)
            {
                var moduleIds = res.Select(x => x.Id).Distinct().ToList();
                var images = _mapper.Map<List<ImageStoreResponse>>(await _imageStoreRepository.GetImageStore(Enums.ModuleNameEnum.VideoGallery, moduleIds, true));
                foreach (var item in res)
                {
                    item.Images = images.Where(x => x.ModuleId == item.Id).ToList();
                }
            }
            return res;
        }
        public async Task<VideoGalleryResponse> GetVideoGalleryById(int Id)
        {
            var result = await _context.VideoGallery
             .Where(x => !x.IsDeleted && x.Id == Id)
             .OrderBy(x => x.EnName)
             .FirstOrDefaultAsync();
            var res = _mapper.Map<VideoGalleryResponse>(result);
            if (res != null)
            {
                var moduleId = res.Id;
                var images = _mapper.Map<List<ImageStoreResponse>>(await _imageStoreRepository.GetImageStore(Enums.ModuleNameEnum.VideoGallery, moduleId, "video"));
                res.Images = images.Where(x => x.ModuleId == moduleId).ToList();
            }
            return res;
        }
        public async Task<VideoGalleryResponse> AddVideoGallery(VideoGalleryRequest request)
        {
            VideoGallery masterData = _mapper.Map<VideoGallery>(request);
            var oldData = await _context.VideoGallery.Where(x => !x.IsDeleted && x.EnName == request.EnName).CountAsync();
            if (oldData > 0) throw new BusinessRuleViolationException(StaticValues.ErrorType_AlreadyExist, StaticValues.Error_AlreadyExist);

            var entity = _context.VideoGallery.Add(masterData);
            entity.State = EntityState.Added;
            if (await _context.SaveChangesAsync() > 0) return _mapper.Map<VideoGalleryResponse>(entity.Entity);
            return default(VideoGalleryResponse);
        }
        public async Task<int> UpdateVideoGallery(VideoGalleryRequest request)
        {
            var oldData = await _context.VideoGallery.Where(x => !x.IsDeleted && x.Id == request.Id).FirstOrDefaultAsync() ?? throw new BusinessRuleViolationException(StaticValues.ErrorType_RecordNotFound, StaticValues.Error_RecordNotFound);

            //oldData.IsDeleted = true;
            oldData.EnName = request.EnName;
            oldData.HiName = request.HiName;
            oldData.TaName = request.TaName;
            oldData.TeName = request.TeName;
            oldData.VideoUrl = request.VideoUrl;
            var entity = _context.Attach(oldData);
            entity.State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
        public async Task<bool> DeleteVideoGallery(int id)
        {
            var oldData = await _context.VideoGallery.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();
            if (oldData == null) throw new BusinessRuleViolationException(StaticValues.ErrorType_RecordNotFound, StaticValues.Error_RecordNotFound);

            oldData.IsDeleted = true;
            var entity = _context.Attach(oldData);
            entity.State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }
        #endregion

        #region 360 Gallery
        public async Task<List<ThreeSixtyDegreeGalleryResponse>> GetThreeSixtyDegreeGallery()
        {
            var result = await _context.ThreeSixtyDegreeGallery.Where(x => !x.IsDeleted).OrderBy(x => x.EnName).ToListAsync();
            var res = _mapper.Map<List<ThreeSixtyDegreeGalleryResponse>>(result);
            if (res != null && res.Count > 0)
            {
                var moduleIds = res.Select(x => x.Id).Distinct().ToList();
                var images = _mapper.Map<List<ImageStoreResponse>>(await _imageStoreRepository.GetImageStore(Enums.ModuleNameEnum.ThreeSixtyDegreeGallery, moduleIds, true));
                foreach (var item in res)
                {
                    item.Images = images.Where(x => x.ModuleId == item.Id).ToList();
                }
            }
            return res;
        }
        public async Task<ThreeSixtyDegreeGalleryResponse> GetThreeSixtyDegreeGalleryById(int Id)
        {
            var result = await _context.ThreeSixtyDegreeGallery
             .Where(x => !x.IsDeleted && x.Id == Id)
             .OrderBy(x => x.EnName)
             .FirstOrDefaultAsync();
            var res = _mapper.Map<ThreeSixtyDegreeGalleryResponse>(result);
            if (res != null)
            {
                var moduleId = res.Id;
                var images = _mapper.Map<List<ImageStoreResponse>>(await _imageStoreRepository.GetImageStore(Enums.ModuleNameEnum.ThreeSixtyDegreeGallery, moduleId, "video"));
                res.Images = images.Where(x => x.ModuleId == moduleId).ToList();
            }
            return res;
        }
        public async Task<ThreeSixtyDegreeGalleryResponse> AddThreeSixtyDegreeGallery(ThreeSixtyDegreeGalleryRequest request)
        {
            ThreeSixtyDegreeGallery masterData = _mapper.Map<ThreeSixtyDegreeGallery>(request);
            var oldData = await _context.ThreeSixtyDegreeGallery.Where(x => !x.IsDeleted && x.EnName == request.EnName).CountAsync();
            if (oldData > 0) throw new BusinessRuleViolationException(StaticValues.ErrorType_AlreadyExist, StaticValues.Error_AlreadyExist);

            var entity = _context.ThreeSixtyDegreeGallery.Add(masterData);
            entity.State = EntityState.Added;
            if (await _context.SaveChangesAsync() > 0) return _mapper.Map<ThreeSixtyDegreeGalleryResponse>(entity.Entity);
            return default(ThreeSixtyDegreeGalleryResponse);
        }
        public async Task<int> UpdateThreeSixtyDegreeGallery(ThreeSixtyDegreeGalleryRequest request)
        {
            var oldData = await _context.ThreeSixtyDegreeGallery.Where(x => !x.IsDeleted && x.Id == request.Id).FirstOrDefaultAsync() ?? throw new BusinessRuleViolationException(StaticValues.ErrorType_RecordNotFound, StaticValues.Error_RecordNotFound);

            //oldData.IsDeleted = true;
            oldData.EnName = request.EnName;
            oldData.HiName = request.HiName;
            oldData.TaName = request.TaName;
            oldData.TeName = request.TeName;
            oldData.VideoUrl = request.VideoUrl;
            var entity = _context.Attach(oldData);
            entity.State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
        public async Task<bool> DeleteThreeSixtyDegreeGallery(int id)
        {
            var oldData = await _context.ThreeSixtyDegreeGallery.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();
            if (oldData == null) throw new BusinessRuleViolationException(StaticValues.ErrorType_RecordNotFound, StaticValues.Error_RecordNotFound);

            oldData.IsDeleted = true;
            var entity = _context.Attach(oldData);
            entity.State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }
        #endregion
        #endregion
    }
}
