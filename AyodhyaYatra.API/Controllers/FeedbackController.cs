using AyodhyaYatra.API.Contants;
using AyodhyaYatra.API.DTO.Request.NewsUpdate;
using AyodhyaYatra.API.DTO.Response.MasterData;
using AyodhyaYatra.API.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace AyodhyaYatra.API.Controllers
{
    [Route(StaticValues.APIPrefix)]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        #region Private Members
        private readonly IFeedbackService _feedbackService;
        #endregion

        #region CTOR
        public FeedbackController(IFeedbackService feedbackService)
        {
           _feedbackService = feedbackService;
        }
        #endregion

        #region Public Methods
        [HttpGet]
        [Route("get/feedback")]
        public async Task<List<FeedbackResponse>> GetFeedback()
        {
            return await _feedbackService.GetFeedback();
        }
        [HttpGet]
        [Route("get/dashboardCount")]
        public async Task<DashboardResponse> GetDashboardCount()
        {
            return await _feedbackService.GetDashboardCount();
        }
        [HttpGet]
        [Route("newsupdate/get/{Id}")]
        public async Task<NewsUpdateResponse> GetNewsUpdateById([FromRoute] int Id)
        {
            return await _feedbackService.GetNewsUpdateById(Id);
        }
        [HttpPut]
        [Route("add/feedback")]
        public async Task<FeedbackResponse> AddFeedback([FromBody] FeedbackRequest request)
        {
            return await _feedbackService.AddFeedback(request);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<bool> DeleteNewsUpdate([FromQuery] int id)
        {
            return await _feedbackService.DeleteNewsUpdate(id);
        }
        #endregion
    }
}
