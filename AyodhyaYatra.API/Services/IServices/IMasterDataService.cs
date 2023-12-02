﻿using AyodhyaYatra.API.DTO.Request;
using AyodhyaYatra.API.DTO.Request.Common;
using AyodhyaYatra.API.DTO.Request.NewsUpdate;
using AyodhyaYatra.API.DTO.Response;
using AyodhyaYatra.API.DTO.Response.Common;
using AyodhyaYatra.API.DTO.Response.MasterData;
using AyodhyaYatra.API.Enums;
using AyodhyaYatra.API.Models;

namespace AyodhyaYatra.API.Services.IServices
{
    public interface IMasterDataService
    {
        Task<List<DropdownResponse>> GetDivisions();
        Task<List<MasterPadavResponse>> GetPadavs(); 
        Task<List<MasterPadavResponse>> GetPadavs(int yatraId);
        Task<List<MasterResponse>> GetYatras();
        Task<MasterResponse> GetYatraById(int id);
        Task<List<MasterResponse>> GetMasterData(ModuleNameEnum masterDataType);
        Task<List<DropdownResponse>> GetMasterDataDropdown(ModuleNameEnum masterDataType);
        Task<List<MasterResponse>> GetMasterData(List<ModuleNameEnum> masterDataTypes);

        Task<DropdownResponse> AddDivisions(MasterDataRequest request);
        Task<MasterPadavResponse> AddPadavs(MasterPadavRequest request);
        Task<int> UpdatePadavs(MasterPadavRequest request);
        Task<MasterResponse> AddYatras(MasterYatraRequest request);
        Task<int> AddMasterData(MasterRequest request);

        Task<bool> DeleteDivisions(int id);
        Task<bool> DeletePadavs(int id);
        Task<bool> DeleteYatras(int id); 
        Task<int> DeleteMasterData(int id);

        Task<MasterResponse> GetMasterData(int id);
        Task<int> UpdateMasterData(MasterRequest masterData);
        Task<int> UpdateYatra(MasterYatraRequest masterData);
        Task<MasterPadavResponse> GetPadavById(int Id);
        Task<List<MasterResponse>> GetMasterDataNearByPlaces(MasterNearByPlacesRequest request);
        Task<PagingResponse<MasterResponse>> SearchMasterData(SearchPagingRequest pagingRequest);
    }
}