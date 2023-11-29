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
        [Route(StaticValues.MasterGetDivisionPath)]
        public async Task<List<DropdownResponse>> GetDivisions()
        {
            return await _masterDataService.GetDivisions();
        }

        [HttpGet]
        [Route(StaticValues.MasterGetPadavPath)]
        public async Task<List<MasterPadavResponse>> GetPadavs()
        {
            return await _masterDataService.GetPadavs();
        }

        [HttpGet]
        [Route(StaticValues.MasterGetPadavByYatraIdPath)]
        public async Task<List<MasterPadavResponse>> GetPadavs([FromRoute]int yatraId)
        {
            return await _masterDataService.GetPadavs(yatraId);
        }

        [HttpGet]
        [Route(StaticValues.MasterGetPadavBydPath)]
        public async Task<MasterPadavResponse> GetPadavById([FromRoute] int Id)
        {
            return await _masterDataService.GetPadavById(Id);
        }

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
        [Route(StaticValues.MasterPadavPath)]
        public async Task<MasterPadavResponse> AddPadavs(MasterPadavRequest request)
        {
            return await _masterDataService.AddPadavs(request);
        }

        [HttpPost]
        [Route(StaticValues.MasterPadavPath)]
        public async Task<int> UpdatePadavs(MasterPadavRequest request)
        {
            return await _masterDataService.UpdatePadavs(request);
        }

        [HttpPut]
        [Route(StaticValues.MasterDivisionPath)]
        public async Task<DropdownResponse> AddDivisions(MasterDataRequest request)
        {
            return await _masterDataService.AddDivisions(request);
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

        [HttpDelete]
        [Route(StaticValues.MasterPadavPath)]
        public async Task<bool> DeletePadavs([FromQuery] int id)
        {
            return await _masterDataService.DeletePadavs(id);
        }

        [HttpDelete]
        [Route(StaticValues.MasterDivisionPath)]
        public async Task<bool> DeleteDivisions([FromQuery] int id)
        {
            return await _masterDataService.DeleteDivisions(id);
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
