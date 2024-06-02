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
    public class NewsUpdateService : INewsUpdateService
    {
        #region Private Members
        private readonly IMapper _mapper;
        private readonly IImageStoreRepository _imageStoreRepository;
        private AyodhyaYatraContext _context;
        #endregion

        #region CTOR
        public NewsUpdateService(IMapper mapper,
            IImageStoreRepository imageStoreRepository,
            AyodhyaYatraContext context)
        {
            _context = context;
            _mapper = mapper;
            _imageStoreRepository = imageStoreRepository;
        }

        public async Task<NewsUpdateResponse> AddNewsUpdate(NewsUpdateRequest request)
        {
            NewsUpdate masterData = _mapper.Map<NewsUpdate>(request);
            var oldData = await _context.NewsUpdates.Where(x => !x.IsDeleted && x.NewsUpdateType == request.NewsUpdateType && x.EnTitle == request.EnTitle).CountAsync();
            if (oldData > 0) throw new BusinessRuleViolationException(StaticValues.ErrorType_AlreadyExist, StaticValues.Error_AlreadyExist);

            var entity = _context.NewsUpdates.Add(masterData);
            entity.State = EntityState.Added;
            if (await _context.SaveChangesAsync() > 0) return _mapper.Map<NewsUpdateResponse>(entity.Entity);
            return default(NewsUpdateResponse);
        }
        public async Task<int> UpdateNewsUpdate(NewsUpdateRequest request)
        {
            var oldData = await _context.NewsUpdates.Where(x => !x.IsDeleted && x.Id == request.Id).FirstOrDefaultAsync() ?? throw new BusinessRuleViolationException(StaticValues.ErrorType_RecordNotFound, StaticValues.Error_RecordNotFound);

            //oldData.IsDeleted = true;
            oldData.EnDescription = request.EnDescription;
            oldData.HiDescription = request.HiDescription;
            oldData.EnTitle = request.EnTitle;
            oldData.HiTitle = request.HiTitle;
            oldData.TaDescription = request.TaDescription;
            oldData.TeDescription = request.TeDescription;
            oldData.TaTitle = request.TaTitle;
            oldData.TeTitle = request.TeTitle;
            oldData.EventDate = !string.IsNullOrEmpty(request.EventDate) ? Convert.ToDateTime(request.EventDate) : null;
            oldData.WebUrl = request.WebUrl;
            oldData.NewsUpdateType = request.NewsUpdateType;
            var entity = _context.Attach(oldData);
            entity.State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
        public async Task<bool> DeleteNewsUpdate(int id)
        {
            var oldData = await _context.NewsUpdates.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();
            if (oldData == null) throw new BusinessRuleViolationException(StaticValues.ErrorType_RecordNotFound, StaticValues.Error_RecordNotFound);

            oldData.IsDeleted = true;
            var entity = _context.Attach(oldData);
            entity.State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }
        #endregion

        #region Public Methods
        public async Task<List<NewsUpdateResponse>> GetNewsUpdate()
        {
            var result = await _context.NewsUpdates.Where(x => !x.IsDeleted).OrderBy(x => x.EnTitle).ToListAsync();
            var res = _mapper.Map<List<NewsUpdateResponse>>(result);
            if (res != null && res.Count > 0)
            {
                var moduleIds = res.Select(x => x.Id).Distinct().ToList();
                var images = _mapper.Map<List<ImageStoreResponse>>(await _imageStoreRepository.GetImageStore(Enums.ModuleNameEnum.NewsUpdate, moduleIds, "image"));
                foreach (var item in res)
                {
                    item.Images = images.Where(x => x.ModuleId == item.Id).ToList();
                }
            }
            res.ForEach(x =>
            {
                x.MasterDataTypeName = x.MasterDataType.ToString();
                x.NewsUpdateTypeName = x.NewsUpdateType.ToString();
            });
            return res;
        }
        public async Task<NewsUpdateResponse> GetNewsUpdateById(int Id)
        {
            var result = await _context.NewsUpdates
             .Where(x => !x.IsDeleted && x.Id == Id)
             .OrderBy(x => x.NewsUpdateType)
             .FirstOrDefaultAsync();
            var res = _mapper.Map<NewsUpdateResponse>(result);
            if (res != null)
            {
                var moduleIds = res.Id;
                var images = _mapper.Map<List<ImageStoreResponse>>(await _imageStoreRepository.GetImageStore(Enums.ModuleNameEnum.NewsUpdate, moduleIds, "image"));
                res.Images = images.Where(x => x.ModuleId == moduleIds).ToList();
            }
            res.MasterDataTypeName = res.MasterDataType.ToString();
            res.NewsUpdateTypeName = res.NewsUpdateType.ToString();
            return res;
        }

        #endregion
    }
}
