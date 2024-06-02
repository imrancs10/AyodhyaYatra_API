using AutoMapper;
using AyodhyaYatra.API.Contants;
using AyodhyaYatra.API.Data;
using AyodhyaYatra.API.DTO.Request.NewsUpdate;
using AyodhyaYatra.API.DTO.Response.MasterAttraction;
using AyodhyaYatra.API.DTO.Response.MasterData;
using AyodhyaYatra.API.DTO.Response.Visitor;
using AyodhyaYatra.API.Exceptions;
using AyodhyaYatra.API.Models;
using AyodhyaYatra.API.Repository;
using AyodhyaYatra.API.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace AyodhyaYatra.API.Services
{
    public class FeedbackService : IFeedbackService
    {
        #region Private Members
        private readonly IMapper _mapper;
        private readonly IImageStoreRepository _imageStoreRepository;
        private AyodhyaYatraContext _context;
        #endregion

        #region CTOR
        public FeedbackService(IMapper mapper,
            IImageStoreRepository imageStoreRepository,
            AyodhyaYatraContext context)
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
            var response = new DashboardResponse
            {
                RegistrationCount = await _context.Visitors.Where(x => !x.IsDeleted).CountAsync(),
                YatraCount = await _context.MasterYatras.Where(x => !x.IsDeleted).CountAsync(),
                AttractionCounts = await _context.MasterAttractions
                .Include(x => x.MasterAttractionType)
                .Where(x => !x.IsDeleted)
                .GroupBy(x => x.AttractionTypeId)
                .Select(x => new AttractionCountResponse() 
                {
                    AttractionType = x.FirstOrDefault().MasterAttractionType.Name,
                    Count = x.Count()
                })
                .ToListAsync(),
                MonthlyVisitorCounts=await _context.Visitors
                                            .GroupBy(item => item.VisitDate.Month) // Group by month
                                            .Select(g =>new MonthlyVisitorCountResponse() {
                                                MonthYear = g.Key.ToString(), // Month
                                                Count = g.Count() // Count of items in each group
                                            }).OrderBy(x=>x.MonthYear).ToListAsync()
            };
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
