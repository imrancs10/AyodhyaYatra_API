using AutoMapper;
using AyodhyaYatra.API.Contants;
using AyodhyaYatra.API.DTO.Request;
using AyodhyaYatra.API.DTO.Request.Common;
using AyodhyaYatra.API.DTO.Request.NewsUpdate;
using AyodhyaYatra.API.DTO.Response;
using AyodhyaYatra.API.DTO.Response.Common;
using AyodhyaYatra.API.DTO.Response.MasterData;
using AyodhyaYatra.API.Enums;
using AyodhyaYatra.API.Repository.IRepository;
using AyodhyaYatra.API.Services;
using AyodhyaYatra.API.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AyodhyaYatra.API.Controllers
{
    [Route("v1/")]
    [ApiController]
    public class MasterDataController : ControllerBase
    {
        #region Private Members
        private readonly IMasterDataService _masterDataService;
        #endregion

        #region CTOR
        public MasterDataController(IMasterDataService masterDataService)
        {
           _masterDataService = masterDataService;
        }
        #endregion

        #region Public Methods


        [HttpGet]
        [Route(StaticValues.MasterGetYatraPath)]
        public async Task<List<MasterResponse>> GetYatras()
        {
            return await _masterDataService.GetYatras();
        }

        [HttpGet(StaticValues.MasterYatraGetByIdPath)]
        public async Task<MasterResponse> GetYatraById([FromRoute] int id)
        {
            return await _masterDataService.GetYatraById(id);
        }

        [HttpPut]
        [Route(StaticValues.MasterYatraPath)]
        public async Task<MasterResponse> AddYatras(MasterYatraRequest request)
        {
            return await _masterDataService.AddYatras(request);
        }
        [HttpPost]
        [Route(StaticValues.MasterYatraPath)]
        public async Task<int> UpdateYatra([FromBody] MasterYatraRequest request)
        {
            return await _masterDataService.UpdateYatra(request);
        }

        [HttpPut]
        [Route(StaticValues.MasterDataPath)]
        public async Task<int> AddMasterData([FromBody] MasterRequest request)
        {
            return await _masterDataService.AddMasterData(request);
        }

        [HttpPost]
        [Route(StaticValues.MasterDataPath)]
        public async Task<int> UpdateMasterData([FromBody] MasterRequest request)
        {
            return await _masterDataService.UpdateMasterData(request);
        }

        [HttpGet]
        [Route(StaticValues.MasterDataPath)]
        public async Task<List<MasterResponse>> GetMasterData([FromQuery] ModuleNameEnum masterDataType)
        {
            return await _masterDataService.GetMasterData(masterDataType);
        }

        [HttpGet]
        [Route(StaticValues.MasterDataGetByTypesPath)]
        public async Task<List<MasterResponse>> GetMasterData([FromQuery] List<ModuleNameEnum> masterDataType)
        {
            return await _masterDataService.GetMasterData(masterDataType);
        }

        [HttpGet]
        [Route(StaticValues.MasterDataDropdownPath)]
        public async Task<List<DropdownResponse>> GetMasterDataDropdown([FromQuery] ModuleNameEnum masterDataType)
        {
            return await _masterDataService.GetMasterDataDropdown(masterDataType);
        }

        [HttpGet]
        [Route(StaticValues.MasterDataByIdPath)]
        public async Task<MasterResponse> GetMasterDataById([FromRoute] int Id)
        {
            return await _masterDataService.GetMasterData(Id);
        }

        [HttpDelete]
        [Route(StaticValues.MasterDataPath)]
        public async Task<int> DeleteMasterData([FromQuery] int id)
        {
            return await _masterDataService.DeleteMasterData(id);
        }


        [HttpDelete]
        [Route(StaticValues.MasterYatraPath)]
        public async Task<bool> DeleteYatras([FromQuery] int id)
        {
            return await _masterDataService.DeleteYatras(id);
        }


        [HttpPost]
        [Route(StaticValues.MasterDataNearByPlacesPath)]
        public async Task<List<MasterResponse>> GetMasterDataNearByPlaces(MasterNearByPlacesRequest request)
        {
            return await _masterDataService.GetMasterDataNearByPlaces(request);
        }

        [HttpGet(StaticValues.MasterDataSearchPath)]
        public async Task<PagingResponse<MasterResponse>> SearchMasterData([FromQuery] SearchPagingRequest pagingRequest)
        {
            return await _masterDataService.SearchMasterData(pagingRequest);
        }
        #endregion
    }
}
