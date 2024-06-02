using AyodhyaYatra.API.Contants;
using AyodhyaYatra.API.DTO.Request.NewsUpdate;
using AyodhyaYatra.API.DTO.Response.MasterData;
using AyodhyaYatra.API.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace AyodhyaYatra.API.Controllers
{
    [Route(StaticValues.APIPrefix)]
    [ApiController]
    public class NewsUpdateController : ControllerBase
    {
        #region Private Members
        private readonly INewsUpdateService _newsUpdateService;
        #endregion

        #region CTOR
        public NewsUpdateController(INewsUpdateService newsUpdateService)
        {
           _newsUpdateService = newsUpdateService;
        }
        #endregion

        #region Public Methods
        [HttpGet]
        [Route("get/newsupdate")]
        public async Task<List<NewsUpdateResponse>> GetNewsUpdate()
        {
            return await _newsUpdateService.GetNewsUpdate();
        }
        [HttpGet]
        [Route("newsupdate/get/{Id}")]
        public async Task<NewsUpdateResponse> GetNewsUpdateById([FromRoute] int Id)
        {
            return await _newsUpdateService.GetNewsUpdateById(Id);
        }
        [HttpPut]
        [Route("add/newsupdate")]
        public async Task<NewsUpdateResponse> AddNewsUpdate([FromBody] NewsUpdateRequest request)
        {
            return await _newsUpdateService.AddNewsUpdate(request);
        }

        [HttpPost]
        [Route("update/newsupdate")]
        public async Task<int> UpdateNewsUpdate([FromBody] NewsUpdateRequest request)
        {
            return await _newsUpdateService.UpdateNewsUpdate(request);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<bool> DeleteNewsUpdate([FromQuery] int id)
        {
            return await _newsUpdateService.DeleteNewsUpdate(id);
        }
        #endregion
    }
}
