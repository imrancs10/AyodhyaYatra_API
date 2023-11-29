using AutoMapper;
using KaashiYatra.API.Contants;
using KaashiYatra.API.DTO.Request;
using KaashiYatra.API.DTO.Request.Common;
using KaashiYatra.API.DTO.Request.NewsUpdate;
using KaashiYatra.API.DTO.Response;
using KaashiYatra.API.DTO.Response.Common;
using KaashiYatra.API.DTO.Response.MasterData;
using KaashiYatra.API.Enums;
using KaashiYatra.API.Repository.IRepository;
using KaashiYatra.API.Services;
using KaashiYatra.API.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KaashiYatra.API.Controllers
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
