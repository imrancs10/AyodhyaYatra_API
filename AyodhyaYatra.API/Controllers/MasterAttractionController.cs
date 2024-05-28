using AyodhyaYatra.API.Contants;
using AyodhyaYatra.API.DTO.Request;
using AyodhyaYatra.API.DTO.Request.Common;
using AyodhyaYatra.API.DTO.Request.MasterAttraction;
using AyodhyaYatra.API.DTO.Response;
using AyodhyaYatra.API.DTO.Response.Common;
using AyodhyaYatra.API.DTO.Response.MasterAttraction;
using AyodhyaYatra.API.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace AyodhyaYatra.API.Controllers
{
    [Route("v1/")]
    [ApiController]
    public class MasterAttractionsController : ControllerBase
    {
        private readonly IMasterAttractionService _MasterAttractionService;
        private readonly IQrCodeService _qrCodeService;
        private readonly IMasterAttractionTypeService _MasterAttractionTypeService;

        public MasterAttractionsController(IMasterAttractionService MasterAttractionService, IQrCodeService qrCodeService,IMasterAttractionTypeService masterAttractionTypeService)
        {
            _MasterAttractionService = MasterAttractionService;
            _qrCodeService = qrCodeService;
            _MasterAttractionTypeService = masterAttractionTypeService;
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
        public async Task<YatraAttractionResponse> GetMasterAttractionByYatraId([FromRoute] int yatraId)
        {
            return await _MasterAttractionService.GetMasterAttractionByYatraId(yatraId);
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

        [ProducesResponseType(typeof(int), 200)]
        [HttpPut(StaticValues.MasterAttractionTypePath)]
        public async Task<int> AddAttractionType([FromBody] MasterAttractionTypeRequest req)
        {
            return await _MasterAttractionTypeService.Add(req);
        }

        [ProducesResponseType(typeof(bool), 200)]
        [HttpPost(StaticValues.MasterAttractionTypePath)]
        public async Task<bool> UpdateAttractionType([FromBody] MasterAttractionTypeRequest req)
        {
            return await _MasterAttractionTypeService.Update(req);
        }

        [ProducesResponseType(typeof(PagingResponse<MasterAttractionTypeResponse>), 200)]
        [HttpGet(StaticValues.MasterAttractionTypePath)]
        public async Task<PagingResponse<MasterAttractionTypeResponse>> GetAllAttractionType([FromQuery]PagingRequest req)
        {
            return await _MasterAttractionTypeService.GetAll(req);
        }

        [ProducesResponseType(typeof(List<MasterAttractionTypeResponse>), 200)]
        [HttpGet(StaticValues.MasterAttractionTypeSearchPath)]
        public async Task<List<MasterAttractionTypeResponse>> SearchAttractionType([FromQuery]string searchTearm)
        {
            return await _MasterAttractionTypeService.Search(searchTearm);
        }


        [ProducesResponseType(typeof(MasterAttractionTypeResponse), 200)]
        [HttpGet(StaticValues.MasterAttractionTypeGetByCodePath)]
        public async Task<MasterAttractionTypeResponse> GetAttractionTypeByCode([FromQuery]string code)
        {
            return await _MasterAttractionTypeService.GetByCode(code);
        }

        [ProducesResponseType(typeof(MasterAttractionTypeResponse), 200)]
        [HttpGet(StaticValues.MasterAttractionTypeGetByIdPath)]
        public async Task<MasterAttractionTypeResponse> GetAttractionTypeById([FromRoute] int id)
        {
            return await _MasterAttractionTypeService.GetById(id);
        }

        [ProducesResponseType(typeof(bool), 200)]
        [HttpDelete(StaticValues.MasterAttractionTypeDeletePath)]
        public async Task<bool> DeleteAttractionTypeByCode([FromRoute]int id)
        {
            return await _MasterAttractionTypeService.Delete(id);
        }
    }
}
