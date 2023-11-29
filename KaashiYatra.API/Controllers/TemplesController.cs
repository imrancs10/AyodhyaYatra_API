using Azure.Core;
using KaashiYatra.API.Contants;
using KaashiYatra.API.DTO.Request;
using KaashiYatra.API.DTO.Request.Common;
using KaashiYatra.API.DTO.Response;
using KaashiYatra.API.DTO.Response.Common;
using KaashiYatra.API.Services;
using KaashiYatra.API.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace KaashiYatra.API.Controllers
{
    [Route(StaticValues.APIPrefix)]
    [ApiController]
    public class TemplesController : ControllerBase
    {
        private readonly ITempleService _templeService;
        private readonly IQrCodeService _qrCodeService;

        public TemplesController(ITempleService templeService, IQrCodeService qrCodeService)
        {
            _templeService = templeService;
            _qrCodeService = qrCodeService;
        }

        [HttpPut(StaticValues.TemplePath)]
        public async Task<TempleResponse> AddTemple([FromBody] TempleRequest request)
        {
            return await _templeService.AddTemple(request);
        }

        [HttpDelete(StaticValues.TempleDeletePath)]
        public async Task<bool> DeleteTemple([FromRoute] int id)
        {
            return await _templeService.DeleteTemple(id);
        }

        [HttpGet(StaticValues.TempleGetByIdPath)]
        public async Task<TempleResponse> GetTempleById([FromRoute] int id)
        {
            return await _templeService.GetTempleById(id);
        }

        [HttpGet(StaticValues.TempleGetByIdOrBarcodeIdPath)]
        public async Task<TempleResponse> GetTempleById([FromRoute] string barcodeId)
        {
            return await _templeService.GetTempleById(barcodeId);
        }

        [HttpGet(StaticValues.TempleGetByYatraIdPath)]
        public async Task<List<TempleResponse>> GetTempleByYatraId([FromRoute] int yatraId, [FromQuery] bool includeAllChildYatraTemple = false)
        {
            return await _templeService.GetTempleByYatraId(yatraId,includeAllChildYatraTemple);
        }

        [HttpGet(StaticValues.TemplePath)]
        public async Task<PagingResponse<TempleResponse>> GetTemples([FromQuery] PagingRequest pagingRequest)
        {
            return await _templeService.GetTemples(pagingRequest);
        }

        [HttpGet(StaticValues.TempleSearchPath)]
        public async Task<PagingResponse<TempleResponse>> SearchTemples([FromQuery] SearchPagingRequest pagingRequest)
        {
            return await _templeService.SearchTemples(pagingRequest);
        }

        [HttpPost(StaticValues.TemplePath)]
        public async Task<TempleResponse> UpdateTemple([FromBody] TempleRequest request)
        {
            return await _templeService.UpdateTemple(request);
        }
        [HttpGet(StaticValues.TempleGetByPadavIdPath)]
        public async Task<List<TempleResponse>> GetTempleByPadavId([FromRoute] int padavId)
        {
            return await _templeService.GetTempleByPadavId(padavId);
        }
        [HttpGet(StaticValues.TempleGetByYatraPadavIdPath)]
        public async Task<List<TempleResponse>> GetTempleByYatraAndPadavId([FromRoute] int yatraId, [FromRoute] int padavId)
        {
            return await _templeService.GetTempleByYatraAndPadavId(yatraId, padavId);
        }

        [HttpGet(StaticValues.GenerateTempleQrCodePath)]
        public async Task<bool> GenerateTemplesQrCode()
        {
            return await _qrCodeService.GenerateTemplesQrCode();
        }

        [HttpPost(StaticValues.TempleUpdateFromExcelPath)]
        public async Task<string> UpdateDataFromExcel(IFormFile file)
        {
            return await _templeService.UpdateTempleFromExcel(file);
        }

        //[HttpGet]
        //[Route(StaticValues.TempleCategoryPath)]
        //public async Task<List<TempleCategoryResponse>> GetTempleCategory()
        //{
        //    return await _templeService.GetTempleCategory();
        //}
    }
}
