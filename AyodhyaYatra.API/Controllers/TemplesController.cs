using AyodhyaYatra.API.Contants;
using AyodhyaYatra.API.DTO.Request;
using AyodhyaYatra.API.DTO.Request.Common;
using AyodhyaYatra.API.DTO.Response;
using AyodhyaYatra.API.DTO.Response.Common;
using AyodhyaYatra.API.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace AyodhyaYatra.API.Controllers
{
    [Route(StaticValues.APIPrefix)]
    [ApiController]
    public class MasterAttractionsController : ControllerBase
    {
        private readonly IMasterAttractionService _MasterAttractionService;
        private readonly IQrCodeService _qrCodeService;

        public MasterAttractionsController(IMasterAttractionService MasterAttractionService, IQrCodeService qrCodeService)
        {
            _MasterAttractionService = MasterAttractionService;
            _qrCodeService = qrCodeService;
        }

        [HttpPut(StaticValues.MasterAttractionPath)]
        public async Task<MasterAttractionResponse> AddMasterAttraction([FromBody] MasterAttractionRequest request)
        {
            return await _MasterAttractionService.AddMasterAttraction(request);
        }

        [HttpDelete(StaticValues.MasterAttractionDeletePath)]
        public async Task<bool> DeleteMasterAttraction([FromRoute] int id)
        {
            return await _MasterAttractionService.DeleteMasterAttraction(id);
        }

        [HttpGet(StaticValues.MasterAttractionGetByIdPath)]
        public async Task<MasterAttractionResponse> GetMasterAttractionById([FromRoute] int id)
        {
            return await _MasterAttractionService.GetMasterAttractionById(id);
        }

        [HttpGet(StaticValues.MasterAttractionGetByIdOrBarcodeIdPath)]
        public async Task<MasterAttractionResponse> GetMasterAttractionById([FromRoute] string barcodeId)
        {
            return await _MasterAttractionService.GetMasterAttractionById(barcodeId);
        }

        [HttpGet(StaticValues.MasterAttractionGetByYatraIdPath)]
        public async Task<List<MasterAttractionResponse>> GetMasterAttractionByYatraId([FromRoute] int yatraId, [FromQuery] bool includeAllChildYatraMasterAttraction = false)
        {
            return await _MasterAttractionService.GetMasterAttractionByYatraId(yatraId,includeAllChildYatraMasterAttraction);
        }

        [HttpGet(StaticValues.MasterAttractionPath)]
        public async Task<PagingResponse<MasterAttractionResponse>> GetMasterAttractions([FromQuery] PagingRequest pagingRequest)
        {
            return await _MasterAttractionService.GetMasterAttractions(pagingRequest);
        }

        [HttpGet(StaticValues.MasterAttractionSearchPath)]
        public async Task<PagingResponse<MasterAttractionResponse>> SearchMasterAttractions([FromQuery] SearchPagingRequest pagingRequest)
        {
            return await _MasterAttractionService.SearchMasterAttractions(pagingRequest);
        }

        [HttpPost(StaticValues.MasterAttractionPath)]
        public async Task<MasterAttractionResponse> UpdateMasterAttraction([FromBody] MasterAttractionRequest request)
        {
            return await _MasterAttractionService.UpdateMasterAttraction(request);
        }

        [HttpGet(StaticValues.GenerateMasterAttractionQrCodePath)]
        public async Task<bool> GenerateMasterAttractionsQrCode()
        {
            return await _qrCodeService.GenerateMasterAttractionQrCode();
        }

        [HttpPost(StaticValues.MasterAttractionUpdateFromExcelPath)]
        public async Task<string> UpdateDataFromExcel(IFormFile file)
        {
            return await _MasterAttractionService.UpdateMasterAttractionFromExcel(file);
        }

        //[HttpGet]
        //[Route(StaticValues.MasterAttractionCategoryPath)]
        //public async Task<List<MasterAttractionCategoryResponse>> GetMasterAttractionCategory()
        //{
        //    return await _MasterAttractionService.GetMasterAttractionCategory();
        //}
    }
}
