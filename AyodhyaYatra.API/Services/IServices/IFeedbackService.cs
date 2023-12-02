using AyodhyaYatra.API.DTO.Request;
using AyodhyaYatra.API.DTO.Request.Common;
using AyodhyaYatra.API.DTO.Request.NewsUpdate;
using AyodhyaYatra.API.DTO.Response;
using AyodhyaYatra.API.DTO.Response.Common;
using AyodhyaYatra.API.DTO.Response.MasterData;
using AyodhyaYatra.API.Enums;
using AyodhyaYatra.API.Models;

namespace AyodhyaYatra.API.Services.IServices
{
    public interface IFeedbackService
    {
        Task<List<FeedbackResponse>> GetFeedback();
        Task<DashboardResponse> GetDashboardCount();
        Task<NewsUpdateResponse> GetNewsUpdateById(int Id);
        Task<FeedbackResponse> AddFeedback(FeedbackRequest request);
        Task<bool> DeleteNewsUpdate(int id);
    }
}
