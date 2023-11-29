using AutoMapper;
using Azure;
using KaashiYatra.API.Contants;
using KaashiYatra.API.Data;
using KaashiYatra.API.DTO.Request;
using KaashiYatra.API.DTO.Request.Common;
using KaashiYatra.API.DTO.Request.NewsUpdate;
using KaashiYatra.API.DTO.Response;
using KaashiYatra.API.DTO.Response.Common;
using KaashiYatra.API.DTO.Response.Image;
using KaashiYatra.API.DTO.Response.MasterData;
using KaashiYatra.API.Enums;
using KaashiYatra.API.Exceptions;
using KaashiYatra.API.Models;
using KaashiYatra.API.Repository;
using KaashiYatra.API.Repository.IRepository;
using KaashiYatra.API.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace KaashiYatra.API.Services
{
    public class FeedbackService : IFeedbackService
    {
        #region Private Members
        private readonly IMapper _mapper;
        private readonly IImageStoreRepository _imageStoreRepository;
        private KaashiYatraContext _context;
        #endregion

        #region CTOR
        public FeedbackService(IMapper mapper,
            IImageStoreRepository imageStoreRepository,
            KaashiYatraContext context)
        {
            _context = context;
            _mapper = mapper;
            _imageStoreRepository = imageStoreRepository;
        }
        #endregion

        #region Public Methods
        public async Task<FeedbackResponse> AddFeedback(FeedbackRequest request)
        {
            Feedback masterData = _mapper.Map<Feedback>(request);
            var entity = _context.Feedbacks.Add(masterData);
            entity.State = EntityState.Added;
            if (await _context.SaveChangesAsync() > 0) return _mapper.Map<FeedbackResponse>(entity.Entity);
            return default(FeedbackResponse);
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
        public async Task<List<FeedbackResponse>> GetFeedback()
        {
            var result = await _context.Feedbacks.Where(x => !x.IsDeleted).OrderByDescending(x => x.UpdatedAt).ToListAsync();
            var res = _mapper.Map<List<FeedbackResponse>>(result);
            return res;
        }
        public async Task<DashboardResponse> GetDashboardCount()
        {
            var response = new DashboardResponse();
            response.TempleCount = await _context.Temples.Where(x => !x.IsDeleted).CountAsync();
            response.RegistrationCount = await _context.Users.Where(x => !x.IsDeleted).CountAsync();
            response.YatraCount = await _context.MasterYatras.Where(x => !x.IsDeleted).CountAsync();
            return response;
        }
        public async Task<NewsUpdateResponse> GetNewsUpdateById(int Id)
        {
            var result = await _context.NewsUpdates
             .Where(x => !x.IsDeleted && x.Id == Id)
             .OrderBy(x => x.NewsUpdateType)
             .FirstOrDefaultAsync();
            return _mapper.Map<NewsUpdateResponse>(result);
        }

        #endregion
    }
}
